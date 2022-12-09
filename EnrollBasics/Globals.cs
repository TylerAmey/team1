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

        public static string rawCourses = "[]";

        public static Dictionary<string, List<string>> RequirementCourses = InitializeRequirements();
        public static void Init()
        {
            Courses = JsonConvert.DeserializeObject<List<Course>>(rawCourses);
        }

        private static Dictionary<string, List<string>> InitializeRequirements()
        {
            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
            ret.Add("New Media Interactive Development", new List<string>()
            {
                
            });
            ret.Add("Social Perspective", new List<string>()
            {

            });
            return ret;
        }
        
    }

}
