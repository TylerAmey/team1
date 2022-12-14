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
        List<Section> recommendedSections = new List<Section>();

        public Form1()
        {
            InitializeComponent();
            Student.Init();
            

            int i = 0; //iterator variable

            //initialize the recommended list to contain the first sections of the first 3 existing courses
            for(i = 0; i < 3; i++)
            {
                recommendedSections.Add(Globals.Courses[i].sections[0]);
            }

            //Sorts the initial recommended list in descending order by their recValue
            SortList();

            //Goes through the rest of existing classes. If recValue is greater than the recValue of the last course in recommendedSections, replace it & sort list
            foreach(Course course in Globals.Courses)
            {
                foreach(Section section in course.sections)
                {
                    if (CalcRecValue(section) > CalcRecValue(recommendedSections[2]) && !IsInList(section))
                    {
                        recommendedSections[2] = section;
                        SortList();
                    }
                }
            }

            CourseBox box = new CourseBox(recommendedSections[0]);
            box.AddToPanel(ref panel1);

            box = new CourseBox(recommendedSections[1]);
            box.AddToPanel(ref panel2);

            box = new CourseBox(recommendedSections[2]);
            box.AddToPanel(ref panel3);
        }

        public Boolean IsInList(Section section)
        {
            foreach(Section recSection in recommendedSections)
            {
                if(recSection == section)
                {
                    return true;
                }
            }

            return false;
        }

        public void SortList()
        {
            Section temp; //temp section variable for sorting the list of recommended sections 
            int i = 0; //iterator variable
            int j = 0; //iterator varibale

            //sorts the recommended list in descending order by their recValue
            for (i = 0; i < 3; i++)
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
        }

        public int CalcRecValue(Section section)
        {
            Course course = section.ParentCourse;
            int recValue = 0;
            bool found = false;

            //foreach (requirement in student's requirements)
            //if this course to that requirement's FulfillsRequirement method returns true, break loop and continue
            //after loop if not found method returns 0
            foreach (KeyValuePair<string, Requirement> requirement in Student.requirements)
            {
                if (requirement.Value.FullfillsRequirement(section.ParentCourse))
                {
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                return 0;
            }
            
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

            //It is preferred that the sessions of the section fit into the current schedule

            return recValue;
        }
    }
}
