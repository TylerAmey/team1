using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Student.Init();

            //Create lists of each panel on the calendar
            List<Control> mondayPanels = new List<Control>();
            List<Control> tuesdayPanels = new List<Control>();
            List<Control> wednesdayPanels = new List<Control>();
            List<Control> thursdayPanels = new List<Control>();
            List<Control> fridayPanels = new List<Control>();

            //Add each panel to their individual lists
            foreach (Control control in splitContainer1.Panel2.Controls)
            {
                if((string)control.Tag == "monday")
                {
                    mondayPanels.Add(control);
                }
                if ((string)control.Tag == "tuesday")
                {
                    tuesdayPanels.Add(control);
                }
                if ((string)control.Tag == "wednesday")
                {
                    wednesdayPanels.Add(control);
                }
                if ((string)control.Tag == "thursday")
                {
                    thursdayPanels.Add(control);
                }
                if ((string)control.Tag == "friday")
                {
                    fridayPanels.Add(control);
                }
            }

            //For each course the student has enrolled in...
            foreach (Section section in Student.enrolledCourses)
            {
                //Create a panel and a splitter within it
                Panel coursePanel = new Panel();
                SplitContainer splitter = new SplitContainer();
                splitter.Orientation = Orientation.Horizontal;
                splitter.Dock = DockStyle.Fill;
                splitter.Panel1.BackColor = Color.DarkOrange;

                //Create all labels for the course
                Label className = new Label();
                className.Text = section.ParentCourse.name;
                Label classCode = new Label();
                classCode.Text = section.ParentCourse.id;
                Label daysLabel = new Label();
                Label timesLabel = new Label();
                Label locationsLabel = new Label();

                //Create lists of days and end time for each class session
                List<string> days = new List<string>();
                List<string> startTimes = new List<string>();
                List<string> endTimes = new List<string>();
                List<string> locations = new List<string>();

                //For each session within the course...
                foreach (Session session in section.sessions)
                {
                    //Get the day of the session
                    string day = session.startTime.DayOfWeek.ToString();

                    //If the day is already in the sessions list, do not add it to the list
                    bool truthDay = true;
                    foreach (string d in days)
                    {
                        if (d == day)
                        {
                            truthDay = false;
                        }
                    }
                    if (truthDay == true)
                    {
                        days.Add(day);
                    }


                    //Get the start time of the session
                    string startTimeHour = session.startTime.Hour.ToString();
                    string startTimeMin = session.startTime.Minute.ToString();
                    //Due to how DateTime is used, if it is 8:01, it would return the minutes as "1";
                    //Fix this issue
                    if (startTimeMin.Length == 1)
                    {
                        startTimeMin = "0" + startTimeMin;
                    }
                    //Create the full start time
                    string startTime = startTimeHour + ":" + startTimeMin;

                    //If the time is already in the sessions list, don't add to the list UNLESS
                    bool truthStart = true;
                    foreach (string s in startTimes)
                    {
                        //If there are MWF classes, and Wednesday has a different time then the others, then
                        //this is the signal to add the Friday time
                        if (s == startTime && startTimes.Count < 2)
                        {
                            truthStart = false;
                        }
                    }
                    if (truthStart == true)
                    {
                        startTimes.Add(startTime);
                    }


                    //Get the end time of the session
                    string endTimeHour = session.endTime.Hour.ToString();
                    string endTimeMinute = session.endTime.Minute.ToString();
                    //The same exact code as above, EXCEPT
                    if (endTimeMinute.Length == 1)
                    {
                        endTimeMinute = "0" + endTimeMinute;
                    }
                    string endTime = endTimeHour + ":" + endTimeMinute;

                    bool truthEnd = true;
                    foreach (string e in endTimes)
                    {
                        //If there are different stop times as well as same end times, do not add it
                        if (e == endTime && endTimes.Count < 2 && startTimes.Count < 2)
                        {
                            truthEnd = false;
                        }
                    }
                    if (truthEnd == true)
                    {
                        endTimes.Add(endTime);
                    }

                    //Get the location of the session
                    string location = session.location;

                    //Same code as the day code
                    bool truthLoc = true;
                    foreach (string l in locations)
                    {
                        if (l == location)
                        {
                            truthLoc = false;
                        }
                    }
                    if (truthLoc == true)
                    {
                        locations.Add(location);
                    }


                    //CALENDAR CODE


                    //Get the start and end times as numbers to interact with the calendar
                    int nStartTimeHour = session.startTime.Hour;
                    /*int nStartTimeMin = session.startTime.Minute;*/

                    int nEndTimeHour = session.endTime.Hour;
                    int nEndTimeMinute = session.endTime.Minute;
                    //Create a list of panels that have to change
                    List<Control> panelToHighlight = new List<Control>();

                    //If the day is x...
                    if (day == "Monday")
                    {
                        //Create an int to sift through the list
                        int nStart = 0;
                        //start at 8 and go until 21 due to military time
                        for (int i = 8; i < 21; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i <= dEndTime)
                            {
                                //Add it to the panels to highlight
                                panelToHighlight.Add(mondayPanels[nStart]);
                            }
                            //increment the list indicator
                            nStart++;
                        }
                    }
                    else if (day == "Tuesday")
                    {
                        //Create an int to sift through the list
                        int nStart = 0;
                        //start at 8 and go until 21 due to military time
                        for (int i = 8; i < 21; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i <= dEndTime)
                            {
                                //Add it to the panels to highlight
                                panelToHighlight.Add(tuesdayPanels[nStart]);
                            }
                            //increment the list indicator
                            nStart++;
                        }
                    }
                    else if (day == "Wednesday")
                    {
                        //Create an int to sift through the list
                        int nStart = 0;
                        //start at 8 and go until 21 due to military time
                        for (int i = 8; i < 21; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i <= dEndTime)
                            {
                                //Add it to the panels to highlight
                                panelToHighlight.Add(wednesdayPanels[nStart]);
                            }
                            //increment the list indicator
                            nStart++;
                        }
                    }
                    else if (day == "Thursday")
                    {
                        //Create an int to sift through the list
                        int nStart = 0;
                        //start at 8 and go until 21 due to military time
                        for (int i = 8; i < 21; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i <= dEndTime)
                            {
                                //Add it to the panels to highlight
                                panelToHighlight.Add(thursdayPanels[nStart]);
                            }
                            //increment the list indicator
                            nStart++;
                        }
                    }
                    else if (day == "Friday")
                    {
                        //Create an int to sift through the list
                        int nStart = 0;
                        //start at 8 and go until 21 due to military time
                        for (int i = 8; i < 21; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i <= dEndTime)
                            {
                                //Add it to the panels to highlight
                                panelToHighlight.Add(fridayPanels[nStart]);
                            }
                            //increment the list indicator
                            nStart++;
                        }
                    }

                    //for each panel that was set to be highlighted
                    foreach (Control panel in panelToHighlight)
                    {
                        //Create a label to inducate what class it is
                        Label lbl = new Label();
                        lbl.Text = section.courseID;
                        //Turn the background color of the panel lime adn add the label to it
                        panel.BackColor = Color.Lime;
                        panel.Controls.Add(lbl);
                    }
                }
                
                //For each day in the days list,
                string dayLabelString = "";
                foreach(string day in days)
                {
                    //If the day is in the list, add it to the string
                    if(day == "Monday")
                    {
                        dayLabelString += "M ";
                    }
                    else if (day == "Tuesday")
                    {
                        dayLabelString += "Tue ";
                    }
                    else if (day == "Wednesday")
                    {
                        dayLabelString += "W ";
                    }
                    else if (day == "Thursday")
                    {
                        dayLabelString += "Th ";
                    }
                    else if (day == "Friday")
                    {
                        dayLabelString += "F ";
                    }
                }
                //Add the string to the label
                daysLabel.Text = dayLabelString;


                //If there are more than 1 time in the list...
                string timeString ="";
                if(endTimes.Count > 1 || startTimes.Count > 1)
                {
                    //iterate through all of the lists
                    for(int i = 0; i < endTimes.Count; i++)
                    {
                        //Add the abbreviation of the day to the times if there are multiple,
                        //to indicate which day each time is associated to
                        string day;
                        char letter1 = days[i][0];
                        //differentiate between tuesday and thursday
                        if (days[i] == "Tuesday" || days[i] == "Tuesday")
                        {
                            char letter2 = days[i][0];
                            day = letter1.ToString() + letter2.ToString();
                        }
                        else
                        {
                            day = letter1.ToString();
                        }
                        //Add the abbreviation to the time string and a new line for each time
                        timeString += day + ": " + startTimes[i] + "-" + endTimes[i] + "\n";
                    }
                }
                //If there are no multiple times in the list, just add the one time
                else
                {
                    timeString += startTimes[0] + "-" + endTimes[0];
                }
                //Set the time label text to the string
                timesLabel.Text = timeString;

                //If there is more than 1 location...
                string locationLabelString = "";
                if(locations.Count > 1)
                {
                    //Do the same thing that was done to the time string above
                    for (int i = 0; i < locations.Count; i++)
                    {
                        string day;
                        char letter1 = days[i][0];
                        if (days[i] == "Tuesday" || days[i] == "Tuesday")
                        {
                            char letter2 = days[i][0];
                            day = letter1.ToString() + letter2.ToString();
                        }
                        else
                        {
                            day = letter1.ToString();
                        }

                        locationLabelString += day + ": " + locations[i];
                    }
                }
                //If there is just one, add the single location to the string
                else
                {
                    locationLabelString += locations[0];
                }
                //set the label text to the string
                locationsLabel.Text = locationLabelString;

                //Add the class name and code to the first splitter panel
                splitter.Panel1.Controls.Add(className);
                splitter.Panel1.Controls.Add(classCode);
                //Add the days times and location to the second splitter panel
                splitter.Panel2.Controls.Add(daysLabel);
                splitter.Panel2.Controls.Add(timesLabel);
                splitter.Panel2.Controls.Add(locationsLabel);
                coursePanel.Controls.Add(splitter);
                classesFlowLayoutPanel.Controls.Add(coursePanel); 
            }
        }     
    }
   
}
