using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchApp
{
    public class CourseBox
    {
        public enum Status
        {
            OPEN,
            WAITLIST,
            CLOSED
        }

        public string subject; // e.g. "IGME"
        public int number; // e.g. 201
        public string name;
        public string description;
        public int credits;

        public string professor;
        public int sectionNumber;

        public CourseBoxSessions sessions; // each time the class meets, grouped by time

        public Status status; // i.e. open, waitlisted, or closed
        public int position = 0; // position out of capacity
        public int capacity = 0; // position out of capacity

        public Control courseBoxControl;

        // Basically generates a course display control it's kinda cute
        public CourseBox(Course course, Section section)
        {
            this.subject = course.id.Substring(0, 4); 
            this.number = Int32.Parse(course.id.Substring(4));

            this.name = course.name;
            this.description = course.description;
            this.credits = course.credits;

            this.professor = section.professor;
            this.sectionNumber = section.number;

            // add all the sessions into the special list to have their data extracted
            // special list also groups them so we can display them more succintly
            this.sessions = new CourseBoxSessions();
            foreach(Session session in section.sessions)
            {
                this.sessions.Add(new CourseBoxSession(session));
            }

            SeatManager seats = section.seats;
            if (section.seats.seatPosition > 0)  // open seats
            {
                this.position = seats.seatPosition;
                this.capacity = seats.capacity;
                this.status = Status.OPEN;
            }
            else if (seats.waitListPosition <= seats.capacity) // hasn't passed capacity
            {
                this.position = seats.waitlistPosition;
                this.capacity = seats.capacity;
                this.status = Status.WAITLIST;
            }
            else
            {
                this.status = Status.CLOSED;
            }
        }

        public void AddToPanel(ref Panel p1)
        {
            SplitContainer mainSplitContainer = new System.Windows.Forms.SplitContainer();
            Label titleLabel = new System.Windows.Forms.Label();
            Label profLabel = new System.Windows.Forms.Label();
            Label unitsLabel = new System.Windows.Forms.Label();
            GroupBox infoGroupBox = new System.Windows.Forms.GroupBox();
            Button enrollButton = new System.Windows.Forms.Button();
            ListView sessionsListView = new System.Windows.Forms.ListView();
            ColumnHeader locationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ColumnHeader dayColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ColumnHeader timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            TableLayoutPanel scheduleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            SplitContainer headerSplitContainer = new System.Windows.Forms.SplitContainer();
            RichTextBox descRichTextBox = new System.Windows.Forms.RichTextBox();
            Panel panel = new System.Windows.Forms.Panel();

            //
            // p1
            //
            p1.Controls.Add(mainSplitContainer);
            p1.Controls.Add(titleLabel);
            p1.Controls.Add(profLabel);
            p1.Controls.Add(unitsLabel);
            p1.Controls.Add(infoGroupBox);
            p1.Controls.Add(enrollButton);
            p1.Controls.Add(sessionsListView);
            p1.Controls.Add(scheduleTableLayoutPanel);
            p1.Controls.Add(headerSplitContainer);
            p1.Controls.Add(descRichTextBox);
            p1.Controls.Add(panel);

            ((System.ComponentModel.ISupportInitialize)(mainSplitContainer)).BeginInit();
            mainSplitContainer.Panel1.SuspendLayout();
            mainSplitContainer.Panel2.SuspendLayout();
            mainSplitContainer.SuspendLayout();
            infoGroupBox.SuspendLayout();


            ((System.ComponentModel.ISupportInitialize)(headerSplitContainer)).BeginInit();
            headerSplitContainer.Panel1.SuspendLayout();
            headerSplitContainer.Panel2.SuspendLayout();
            headerSplitContainer.SuspendLayout();
            panel.SuspendLayout();
            p1.SuspendLayout();


            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (CourseBoxSession session in sessions)
            {
                listViewItems.Add(new System.Windows.Forms.ListViewItem(new String[]
                {
                    session.location, session.Days, session.time
                }));
            }

            // 
            // mainSplitContainer
            // 
            mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            mainSplitContainer.Panel1.Controls.Add(descRichTextBox);
            mainSplitContainer.Panel1.Controls.Add(enrollButton);
            mainSplitContainer.Panel1.Controls.Add(infoGroupBox);
            // 
            // mainSplitContainer.Panel2
            // 
            mainSplitContainer.Panel2.Controls.Add(scheduleTableLayoutPanel);
            mainSplitContainer.Panel2.Controls.Add(sessionsListView);
            // mainSplitContainer.Size = new System.Drawing.Size(p1.Width, p1.Height);
            mainSplitContainer.SplitterDistance = p1.Width / 2;
            mainSplitContainer.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            titleLabel.Location = new System.Drawing.Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(p1.Width, 40);
            titleLabel.TabIndex = 1;
            titleLabel.Text = $"{subject} {number} - {sectionNumber} {name}"; // "XXXX ### - ## Course Title"
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // profLabel
            // 
            profLabel.AutoSize = true;
            profLabel.Dock = System.Windows.Forms.DockStyle.Left;
            profLabel.Location = new System.Drawing.Point(0, 16);
            profLabel.Name = "profLabel";
            // profLabel.Size = new System.Drawing.Size(82, 13);
            profLabel.TabIndex = 0;
            profLabel.Text = professor; // "Professor Name"
            profLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // unitsLabel
            // 
            unitsLabel.AutoSize = true;
            unitsLabel.Dock = System.Windows.Forms.DockStyle.Right;
            unitsLabel.Location = new System.Drawing.Point(p1.Width / 2, 16);
            unitsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            unitsLabel.Name = "unitsLabel";
            // unitsLabel.Size = new System.Drawing.Size(51, 13);
            unitsLabel.TabIndex = 1;
            unitsLabel.Text = $"{credits}.0 Units"; // "#.# Units"
            unitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoGroupBox
            // 
            infoGroupBox.Controls.Add(profLabel);
            infoGroupBox.Controls.Add(unitsLabel);
            infoGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            infoGroupBox.Location = new System.Drawing.Point(0, 0);
            infoGroupBox.Name = "infoGroupBox";
            // infoGroupBox.Size = new System.Drawing.Size(p1.Width / 2, 41);
            infoGroupBox.TabIndex = 2;
            infoGroupBox.TabStop = false;
            // 
            // enrollButton
            // 
            enrollButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            enrollButton.Location = new System.Drawing.Point(0, 221);
            enrollButton.Name = "enrollButton";
            // enrollButton.Size = new System.Drawing.Size(343, 34);
            enrollButton.TabIndex = 3;
            string thisText = "";
            switch(status)
            {
                case Status.OPEN:
                    thisText = "> Enroll in this section";
                    break;
                case Status.WAITLIST:
                    thisText = "> Waitlist this section";
                    break;
                case Status.CLOSED:
                    thisText = "This section is closed";
                    break;
            }
            enrollButton.Text = thisText;
            enrollButton.UseVisualStyleBackColor = true;
            // 
            // sessionsListView
            // 
            sessionsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sessionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            locationColumnHeader,
            dayColumnHeader,
            timeColumnHeader});
            sessionsListView.Dock = System.Windows.Forms.DockStyle.Top;
            sessionsListView.FullRowSelect = true;
            sessionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            sessionsListView.HideSelection = false;
            sessionsListView.Items.AddRange(listViewItems.ToArray());
            sessionsListView.Location = new System.Drawing.Point(0, 0);
            sessionsListView.Name = "sessionsListView";
            // sessionsListView.Size = new System.Drawing.Size(339, 53);
            sessionsListView.TabIndex = 0;
            sessionsListView.UseCompatibleStateImageBehavior = false;
            sessionsListView.View = System.Windows.Forms.View.Details;
            // 
            // locationColumnHeader
            // 
            locationColumnHeader.Text = "Location";
            locationColumnHeader.Width = -1;
            // 
            // dayColumnHeader
            // 
            dayColumnHeader.Text = "Day";
            dayColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dayColumnHeader.Width = -1;
            // 
            // timeColumnHeader
            // 
            timeColumnHeader.Text = "Time";
            timeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            timeColumnHeader.Width = -1;
            // 
            // scheduleTableLayoutPanel
            // 
            scheduleTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            scheduleTableLayoutPanel.ColumnCount = 6;
            scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            scheduleTableLayoutPanel.Enabled = false;
            // scheduleTableLayoutPanel.Location = new System.Drawing.Point(0, 53);
            scheduleTableLayoutPanel.Name = "scheduleTableLayoutPanel";
            scheduleTableLayoutPanel.RowCount = 6;
            scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            // scheduleTableLayoutPanel.Size = new System.Drawing.Size(339, 202);
            scheduleTableLayoutPanel.TabIndex = 1;
            // 
            // headerSplitContainer
            // 
            headerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            headerSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            headerSplitContainer.IsSplitterFixed = true;
            headerSplitContainer.Location = new System.Drawing.Point(0, 0);
            headerSplitContainer.Name = "headerSplitContainer";
            headerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // headerSplitContainer.Panel1
            // 
            headerSplitContainer.Panel1.Controls.Add(titleLabel);
            // 
            // headerSplitContainer.Panel2
            // 
            headerSplitContainer.Panel2.Controls.Add(mainSplitContainer);
            headerSplitContainer.Size = p1.Size;
            headerSplitContainer.SplitterDistance = 40;
            headerSplitContainer.TabIndex = 0;
            // 
            // descRichTextBox
            // 
            descRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            descRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            descRichTextBox.Enabled = false;
            // descRichTextBox.Location = new System.Drawing.Point(0, 41);
            descRichTextBox.Name = "descRichTextBox";
            descRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            // descRichTextBox.Size = new System.Drawing.Size(343, 180);
            descRichTextBox.TabIndex = 4;
            descRichTextBox.Text = description; // "Course description"
            descRichTextBox.Visible = false;
            // 
            // panel
            // 
            p1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            p1.Controls.Add(headerSplitContainer);
        }


    }

    // Stores indidvual class sessions, grouped by time (e.g. MWF 12:00PM-12:50PM)
    internal class CourseBoxSessions : IEnumerable
    {
        private List<CourseBoxSession> sessions;

        public CourseBoxSession this[int i]
        {
            get { return sessions[i]; }
        }

        public CourseBoxSessions()
        {
            sessions = new List<CourseBoxSession>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)sessions.GetEnumerator();
        }

        public void Add(CourseBoxSession session)
        {
            foreach (CourseBoxSession thisSession in sessions)
            {
                if (thisSession == session) // if we already have this one
                {
                    thisSession.Merge(session); // add the extra days
                    break;
                }

                sessions.Add(session); // otherwise add it to the list
            }
        }
    }

    // extracts and parses data about each class meeting
    internal class CourseBoxSession
    {
        public string location; // e.g. GOL 2000
        private List<int> days; // e.g. MWF
        public string time; // e.g. 12:00PM-12:50PM

        // converts DayOfWeek back to MTWThFS format
        private enum DayAbbreviation
        {
            M   = DayOfWeek.Monday,
            T   = DayOfWeek.Tuesday,
            W   = DayOfWeek.Wednesday,
            Th  = DayOfWeek.Thursday,
            F   = DayOfWeek.Friday,
            S   = DayOfWeek.Saturday
        }

        // this is the form that we'll want for our control display
        public string Days
        {
            get
            {
                string sDays = "";
                days.Sort();
                foreach(DayOfWeek day in days)
                {
                    sDays += ((DayAbbreviation)day).ToString();
                }

                return sDays;
            }
        }

        public CourseBoxSession(Session session)
        {
            this.location = session.location;
            this.days = session.startTime.DayOfWeek;
            this.time = "" + (((session.startTime.Hours + 11) % 12) - 11);  // 12
            this.time += ":" + (session.startTime.Minute);                  // 12:00
            this.time += session.startTime.Hours > 11 ? "PM" : "AM";        // 12:00PM

            this.time += "-";                                               // 12:00PM-

            this.time += ((session.endTime.Hours + 11) % 12) - 11;          // 12:00PM-12
            this.time += ":" + (session.endTime.Minute);                    // 12:00PM-12:50
            this.time += session.endTime.Hours > 11 ? "PM" : "AM";          // 12:00PM-12:50PM
        }

        // if two sessions are the same other than the day they meet on, we can merge them into one display
        public void Merge(CourseBoxSession session)
        {
            days.AddRange(session.days);
        }

        // can they be merged?
        public static bool operator ==(CourseBoxSession a, CourseBoxSession b)
        {
            return (a.time == b.time && a.location == b.location);
        }

        // obligatory not equals
        public static bool operator !=(CourseBoxSession a, CourseBoxSession b)
        {
            return (a.time != b.time || a.location != b.location);
        }
    }
}
