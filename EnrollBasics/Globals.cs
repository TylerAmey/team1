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

        private static Course exampleCourse = new Course();

        public static void Setup()
        {
            exampleCourse.id = "COURSE_ID";
            exampleCourse.name = "COURSE_NAME";
            exampleCourse.description = "COURSE_DESCRIPTION";

            exampleCourse.requisites = new List<String>();
            exampleCourse.requisites.Add("REQUISITE_1");
            exampleCourse.requisites.Add("REQUISITE_2");

            exampleCourse.sections = new List<Section>();

            Section section1 = new Section();
            section1.courseID = "COURSE_ID";
            section1.number = 0;
            section1.professor = "SECTION1_PROFESSOR";
            section1.seats = new SeatManager();
            section1.sessions = new List<Session>();

            section1.seats.seatPosition = 1;
            section1.seats.waitListPosition = 2;
            section1.seats.capacity = 3;

            Session session1 = new Session();
            session1.location = "SECTION1_SESSION1_LOCATION";
            session1.startTime = new DateTime(2022, 1, 1, 0, 0, 0);
            session1.endTime = new DateTime(2022, 1, 1, 1, 0, 0);
            section1.sessions.Add(session1);

            Session session2 = new Session();
            session2.location = "SECTION1_SESSION2_LOCATION";
            session2.startTime = new DateTime(2022, 1, 2, 0, 0, 0);
            session2.endTime = new DateTime(2022, 1, 2, 1, 0, 0);
            section1.sessions.Add(session2);

            Session session3 = new Session();
            session3.location = "SECTION1_SESSION3_LOCATION";
            session3.startTime = new DateTime(2022, 1, 3, 0, 0, 0);
            session3.endTime = new DateTime(2022, 1, 3, 1, 0, 0);
            section1.sessions.Add(session3);

            exampleCourse.sections.Add(section1);


            Section section2 = new Section();
            section2.courseID = "COURSE_ID";
            section2.number = 0;
            section2.professor = "SECTION1_PROFESSOR";
            section2.seats = new SeatManager();
            section2.sessions = new List<Session>();
            
            section2.seats.seatPosition = 1;
            section2.seats.waitListPosition = 2;
            section2.seats.capacity = 3;

            Session session4 = new Session();
            session1.location = "SECTION1_SESSION1_LOCATION";
            session1.startTime = new DateTime(2022, 1, 4, 0, 0, 0);
            session1.endTime = new DateTime(2022, 1, 4, 1, 0, 0);
            section2.sessions.Add(session4);

            Session session5 = new Session();
            session2.location = "SECTION1_SESSION2_LOCATION";
            session2.startTime = new DateTime(2022, 1, 5, 0, 0, 0);
            session2.endTime = new DateTime(2022, 1, 5, 1, 0, 0);
            section2.sessions.Add(session5);

            Session session6 = new Session();
            session3.location = "SECTION1_SESSION3_LOCATION";
            session3.startTime = new DateTime(2022, 1, 6, 0, 0, 0);
            session3.endTime = new DateTime(2022, 1, 6, 1, 0, 0);
            section2.sessions.Add(session6);

            exampleCourse.sections.Add(section1);



        } 
    }

}
