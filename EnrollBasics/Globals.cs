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
        public static string rawCourses = @"[
            {""id"":""NMDE 111"",""crn"":""14135"",""name"":""New Media Digital Survey"",""description"":""This project-based course is an investigation of the computer as an illustrative, imaging, and graphical generation tool. It develops foundational design skills in raster and vector image creation, editing, compositing, layout and visual design for online production. Emphasis will be on the application of visual design organization methods and principles for electronic media. Students will create and edit images, graphics, layouts and typography to form effective design solutions for online delivery."",""requisites"":[],""sections"":[{""courseID"":""NMDE 111"",""number"":1,""professor"":""Joel Rosen"",""seats"":{""seatPosition"":16,""waitListPosition"":0,""capacity"":20},""sessions"":[{""startTime"":""2018-01-02T11:00:00"",""endTime"":""2018-01-02T13:00:00"",""location"":""BOO 1560""},{""startTime"":""2018-01-04T11:00:00"",""endTime"":""2018-01-04T12:00:00"",""location"":""BOO 1540""}]},{""courseID"":""NMDE 111"",""number"":2,""professor"":""Melissa Warp"",""seats"":{""seatPosition"":3,""waitListPosition"":0,""capacity"":20},""sessions"":[{""startTime"":""2018-01-02T15:00:00"",""endTime"":""2022-01-02T17:00:00"",""location"":""BOO 1560""},{""startTime"":""2022-01-04T15:00:00"",""endTime"":""2022-01-04T16:00:00"",""location"":""BOO 1540""}]}],""yearLvl"":1,""credits"":3},
            {""id"":""NMDE 112"",""crn"":""52139"",""name"":""New Media Digital Survey II"",""description"":""Through formal studies and perceptual understanding, including aesthetics, graphic form, structure, concept development, visual organization methods and interaction principles, students will design graphical solutions to communication problems for static and interactive projects. Students will focus on creating appropriate and usable design systems through the successful application of design theory and best practices. Assignments exploring aspects of graphic imagery, typography, usability and production for multiple digital devices and formats will be included."",""requisites"":[""NMDE 111""],""sections"":[{""courseID"":""NMDE 112"",""number"":1,""professor"":""Andy Warhol"",""seats"":{""seatPosition"":5,""waitListPosition"":0,""capacity"":20},""sessions"":[{""startTime"":""2018-01-01T09:00:00"",""endTime"":""2018-01-01T11:00:00"",""location"":""BOO 1430""},{""startTime"":""2018-01-05T09:00:00"",""endTime"":""2018-01-05T10:00:00"",""location"":""BOO 1450""}]},{""courseID"":""NMDE 112"",""number"":2,""professor"":""Melissa Warp"",""seats"":{""seatPosition"":9,""waitListPosition"":0,""capacity"":20},""sessions"":[{""startTime"":""2018-01-01T16:00:00"",""endTime"":""2022-01-01T18:00:00"",""location"":""MSS 2150""},{""startTime"":""2022-01-03T16:00:00"",""endTime"":""2022-01-03T17:00:00"",""location"":""MSS 2150""}]}],""yearLvl"":2,""credits"":3},
            {""id"":""PHIL 101"",""crn"":""50031"",""name"":""Introduction to Philosophy"",""description"":""Philosophy is about the rigorous discussion of big questions, and sometimes small precise questions, that do not have obvious answers. This class is an introduction to philosophical thinking where we learn how to think and talk critically about some of these challenging questions. Such as: Is there a single truth or is truth relative to different people and perspectives? Do we have free will and, if so, how? Do we ever really know anything? What gives life meaning? Is morality objective or subjective, discovered or created? We’ll use historical and contemporary sources to clarify questions like these, to understand the stakes, to discuss possible responses, and to arrive at a more coherent, more philosophically informed, set of answers."",""requisites"":[],""sections"":[{""courseID"":""PHIL 101"",""number"":1,""professor"":""Robert Shapiro"",""seats"":{""seatPosition"":28,""waitListPosition"":0,""capacity"":40},""sessions"":[{""startTime"":""2018-01-01T08:00:00"",""endTime"":""2018-01-01T09:00:00"",""location"":""ORN 1350""},{""startTime"":""2018-01-03T08:00:00"",""endTime"":""2018-01-03T09:00:00"",""location"":""ORN 1350""}]},{""courseID"":""PHIL 101"",""number"":2,""professor"":""John Sanders"",""seats"":{""seatPosition"":1,""waitListPosition"":0,""capacity"":40},""sessions"":[{""startTime"":""2018-01-01T13:00:00"",""endTime"":""2022-01-01T14:00:00"",""location"":""ORN 1380""},{""startTime"":""2022-01-03T13:00:00"",""endTime"":""2022-01-03T14:00:00"",""location"":""ORN 1380""}]}],""yearLvl"":1,""credits"":3},
            {""id"":""ARTH 135"",""crn"":""09274"",""name"":""Art History"",""description"":""In this course students will examine the forms, styles, functions, and meanings of important objects and monuments dating from prehistory through the Middle Ages, and consider these works of art in their social, historical and cultural contexts. "",""requisites"":[],""sections"":[{""courseID"":""ARTH 135"",""number"":1,""professor"":""Tyler Amey"",""seats"":{""seatPosition"":12,""waitListPosition"":0,""capacity"":40},""sessions"":[{""startTime"":""2018-01-01T14:00:00"",""endTime"":""2018-01-01T15:00:00"",""location"":""Online""},{""startTime"":""2018-01-03T14:00:00"",""endTime"":""2018-01-03T15:00:00"",""location"":""Online""}]}],""yearLvl"":1,""credits"":3},
            {""id"":""IGME 235"",""crn"":""38750"",""name"":""Intro to Game Web Tech"",""description"":""This course introduces web technologies commonly used in the production and distribution of both content focused web sites, and in the creation of interactive applications and games. Students will create web sites and web-native interactive experiences, and publish them to the web. Programming projects are required."",""requisites"":[""IGME 102""],""sections"":[{""courseID"":""IGME 235"",""number"":1,""professor"":""Andrew Wheeland"",""seats"":{""seatPosition"":0,""waitListPosition"":2,""capacity"":30},""sessions"":[{""startTime"":""2018-01-02T08:00:00"",""endTime"":""2018-01-02T09:00:00"",""location"":""GOL-2435""},{""startTime"":""2018-01-04T08:00:00"",""endTime"":""2018-01-04T09:00:00"",""location"":""GOL-2435""}]},{""courseID"":""IGME 235"",""number"":2,""professor"":""Andrew Wheeland"",""seats"":{""seatPosition"":2,""waitListPosition"":0,""capacity"":30},""sessions"":[{""startTime"":""2018-01-02T10:00:00"",""endTime"":""2018-01-04T11:00:00"",""location"":""GOL-2435""},{""startTime"":""2018-01-02T10:00:00"",""endTime"":""2018-01-04T11:00:00"",""location"":""GOL-2435""}]}],""yearLvl"":2,""credits"":3},
            {""id"":""IGME 102"",""crn"":""98673"",""name"":""Algorithmic Problem Solving 2"",""description"":""This course provides students a continued introduction to problem solving, abstraction, and algorithmic thinking that is relevant across the field of new media. As the second course in programming for new media students, this course continues an object-oriented approach to programming for creative practice. Topics will include re-usability, data structures, rich media types, event-driven programming, loaders, XML, object design, and inheritance. Emphasis is placed on the development of problem-solving skills as students develop moderately complex applications."",""requisites"":[],""sections"":[{""courseID"":""IGME 102"",""number"":1,""professor"":""Jeff Spain"",""seats"":{""seatPosition"":20,""waitListPosition"":0,""capacity"":30},""sessions"":[{""startTime"":""2018-01-01T17:00:00"",""endTime"":""2018-01-01T19:00:00"",""location"":""MSS-2150""},{""startTime"":""2018-01-03T17:00:00"",""endTime"":""2018-01-03T19:50:00"",""location"":""MSS-2150""}]},{""courseID"":""IGME 102"",""number"":1,""professor"":""Jeff Spain"",""seats"":{""seatPosition"":20,""waitListPosition"":0,""capacity"":30},""sessions"":[{""startTime"":""2018-01-01T13:00:00"",""endTime"":""2018-01-01T15:00:00"",""location"":""MSS-1150""},{""startTime"":""2018-01-03T13:00:00"",""endTime"":""2018-01-03T15:50:00"",""location"":""MSS-1150""}]}],""yearLvl"":1,""credits"":4}
        ]";

        public static List<Course> Courses = JsonConvert.DeserializeObject<List<Course>>(rawCourses);

        public static Dictionary<string, List<string>> RequirementCourses = InitializeRequirements();

        private static Dictionary<string, List<string>> InitializeRequirements()
        {
            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
            ret.Add("New Media Interactive Development", new List<string>()
            {
                "NMDE 111", "NMDE 112", "IGME 235", "IGME 102"
            });
            ret.Add("Artistic Perspective", new List<string>()
            {
                "ARTH 135"
            });
            ret.Add("Ethical Perspective", new List<string>()
            {
                "PHIL 101"
            });
            ret.Add("Global Perspective", new List<string>()
            {
                "ARTH 135"
            });
            ret.Add("Mathematical Perspective", new List<string>()
            {

            });
            ret.Add("Natural Science Perspective", new List<string>()
            {

            });
            ret.Add("Scientific Principles Perspective", new List<string>()
            {

            });
            ret.Add("Social Perspective", new List<string>()
            {
                "PHIL 101"
            });

            return ret;
        }
        
    }

}
