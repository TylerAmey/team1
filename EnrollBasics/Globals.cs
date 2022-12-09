using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace EnrollBasics
{
    public static class Globals
    {
        public static List<Course> Courses;

        public static string rawCourses;

        public static Dictionary<string, List<string>> RequirementCourses = InitializeRequirements();
        public static void Init()
        {
            Courses = JsonConvert.DeserializeObject<List<Course>>(rawCourses);

            Student.name = "David Schuh";
            Student.major = "New Media Interactive Development";
            
            Student.projectedSchedule = new List<Course>();
            Student.savedCourses = new List<Course>();
            Student.enrolledCourses = new List<Section>();
            Student.completedCourses = new List<Course>()
            {

            };
            
            Student.requirements = new Dictionary<string, Requirement>();

            Student.requirements.Add("New Media Interactive Development", new MajorRequirement("New Media Interactive Development", Student.completedCourses));
            Student.requirements.Add("Social Perspective", new GeneralRequirement("Social Perspective", Student.completedCourses));

            Student.totalCredits = 0;
            Student.year = 2;
        }

        private static Dictionary<string, List<string>> InitializeRequirements()
        {
            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
            ret.Add("New Media Interactive Development", new List<string>()
            {
                
            });

            return ret;
        }
        
    }

}
