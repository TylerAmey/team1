using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnrollBasics;

namespace SearchLib
{
    public class SearchResult : IComparable
    {
        public Course course { get { return section.ParentCourse; } }
        public Section section;
        public int relevance;

        public string Name { get { return course.name; } }

        public SearchResult(Section section, int relevance)
        {
            this.section = section;
            this.relevance = relevance; 
        }

        private class SortRelevanceHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                SearchResult s1 = (SearchResult)a;
                SearchResult s2 = (SearchResult)b;
                return s1.relevance - s2.relevance;
            }
        }

        private class SortAlphabeticalDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                SearchResult s1 = (SearchResult)a;
                SearchResult s2 = (SearchResult)b;
                return s1.Name.CompareTo(s2.Name);
            }
        }

        private class SortAlphabeticalAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                SearchResult s1 = (SearchResult)a;
                SearchResult s2 = (SearchResult)b;
                return s2.Name.CompareTo(s1.Name);
            }
        }

        int IComparable.CompareTo(object obj)
        {
            SearchResult s = (SearchResult)obj;
            return SortAlphabeticalDescending().Compare(this, s);
        }

        public static IComparer SortRelevance()
        {
            return (IComparer) new SortRelevanceHelper();
        }

        public static IComparer SortAlphabeticalDescending()
        {
            return (IComparer)new SortAlphabeticalDescendingHelper();
        }

        public static IComparer SortAlphabeticalAscending()
        {
            return (IComparer)new SortAlphabeticalAscendingHelper();
        }

    }

    public interface IQuerySimilar
    {
        int GetDistance(Section section);
    }

    public abstract class QueryCondition { 
        public abstract bool IsSatisfied(Section section);
    }

    public abstract class QueryCondition<T> : QueryCondition
    {
        public T Query;

        public QueryCondition(T query)
        {
            Query = query;
        }
    }

    public class QueryNumber : QueryCondition<int>, IQuerySimilar
    {
        public QueryNumber(int query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            Course course = section.ParentCourse;
            return course.id.Contains(Query.ToString());
        }

        public int GetDistance(Section section)
        {
            Course course = section.ParentCourse;
            char[] cQuery = Query.ToString().ToCharArray();
            char[] cNumber = course.id.Substring(4).ToCharArray();

            int distance = 0;
            for (int i = 0; i < cQuery.Length; i++)
            {
                distance += Math.Abs(cQuery[i] - cNumber[i]);
            }
            return distance;
        }
    }

    public class QueryCode : QueryCondition<int>, IQuerySimilar
    {
        public QueryCode(int query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            Course course = section.ParentCourse;
            return course.crn == Query;
        }

        public int GetDistance(Section section)
        {
            Course course = section.ParentCourse;
            return Math.Abs(course.crn - Query);
        }
    }

    public class QueryKeyword : QueryCondition<string>, IQuerySimilar
    {
        public QueryKeyword(string query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            Course course = section.ParentCourse;

            return (
                course.name.ToLower().Contains(Query.ToLower()) ||
                course.id.ToLower().Contains(Query.ToLower()) ||
                course.description.ToLower().Contains(Query.ToLower()) );
        }

        public int GetDistance(Section section)
        {
            int distance = 0;
            Course course = section.ParentCourse;

            foreach (string word in Query.Split(' '))
            {
                if (course.id.ToLower().Contains(Query.ToLower())) distance -= 25;
                if (course.name.ToLower().Contains(Query.ToLower())) distance -= 20;
                if (course.description.ToLower().Contains(Query.ToLower())) distance -= 15;
            }

            int countLetters(string str)
            {
                int index = str.IndexOfAny(Query.Replace(" ", "").ToLower().ToCharArray());
                if (index > -1) return 0;
                return 1 + countLetters(str.Substring(index));
            }

            return distance - countLetters(course.description.ToLower());
        }
    }

    public class QuerySubject : QueryCondition<string>, IQuerySimilar
    {
        public QuerySubject(string query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            Course course = section.ParentCourse;
            return course.id.Contains(Query);
        }

        public int GetDistance(Section section)
        {
            int distance = 0;
            Course course = section.ParentCourse;

            for (int i = 0; i < 4; i++)
            {
                distance += Math.Abs(Query.ToCharArray()[i] - course.id.ToCharArray()[i]);
                // if the right letter is in there, we might be close
                distance -= course.id.Contains(Query.ToCharArray()[i]) ? 10 : 0;
                // if it's in the wrong place, maybe not
                distance += Math.Abs(course.id.IndexOf(Query.ToCharArray()[i]) - i);
            }

            return distance;
        }
    }

    // TODO
    public class QueryTimes : QueryCondition<TimeBlocks>, IQuerySimilar
    {
        public QueryTimes(TimeBlocks query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            return true;
        }

        public int GetDistance(Section section)
        {
            return 0;
        }
    }

    // TODO
    public class QueryAvailability : QueryCondition<Availability>
    {
        public QueryAvailability(Availability query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            // convert availability to enum
            Availability thisAvailability = 0;

            
        }
    }

    public class QueryPerspective : QueryCondition<List<string>>
    {
        public QueryPerspective(List<string> query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            Course course = section.ParentCourse;

            foreach (string query in Query)
            {
                if (Globals.RequirementCourses[query].Contains(course.id)) return true;
            }
            return false;
            
        }
    }

    public class QueryMajor : QueryCondition<string>
    {
        public QueryMajor(string query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            Course course = section.ParentCourse;
            return Globals.RequirementCourses[Query].Contains(course.id);
        }
    }


    public class QueryDays : QueryCondition<Days>, IQuerySimilar
    {
        public QueryDays(Days query) : base(query) { }

        public override bool IsSatisfied(Section section)
        {
            Days sectionDays = 0; // converting DateTime to our custom Days enum
            foreach (Session session in section.sessions)
            {
                Days thisDay;
                if (Days.TryParse(session.startTime.ToString(), true, out thisDay)) // if we're able to parse it
                    sectionDays |= thisDay; // add it to the list
            }

            return (Query & sectionDays) == sectionDays; // query contains section days
        }

        public int GetDistance(Section section)
        {
            int distance = 0;
            foreach (Session session in section.sessions)
            {
                Days thisDay;
                if (!Days.TryParse(session.startTime.ToString(), true, out thisDay)) continue; // if we can't parse, move to the next
                if ((Query & thisDay) != thisDay) distance++; // if our day isn't in the query, increase the distance
            }

            return distance;
        }
    }
    
    public class TimeBlocks
    {
        private List<TimeBlock> times;
        public List<TimeBlock> Times { get { return times; } }

        public int Count { get { return times.Count; } }

        public TimeBlocks() { 
            times = new List<TimeBlock>();
        }

        public void Add(TimeBlock tb)
        {
            times.Add(tb);
            Collapse();
        }

        private void Collapse()
        {
            for (int i = 1; i < times.Count; i++)
            {
                if ( times[i].start <= times[i - 1].end )
                {
                    times[i - 1].end = times[i].end;
                    times.RemoveAt(i);
                    Collapse();
                }
            }
        }

    }

    public class TimeBlock
    {
        public DateTime start;
        public DateTime end;

        public TimeBlock(DateTime start, DateTime end)
        {
            this.start = new DateTime(0001, 01, 01, start.Hour, start.Minute, 0);
            this.end = new DateTime(0001, 01, 01, end.Hour, end.Minute, 0); ;
        }
    }

    public static class SearchManager
    {
        private static SortType sorting;
        public static SortType Sorting { get { return sorting; } set { sorting = value; } }

        public static List<SearchResult> Search(List<QueryCondition> query)
        {
            List<SearchResult> results = new List<SearchResult>();

            foreach (Course course in Globals.Courses)
            {
                results.AddRange(SearchWithin(query, course));
            }

            return results;
        }

        private static List<SearchResult> SearchWithin(List<QueryCondition> query, Course course)
        {
            List<SearchResult> results = new List<SearchResult>();

            foreach (Section section in course.sections)
            {
                bool passes = false;
                bool passedAll = true;
                int relevance = 0;
                foreach (QueryCondition condition in query)
                {
                    if (condition.IsSatisfied(section)) passes = true;
                    else passedAll = false;
                    if (condition is IQuerySimilar) relevance += ((IQuerySimilar)condition).GetDistance(section);
                }

                if (passedAll) relevance = int.MinValue;
                if (passes) results.Add(new SearchResult(section, relevance));
            }

            return results;
        }
    }

    public enum SortType
    {
        AlphabetAscending,
        AlphabetDescending,
        Relevance
    }

    [Flags]
    public enum Availability
    {
        Open,
        Waitlist,
        Closed
    }

    [Flags]
    public enum Days
    {
        Monday      = 0b_0000_0001,
        Tuesday     = 0b_0000_0010,
        Wednesday   = 0b_0000_0100,
        Thursday    = 0b_0000_1000,
        Friday      = 0b_0001_0000,
        Saturday    = 0b_0010_0000,
        Sunday      = 0b_0100_0000
    }
}
