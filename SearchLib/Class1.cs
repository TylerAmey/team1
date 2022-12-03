using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLib
{
    public class SearchResult : IComparable
    {
        public Course course;
        public int relevance;

        public string Name { get { return course.Name; } }

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

    public abstract class QueryCondition { }

    public abstract class QueryCondition<T> : QueryCondition
    {
        public T Query;

        public QueryCondition(T query)
        {
            Query = query;
        }

        public abstract bool IsSatisfied(Course course);
    }

    public class QueryNumber : QueryCondition<int>, IQuerySimilar
    {
        public QueryNumber(int query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }

        public int GetDistance(Course course)
        {

        }
    }

    public class QueryCode : QueryCondition<int>, IQuerySimilar
    {
        public QueryCode(int query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }

        public int GetDistance(Course course)
        {

        }
    }

    public class QueryKeyword : QueryCondition<string>, IQuerySimilar
    {
        public QueryKeyword(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }

        public int GetDistance(Course course)
        {

        }
    }

    public class QuerySubject : QueryCondition<string>, IQuerySimilar
    {
        public QuerySubject(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }

        public int GetDistance(Course course)
        {

        }
    }

    public class QueryTimes : QueryCondition<(DateTime, DateTime)>
    {
        public QueryTimes((DateTime, DateTime) query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }
    }

    public class QueryAvailability : QueryCondition<Availability>
    {
        public QueryAvailability(Availability query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }
    }

    public class QueryPerspective : QueryCondition<string>
    {
        public QueryPerspective(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }
    }

    public class QueryMajor : QueryCondition<string>
    {
        public QueryMajor(string query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }
    }

    public class QueryDays : QueryCondition<Days>
    {
        public QueryDays(Days query) : base(query) { }

        public override bool IsSatisfied(Course course)
        {

        }
    }

    public class SearchManager
    {
        private SortType sorting;
        public SortType Sorting { get { return sorting; } set { sorting = value; } }

        public List<SearchResult> Search(List<QueryCondition> query)
        {
            
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
