using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            foreach(Course course in Student.enrolledCourses)
            {
                Panel coursePanel = new Panel();
                Label className = course.
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
