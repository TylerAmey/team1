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
        public Course course;
        public int relevance;

        public string Name { get { return course.name; } }

        public SearchResult(Course course, int relevance)
        {
            this.course = course;
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
        int GetDistance(Course course);
    }

    public abstract class QueryCondition { 
        public abstract bool IsSatisfied(Course course);
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

        public override bool IsSatisfied(Course course)
        {
            return course.id.Contains(Query.ToString());
        }

        public int GetDistance(Course course)
        {
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

        public override bool IsSatisfied(Course course)
        {
            return course.crn == Query;
        }

        public int GetDistance(Course course)
        {
            return Math.Abs(course.crn - Query);
        }
    }

    public class QueryKeyword : QueryCondition<string>, IQuerySimilar
    {
        public QueryKeyword(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {
            return (
                course.name.Contains(Query) ||
                course.id.Contains(Query) ||
                course.description.Contains(Query) );
        }

        public int GetDistance(Course course)
        {
            int distance = 0;

            foreach (string word in Query.Split(' '))
            {
                if (course.id.Contains(Query)) distance -= 25;
                if (course.name.Contains(Query)) distance -= 20;
                if (course.description.Contains(Query)) distance -= 15;
            }

            int countLetters(string str)
            {
                int index = str.IndexOfAny(Query.Replace(" ", "").ToCharArray());
                if (index != -1) return 0;
                return 1 + countLetters(str.Substring(index));
            }

            return distance - countLetters(course.description);
        }
    }

    public class QuerySubject : QueryCondition<string>, IQuerySimilar
    {
        public QuerySubject(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {
            return course.id.Contains(Query);
        }

        public int GetDistance(Course course)
        {
            int distance = 0;

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
    public class QueryTimes : QueryCondition<(DateTime, DateTime)>, IQuerySimilar
    {
        public QueryTimes((DateTime, DateTime) query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {
            return true;
        }

        public int GetDistance(Course course)
        {
            return 0;
        }
    }

    // TODO
    public class QueryAvailability : QueryCondition<Availability>
    {
        public QueryAvailability(Availability query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {
            return true;
        }
    }

    public class QueryPerspective : QueryCondition<string>
    {
        public QueryPerspective(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {
            return Globals.RequirementCourses[Query].Contains(course.id);
        }
    }

    public class QueryMajor : QueryCondition<string>
    {
        public QueryMajor(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {
            return Globals.RequirementCourses[Query].Contains(course.id);
        }
    }


    // TODO
    public class QueryDays : QueryCondition<Days>
    {
        public QueryDays(Days query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {
            return true;
        }
    }
    
    public class Timeblocks
    {
        private List<TimeBlock> times;
        public List<TimeBlock> Times { get { return times; } }

        public void Add(TimeBlock tb)
        {
            times.Add(tb);
            Collapse();
        }

        private void Collapse()
        {

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
                bool passes = false;
                bool passedAll = true;
                int relevance = 0;
                foreach (QueryCondition condition in query)
                {
                    if (condition.IsSatisfied(course)) passes = true;
                    else passedAll = false;
                    if (condition is IQuerySimilar) relevance += ((IQuerySimilar)condition).GetDistance(course);
                }

                if (passedAll) relevance = int.MinValue;
                if (passes) results.Add(new SearchResult(course, relevance));
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
        Monday = 0b_0000_0001,
        Tuesday = 0b_0000_0010,
        Wednesday = 0b_0000_0100,
        Thursday = 0b_0000_1000,
        Friday = 0b_0001_0000,
        Saturday = 0b_0010_0000,
        Sunday = 0b_0100_0000
    }
}
