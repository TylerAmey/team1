using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Collections.Specialized.BitVector32;

using EnrollBasics;

namespace SuggestedClasses
{
    //This form will take a list of all courses' sections and go through them, choosing 5 to display based on characteristics of the course/section.
    public partial class Form1 : Form 
    {
        List<Section> recommendedSections;
        public Form1()
        {
            InitializeComponent();
            Student.Init();
            Globals.Init();

            /*Course course = new Course();
            course.id = "IGME201";
            course.name = "Interac Des & Alg Prob Sol III";
            course.description = "This is the third course in the software development sequence for new media interactive development students. Students further their exploration of problem solving and abstraction through coverage of topics such as GUI development, events, file I/O, networking, threading, and other advanced topics related to the design and development of modern dynamic applications. Programming assignments are an integral part of the course.";
            course.credits = 3;

            Section section = new Section();
            section.number = 1;
            section.professor = "David Schuh";

            Session session1 = new Session();
            session1.location = "Online";
            session1.startTime = new DateTime(2022, 1, 3, 12, 00, 0);
            session1.endTime = new DateTime(2022, 1, 3, 12, 50, 0);

            Session session2 = new Session();
            session2.location = "Online";
            session2.startTime = new DateTime(2022, 1, 5, 12, 00, 0);
            session2.endTime = new DateTime(2022, 1, 5, 12, 50, 0);

            Session session3 = new Session();
            session3.location = "Online";
            session3.startTime = new DateTime(2022, 1, 7, 12, 00, 0);
            session3.endTime = new DateTime(2022, 1, 7, 12, 50, 0);

            section.sessions = new List<Session>();
            section.sessions.Add(session1);
            section.sessions.Add(session2);
            section.sessions.Add(session3);

            SeatManager seats = new SeatManager();
            seats.seatPosition = 12;
            seats.capacity = 30;
            seats.waitListPosition = 0;

            section.seats = seats;

            CourseBox box = new CourseBox(Course, section);
            box.EnrollClick += new EventHandler(DoFunny);
            box.AddToPanel(ref panel1);*/

            CourseBox box = new CourseBox(Globals.Courses[0], Globals.Courses[0].sections[0]);
            box.EnrollClick += new EventHandler(DoFunny);
            box.AddToPanel(ref panel1);

        }

        /*public Form1()
        {
            Section temp; //temp section variable for sorting the list of recommended sections 
            int i = 0; //iterator variable
            int j = 0; //iterator varibale

            //initialize the recommended list to contain the first sections of the first 3 existing courses
            for(i = 0; i < 3; i++)
            {
                recommendedSections[i] = Globals.Courses[i].sections[0];
            }

            //sorts the initial recommended list in descending order by their recValue
            for(i = 0; i < 3; i++)
            {
                for (j = i + 1; j < 3; j++)
                {
                    if (CalcRecValue(recommendedSections[i]) < CalcRecValue(recommendedSections[j]))
                    {
                        temp = recommendedSections[i];
                        recommendedSections[i] = recommendedSections[j];
                        recommendedSections[j] = temp;
                    }
                }
            }

        }*/

        public int CalcRecValue(Section section)
        {
            Course course = section.ParentCourse;
            int recValue = 0;

            //foreach (requirement in student's requirements)
            //if this course to that requirement's FulfillsRequirement method returns true, break loop and continue
            //after loop if not found(maybe use found boolean variable), method returns 0
            
            if (Student.year < course.yearLvl) //1-Freshman, 2-Sophomore, 3-Junior, 4-Senior
            {
                return 0;
            }

            //Preferred that this course wouldn't send student over max credits (but not required because the student could always drop classes)
            if (Student.totalCredits + course.credits <= 18)
            {
                recValue++;
            }

            //it is preferred that there are seats left
            if (section.seats.seatPosition > 0)
            {
                recValue++;
            }

            //if there are 5 or less seats available, student should enroll soon
            if (section.seats.seatPosition <= 5)
            {
                recValue++;
            }

            return recValue;
        }

        private void DoFunny(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
