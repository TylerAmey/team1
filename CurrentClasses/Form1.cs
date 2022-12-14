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
                
            mondayPanels.Add(monday8AMPanel);
            mondayPanels.Add(monday9Panel);
            mondayPanels.Add(monday10Panel);
            mondayPanels.Add(monday11Panel);
            mondayPanels.Add(monday12Panel);
            mondayPanels.Add(monday1Panel);
            mondayPanels.Add(monday2Panel);
            mondayPanels.Add(monday3Panel);
            mondayPanels.Add(monday4Panel);
            mondayPanels.Add(monday5Panel);
            mondayPanels.Add(monday6Panel);
            mondayPanels.Add(monday7Panel);

            tuesdayPanels.Add(tuesday8AMPanel);
            tuesdayPanels.Add(tuesday9Panel);
            tuesdayPanels.Add(tuesday10Panel);
            tuesdayPanels.Add(tuesday11Panel);
            tuesdayPanels.Add(tuesday12Panel);
            tuesdayPanels.Add(tuesday1Panel);
            tuesdayPanels.Add(tuesday2Panel);
            tuesdayPanels.Add(tuesday3Panel);
            tuesdayPanels.Add(tuesday4Panel);
            tuesdayPanels.Add(tuesday5Panel);
            tuesdayPanels.Add(tuesday6Panel);
            tuesdayPanels.Add(tuesday7Panel);

            wednesdayPanels.Add(wednesday8AMPanel);
            wednesdayPanels.Add(wednesday9Panel);
            wednesdayPanels.Add(wednesday10Panel);
            wednesdayPanels.Add(wednesday11Panel);
            wednesdayPanels.Add(wednesday12Panel);
            wednesdayPanels.Add(wednesday1Panel);
            wednesdayPanels.Add(wednesday2Panel);
            wednesdayPanels.Add(wednesday3Panel);
            wednesdayPanels.Add(wednesday4Panel);
            wednesdayPanels.Add(wednesday5Panel);
            wednesdayPanels.Add(wednesday6Panel);
            wednesdayPanels.Add(wednesday7Panel);

            thursdayPanels.Add(thursday8AMPanel);
            thursdayPanels.Add(thursday9Panel);
            thursdayPanels.Add(thursday10Panel);
            thursdayPanels.Add(thursday11Panel);
            thursdayPanels.Add(thursday12Panel);
            thursdayPanels.Add(thursday1Panel);
            thursdayPanels.Add(thursday2Panel);
            thursdayPanels.Add(thursday3Panel);
            thursdayPanels.Add(thursday4Panel);
            thursdayPanels.Add(thursday5Panel);
            thursdayPanels.Add(thursday6Panel);
            thursdayPanels.Add(thursday7Panel);

            fridayPanels.Add(friday8AMPanel);
            fridayPanels.Add(friday9Panel);
            fridayPanels.Add(friday10Panel);
            fridayPanels.Add(friday11Panel);
            fridayPanels.Add(friday12Panel);
            fridayPanels.Add(friday1Panel);
            fridayPanels.Add(friday2Panel);
            fridayPanels.Add(friday3Panel);
            fridayPanels.Add(friday4Panel);
            fridayPanels.Add(friday5Panel);
            fridayPanels.Add(friday6Panel);
            fridayPanels.Add(friday7Panel);

            //Stylize the panels
            foreach(Control control in mondayPanels)
            {
                control.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Bold);
                control.BackColor = Color.White;
            }

            foreach (Control control in tuesdayPanels)
            {
                control.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Bold);
                control.BackColor = Color.White;
            }

            foreach (Control control in wednesdayPanels)
            {
                control.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Bold);
                control.BackColor = Color.White;
            }

            foreach (Control control in thursdayPanels)
            {
                control.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Bold);
                control.BackColor = Color.White;
            }

            foreach (Control control in fridayPanels)
            {
                control.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Bold);
                control.BackColor = Color.White;
            }

            //For each course the student has enrolled in...
            foreach (Section section in Student.enrolledCourses)
            {
                //Create a panel and a splitter within it
                Panel coursePanel = new Panel();
                coursePanel.AutoSize = true;
                coursePanel.Padding = new Padding(0, 0, 0, 0);
                SplitContainer splitter = new SplitContainer();
                splitter.Orientation = Orientation.Horizontal;
                splitter.Dock = DockStyle.None;
                splitter.IsSplitterFixed = true;
                splitter.Panel1.BackColor = Color.DarkOrange;
                splitter.Panel2.BackColor = Color.White;
                splitter.BorderStyle = BorderStyle.Fixed3D;
                splitter.Size = new Size(105, 175);

                //Create all labels for the course
                Label className = new Label();
                className.Text = section.ParentCourse.name;
                className.AutoSize = false;
                className.TextAlign = ContentAlignment.MiddleCenter;
                className.Dock = DockStyle.None;

                Label classCode = new Label();
                classCode.Text = section.ParentCourse.id;
                classCode.AutoSize = false;
                classCode.TextAlign = ContentAlignment.MiddleCenter;
                classCode.Dock = DockStyle.None;

                Label daysLabel = new Label();
                daysLabel.AutoSize = false;
                daysLabel.TextAlign = ContentAlignment.MiddleCenter;
                daysLabel.Dock = DockStyle.None;

                Label timesLabel = new Label();
                timesLabel.AutoSize = false;
                timesLabel.TextAlign = ContentAlignment.MiddleCenter;
                timesLabel.Dock = DockStyle.None;
                bool multipleTimes = false;

                Label locationsLabel = new Label();
                locationsLabel.AutoSize = false;
                locationsLabel.TextAlign = ContentAlignment.MiddleCenter;
                locationsLabel.Dock = DockStyle.None;

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
                    bool pmStartIndicator = false;
                    string startTimeHour = "";
                    //To transition from military time to standard
                    if (session.startTime.Hour < 13)
                    {
                        startTimeHour = session.startTime.Hour.ToString();
                    }
                    else
                    {
                        for(int i = 1; i < 13; i++)
                        {
                            if(i + 12 == session.startTime.Hour)
                            {
                                startTimeHour = i.ToString();
                            }
                        }
                        pmStartIndicator = true;
                    }
                    string startTimeMin = session.startTime.Minute.ToString();
                    //Due to how DateTime is used, if it is 8:01, it would return the minutes as "1";
                    //Fix this issue
                    if (startTimeMin.Length == 1)
                    {
                        startTimeMin = "0" + startTimeMin;
                    }
                    //To add either PM or AM to the times
                    string startTime = "";
                    if (pmStartIndicator == false)
                    {
                        startTime = startTimeHour + ":" + startTimeMin + " A.M";
                    }
                    else
                    {
                        startTime = startTimeHour + ":" + startTimeMin + " P.M";
                    }

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
                    bool pmEndIndicator = false;
                    //To transition from military time to standard
                    string endTimeHour = "";
                    if (session.startTime.Hour < 13)
                    {
                        endTimeHour = session.endTime.Hour.ToString();
                    }
                    else
                    {
                        for (int i = 1; i < 13; i++)
                        {
                            if (i + 12 == session.endTime.Hour)
                            {
                                endTimeHour = i.ToString();
                            }
                        }
                        pmEndIndicator = true;
                    }
                    string endTimeMinute = session.endTime.Minute.ToString();
                    //The same exact code as above, EXCEPT
                    if (endTimeMinute.Length == 1)
                    {
                        endTimeMinute = "0" + endTimeMinute;
                    }
                    //To add either PM or AM to the times
                    string endTime = "";
                    if (pmEndIndicator == false)
                    {
                        endTime = endTimeHour + ":" + endTimeMinute + " AM";
                    }
                    else
                    {
                        endTime = endTimeHour + ":" + endTimeMinute + " PM";
                    }

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
                        for (int i = 8; i < 20; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i < dEndTime)
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
                        for (int i = 8; i < 20; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i < dEndTime)
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
                        for (int i = 8; i < 20; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i < dEndTime)
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
                        for (int i = 8; i < 20; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i < dEndTime)
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
                        for (int i = 8; i < 20; i++)
                        {
                            //Create a double so we can compare the true end time
                            double dEndTime = nEndTimeHour + (.1 * nEndTimeMinute);
                            //If i is greater than or equal to the start time and
                            //Less than or equal to end time + 1 (to account for minutes)
                            if (i >= nStartTimeHour && i < dEndTime)
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
                        lbl.AutoSize = false;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Dock = DockStyle.Fill;
                        //Turn the background color of the panel lime adn add the label to it
                        panel.BackColor = Color.DarkOrange;
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
                    //Set the multiple times boolean to true for later in the code
                    multipleTimes = true;
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
                        //If there are an even amounts of starts and end times in the lists
                        try
                        {
                            timeString += day + ": " + startTimes[i] + "-" + endTimes[i] + "\n";
                        }
                        //If not...
                        catch
                        {
                            //Acount for variations (examples would be labs)
                            //This only happens for 2 day classes with variations. 3 day classes with
                            //variations are accounted in lines 145-196
                            try
                            {
                                timeString += day + ": " + startTimes[0] + "-" + endTimes[i] + "\n";
                            }
                            catch
                            {
                                timeString += day + ": " + startTimes[i] + "-" + endTimes[0] + "\n";
                            }
                        }
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

                //Set the text color to transparent
                className.BackColor = Color.Transparent;
                classCode.BackColor = Color.Transparent;
                daysLabel.BackColor = Color.Transparent;
                timesLabel.BackColor = Color.Transparent;
                locationsLabel.BackColor = Color.Transparent;

                //If there are multiple times, uncenter the text
                if(multipleTimes == true)
                {
                    timesLabel.AutoSize = true;
                }

                //Change the fonts
                className.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Regular);
                classCode.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Regular);
                daysLabel.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Regular);
                timesLabel.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Regular);
                locationsLabel.Font = new Font(new FontFamily("Arial"), 8, style: FontStyle.Regular);

                //Add the controls to the splitter
                className.Location = new Point(className.Location.X, className.Location.Y + 15);
                splitter.Panel1.Controls.Add(className);
                classCode.Location = new Point(className.Location.X, className.Location.Y + 25);
                splitter.Panel1.Controls.Add(classCode);

                splitter.Panel2.Controls.Add(daysLabel);
                timesLabel.Location = new Point(daysLabel.Location.X, daysLabel.Location.Y + 25);
                splitter.Panel2.Controls.Add(timesLabel);
                locationsLabel.Location = new Point(timesLabel.Location.X, timesLabel.Location.Y + 30);
                splitter.Panel2.Controls.Add(locationsLabel);
                //Add the splitter to the panel
                coursePanel.Controls.Add(splitter);
                classesFlowLayoutPanel.Controls.Add(coursePanel); 
            }
        }
    }
   
}
