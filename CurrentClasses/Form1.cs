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

namespace CurrentClasses
{
    public partial class CurrentClasses : Form
    {
        public CurrentClasses() 
        {
            InitializeComponent();

            //Give all class panels event handlers

            //for each class in student.currentClasses
            //create a panel under classFlowLayoutPanel

            foreach(Section section in Student.enrolledCourses)
            {
                Panel coursePanel = new Panel();
                Label className = new Label();
                className.Text = section.course.name;
                Label classCode = new Label();
                classCode.Text = section.course.id;
                Label classDays = new Label();
                foreach(Session session in Section.sessions)
                {

                }


            }
        }


        /*Functionality:
         * 
         * Read the current classes within the Student class
         * Add all classes to the classesFlowLayoutPanel
         * Take all class times from each class and add it to the calendar, as well as the names
         * A class time is shown as used when the panel turns green
         * The Class name will also be on the panel
         * 
         */
    }
}
