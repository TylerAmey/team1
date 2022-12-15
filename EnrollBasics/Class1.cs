using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollBasics
{
/*Class:
 * 
 * Name
 * Professor
 * id
 * description
 * requisites
 * sections available (times)
 * year level
 * 
 */


    public static class Student
    {
        public static string name;
        public static string major;
        public static List<Course> completedCourses;
        public static List<Section> projectedSchedule;
        public static List<Section> savedCourses;
        public static List<Section> enrolledCourses;
        public static Dictionary<string, Requirement> requirements;
        public static int totalCredits;
        public static int year;

        public static void Init()
        {
            name = "David Schuh";
            major = "New Media Interactive Development";
            projectedSchedule = new List<Section>();
            savedCourses = new List<Section>();
            enrolledCourses = new List<Section>()
            {
                Globals.Courses[3].sections[0],
                Globals.Courses[4].sections[0],
                Globals.Courses[5].sections[0]
            };
            completedCourses = new List<Course>()
            {

            };

            requirements = new Dictionary<string, Requirement>();
            requirements.Add("New Media Interactive Development", new MajorRequirement("New Media Interactive Development", completedCourses));
            requirements.Add("Social Perspective", new GeneralRequirement("Social Perspective", completedCourses));
            totalCredits = 0;
            year = 2;
        }

        public static void Enroll(Section section)
        {
            Course course = section.ParentCourse;
            if (totalCredits + course.credits > 18) throw new MaximumCreditsSurpassedException("Could not complete enrollment, student would exceed maximum credits allowed (18).");
            if (enrolledCourses.Any(s => s.courseID == course.id)) throw new DuplicateCoursesException($"Could not complete enrollment, you have already enrolled in a section of {course.id}.");
            if (!course.prereqsFulfilled(completedCourses))
            {
                string missedPrereqs = "";
                foreach(string prereq in course.requisites)
                {
                    if (!completedCourses.Any(c => c.id == prereq)) missedPrereqs += ", " + prereq;
                }
                missedPrereqs = missedPrereqs.Substring(2);

                throw new RequisitesNotMetException($"Could not complete enrollment, requisites have not been met (missing {missedPrereqs}).");
            }
            if (ScheduleOverlap(section)) throw new OverlappingCoursesException("Could not complete enrollment, section overlaps with an enrolled course.");

            enrolledCourses.Add(section);            
        }

        private static bool ScheduleOverlap(Section section)
        {
            foreach (Section enrolled in enrolledCourses)
            {
                if (enrolled.sessions.Any(e => section.sessions.Any(s => s.Overlap(e)))) return true;
            }
            return false;
        }
    }

    public class Course
    {
        public string id;
        public int crn;
        public string name;
        public string description;
        public List<string> requisites;
        public List<Section> sections;
        public int yearLvl;
        public int credits;

        /*public Boolean FulfillsPreReqs()
        {
            bool fulfilled = false;

            for (int i = 0; i < requisites.Count; i++)
            {
                foreach (Course pastCourse in Student.completedCourses)
                {
                    if (pastCourse.id.Equals())
                }
            }

            return fulfilled;
        }*/

        public bool prereqsFulfilled(List<Course> completed)
        {
            return !requisites.Any(req => !completed.Any(course => course.id == req));
        }
    }

    public abstract class Requirement
    {
        public string displayName;
        public bool isFullfilled;
        public List<string> ValidCourses { get
            {
                return Globals.RequirementCourses[displayName];
            } }

        public Requirement(string displayName) {
            this.displayName = displayName;
        }

        public bool FullfillsRequirement(Course course)
        {
            foreach(string course2 in ValidCourses)
            {
                if(course.id == course2)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class MajorRequirement : Requirement
    {
        public MajorRequirement(string id, List<Course> completed) : base(id)
        {
            isFullfilled = true;
            foreach (string course in ValidCourses)
            {
                if (completed.Find(c => c.id == course) == null)
                {
                    isFullfilled = false;
                    break;
                }
            }
        }
    }

    public class GeneralRequirement : Requirement
    {
        public GeneralRequirement(string id, List<Course> completed) : base(id)
        {
            isFullfilled = false;
            foreach (string course in ValidCourses)
            {
                if (completed.Find(c => c.id == course) != null)
                {
                    isFullfilled = true;
                    break;
                }
            }
        }
    }

    public class Section
    {
        public string courseID;
        public int number;
        public string professor;
        public SeatManager seats;
        public List<Session> sessions;

        public Course ParentCourse 
        { 
            get
            {
                return Globals.Courses.Find((course) => course.id == courseID);
            } 
        }

        public Status Status
        {
            get
            {
                if (seats.seatPosition > 0) return Status.OPEN;
                if (seats.waitListPosition <= seats.capacity) return Status.WAITLIST;
                return Status.CLOSED;
            }
        }

        public Days Days
        {
            get
            {
                return sessions.Aggregate(new Days(), (days, session) => days |= session.Day);
            }
        }
    }

    public class Session
    {
        public DateTime startTime;
        public DateTime endTime;
        public string location;

        public Days Day
        {
            get
            {
                Days thisDay = 0;
                Days.TryParse(startTime.DayOfWeek.ToString(), true, out thisDay);
                return thisDay;
            }
        }

        public bool Overlap(Session other)
        {
            return (other.startTime > startTime) && (other.endTime < endTime);
        }
    }

    public class SeatManager
    {
        public int seatPosition;
        public int waitListPosition;
        public int capacity;
    }

    public class EnrollException : Exception
    {
        public EnrollException() { }

        public EnrollException(string message) : base(message) { }
    }

    public class MaximumCreditsSurpassedException : EnrollException
    {
        public MaximumCreditsSurpassedException() { }
        
        public MaximumCreditsSurpassedException(string message) : base(message) { }
    }

    public class RequisitesNotMetException : EnrollException
    {
        public RequisitesNotMetException() { }

        public RequisitesNotMetException(string message) : base(message) { }
    }

    public class OverlappingCoursesException : EnrollException
    {
        public OverlappingCoursesException() { }

        public OverlappingCoursesException(string message) : base(message) { }
    }

    public class DuplicateCoursesException : EnrollException
    {
        public DuplicateCoursesException() { }

        public DuplicateCoursesException(string message) : base(message) { }
    }

    [Flags]
    public enum Status
    {
        OPEN        = 0b_0001,
        WAITLIST    = 0b_0010,
        CLOSED      = 0b_0100
    }

    [Flags]
    public enum Days
    {
        MONDAY      = 0b_0000_0001,
        TUESDAY     = 0b_0000_0010,
        WEDNESDAY   = 0b_0000_0100,
        THURSDAY    = 0b_0000_1000,
        FRIDAY      = 0b_0001_0000,
        SATURDAY    = 0b_0010_0000,
    }
}
