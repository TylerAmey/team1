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
            session1.startTime = new DateTime(2022, 1, 1, 8, 30, 0);
            session1.endTime = new DateTime(2022, 1, 1, 10, 30, 0);

            section.sessions = new List<Session>();
            section.sessions.Add(session1);

            SeatManager seats = new SeatManager();
            seats.seatPosition = 5;
            seats.capacity = 25;
            seats.waitListPosition = 0;

            section.seats = seats;

            CourseBox box = new CourseBox(course, section);
            box.EnrollClick += new EventHandler(DoFunny);
            box.AddToPanel(ref testPanel1);
            box.AddToPanel(ref testPanel2);
            box.AddToPanel(ref testPanel3);
            box.AddToPanel(ref testPanel4);
        }

        private void DoFunny(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
