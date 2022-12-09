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
                Globals.Courses[3].sections[0]
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

        /* public bool prereqsFulfilled(List<Course> completed)
        {
            return !requisites.Any(req => !completed.Any(course => course.id == req));
        } */
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

        public Course ParentCourse { get
            {
                return Globals.Courses.Find((course) => course.id == courseID);
            } }
    }

    public class Session
    {
        public DateTime startTime;
        public DateTime endTime;
        public string location;
    }

    public class SeatManager
    {
        public int seatPosition;
        public int waitListPosition;
        public int capacity;
    }
}
