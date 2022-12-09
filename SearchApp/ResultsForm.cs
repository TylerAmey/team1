using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EnrollBasics;
using SearchLib;

namespace SearchApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(List<SearchResult> results)
        {
            InitializeComponent();
            Student.Init();

            Course course = new Course();
            course.id = "IGME201";
            course.name = "Interac Des & Alg Prob Sol III";
            course.description = "This is the third course in the software development sequence for new media interactive development students. Students further their exploration of problem solving and abstraction through coverage of topics such as GUI development, events, file I/O, networking, threading, and other advanced topics related to the design and development of modern dynamic applications. Programming assignments are an integral part of the course.";
            course.credits = 3;

            Section section = new Section();
            section.number = 1;
            section.professor = "David Schuh";
            
            Session session1 = new Session();
            session1.location = "GOL-2000";
            session1.startTime = new DateTime(2022, 1, 4, 17, 00, 0);
            session1.endTime = new DateTime(2022, 1, 4, 19, 0, 0);

            Session session2 = new Session();
            session2.location = "GOL-3000";
            session2.startTime = new DateTime(2022, 1, 6, 17, 00, 0);
            session2.endTime = new DateTime(2022, 1, 6, 20, 0, 0);

            Session session3 = new Session();
            session3.location = "Online";
            session3.startTime = new DateTime(2022, 1, 7, 12, 00, 0);
            session3.endTime = new DateTime(2022, 1, 7, 12, 50, 0);

            section.sessions = new List<Session>();
            section.sessions.Add(session1);
            section.sessions.Add(session2);
            // section.sessions.Add(session3);

            SeatManager seats = new SeatManager();
            seats.seatPosition = 12;
            seats.capacity = 30;
            seats.waitListPosition = 0;

            section.seats = seats;

            CourseBox box = new CourseBox(course, section);
            box.EnrollClick += new EventHandler(DoFunny);
            box.AddToPanel(ref testPanel2);
        }

        private void DoFunny(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
