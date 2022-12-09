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

        public static string rawCourses = "[{\"id\":\"NMDE 111\",\"crn\":\"14135\",\"name\":\"New Media Digital Survey\",\"description\":\"This project-based course is an investigation of the computer as an illustrative, imaging, and graphical generation tool. It develops foundational design skills in raster and vector image creation, editing, compositing, layout and visual design for online production. Emphasis will be on the application of visual design organization methods and principles for electronic media. Students will create and edit images, graphics, layouts and typography to form effective design solutions for online delivery.\",\"requisites\":[],\"sections\":[{\"courseID\":\"NMDE 111\",\"number\":1,\"professor\":\"Joel Rosen\",\"seats\":{\"seatPosition\":16,\"waitListPosition\":0,\"capacity\":20},\"sessions\":[{\"startTime\":\"2018-01-02T11:00:00\",\"endTime\":\"2018-01-02T13:00:00\",\"location\":\"BOO 1560\"},{\"startTime\":\"2018-01-04T11:00:00\",\"endTime\":\"2018-01-04T12:00:00\",\"location\":\"BOO 1540\"}]},{\"courseID\":\"NMDE 111\",\"number\":2,\"professor\":\"Melissa Warp\",\"seats\":{\"seatPosition\":3,\"waitListPosition\":0,\"capacity\":20},\"sessions\":[{\"startTime\":\"2018-01-02T15:00:00\",\"endTime\":\"2022-01-02T17:00:00\",\"location\":\"BOO 1560\"},{\"startTime\":\"2022-01-04T15:00:00\",\"endTime\":\"2022-01-04T16:00:00\",\"location\":\"BOO 1540\"}]}],\"yearLvl\":1,\"credits\":3}]";

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

            return ret;
        }
        
    }

}
