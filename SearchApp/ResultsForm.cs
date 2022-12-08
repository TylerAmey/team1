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

namespace SearchApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();

            Course course = new Course();
            course.id = "IGME201";
            course.name = "name";
            course.description = "description";
            course.credits = 4;

            Section section = new Section();
            section.number = 2;
            section.professor = "professor";
            
            Session session1 = new Session();
            session1.location = "GOL 2000";
            session1.startTime = new DateTime(2022, 1, 4, 13, 00, 0);
            session1.endTime = new DateTime(2022, 1, 4, 15, 50, 0);

            Session session2 = new Session();
            session2.location = "GOL 2000";
            session2.startTime = new DateTime(2022, 1, 3, 12, 00, 0);
            session2.endTime = new DateTime(2022, 1, 3, 12, 50, 0);

            Session session3 = new Session();
            session3.location = "GOL 2000";
            session3.startTime = new DateTime(2022, 1, 3, 8, 30, 0);
            session3.endTime = new DateTime(2022, 1, 3, 12, 30, 0);

            section.sessions = new List<Session>();
            section.sessions.Add(session1);
            section.sessions.Add(session2);
            section.sessions.Add(session3);

            SeatManager seats = new SeatManager();
            seats.seatPosition = 5;
            seats.capacity = 25;
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
