using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EnrollBasics
{
    public class CourseBox
    {
        public enum CourseType
        {
            ENROLLED,
            PROJECTED,
            VIEWING,
            ACTIVE
        }

        private Dictionary<CourseType, Brush> fills;
        private Dictionary<CourseType, Pen> strokes;
        public void setFill(CourseType key, SolidBrush fill)
        {
            fills[key] = fill;
            if (key == CourseType.PROJECTED)
                fills[key] = new HatchBrush(HatchStyle.ForwardDiagonal, fill.Color);
        }
        public void setFill(CourseType key, int fill)
        {
            Color cFill = Color.FromArgb(
                1,
                fill >> 16 & 0xFF,
                fill >> 8 & 0xFF,
                fill & 0xFF);
            setFill(key, new SolidBrush(cFill));
        }
        public void setFill(string key, SolidBrush fill)
        {
            CourseType ctKey;
            if (CourseType.TryParse(key, out ctKey)) setFill(ctKey, fill);
        }
        public void setFill(string key, int fill)
        {
            CourseType ctKey;
            if (CourseType.TryParse(key, out ctKey)) setFill(ctKey, fill);
        }
        public void setStroke(CourseType key, Pen stroke)
        {
            strokes[key] = stroke;
        }
        public void setStroke(CourseType key, int stroke)
        {
            Color cStroke = Color.FromArgb(
                1,
                stroke >> 16 & 0xFF,
                stroke >> 8 & 0xFF,
                stroke & 0xFF);
            setStroke(key, new Pen(cStroke));
        }
        public void setStroke(string key, Pen stroke)
        {
            CourseType ctKey;
            if (CourseType.TryParse(key, out ctKey)) setStroke(ctKey, stroke);
        }
        public void setStroke(string key, int stroke)
        {
            CourseType ctKey;
            if (CourseType.TryParse(key, out ctKey)) setStroke(ctKey, stroke);
        }
        public void setStyle(CourseType key, SolidBrush fill, Pen stroke)
        {
            setFill(key, fill);
            setStroke(key, stroke);
        }
        public void setStyle(CourseType key, int fill, int stroke)
        {
            setFill(key, fill);
            setStroke(key, stroke);
        }
        public void setStyle(string key, SolidBrush fill, Pen stroke)
        {
            CourseType ctKey;
            if (CourseType.TryParse(key, out ctKey))
            {
                setFill(key, fill);
                setStroke(key, stroke);
            }
        }
        public void setStyle(string key, int fill, int stroke)
        {
            CourseType ctKey;
            if (CourseType.TryParse(key, out ctKey))
            {
                setFill(key, fill);
                setStroke(key, stroke);
            }
        }

        public enum Status
        {
            ENROLLED,
            OPEN,
            WAITLIST,
            CLOSED
        }

        private Section section;

        private string subject; // e.g. "IGME"
        private int number; // e.g. 201
        private string name;
        private string description;
        private int credits;

        private string professor;
        private int sectionNumber;

        private CourseBoxSessions sessions; // each time the class meets, grouped by time

        private Status status; // i.e. open, waitlisted, or closed
        private int position = 0; // position out of capacity
        private int capacity = 0; // position out of capacity

        public EventHandler DisenrollClick;
        public EventHandler EnrollClick;
        public EventHandler WaitListClick;
        public EventHandler SaveClick;

        // Basically generates a course display control it's kinda cute
        public CourseBox(Section section)
        {
            this.fills = new Dictionary<CourseType, Brush>() {
                { CourseType.ENROLLED, Brushes.Gray },
                { CourseType.PROJECTED, Brushes.Gray },
                { CourseType.VIEWING, Brushes.DarkOrange },
                { CourseType.ACTIVE, Brushes.OrangeRed }
            };

            this.strokes = new Dictionary<CourseType, Pen>()
            {
                { CourseType.ENROLLED, Pens.Black },
                { CourseType.PROJECTED, Pens.Black },
                { CourseType.VIEWING, Pens.Black },
                { CourseType.ACTIVE, Pens.Black }
            };

            this.section = section;
            Course course = section.ParentCourse;

            this.subject = course.id.Substring(0, 4);
            this.number = Int32.Parse(course.id.Substring(4));

            this.name = course.name;
            this.description = course.description;
            this.credits = course.credits;

            this.professor = section.professor;
            this.sectionNumber = section.number;
            Status.TryParse(section.Status.ToString(), true, out status);
            if (Student.enrolledCourses.Contains(section)) status = Status.ENROLLED;

            // add all the sessions into the special list to have their data extracted
            // special list also groups them so we can display them more succintly
            this.sessions = new CourseBoxSessions();
            foreach (Session session in section.sessions)
            {
                this.sessions.Add(new CourseBoxSession(session));
            }

            SeatManager seats = section.seats;
            switch (status)
            {
                case Status.OPEN:
                    position = seats.seatPosition;
                    capacity = seats.capacity;
                    break;
                case Status.WAITLIST:
                    position = seats.waitListPosition;
                    capacity = seats.capacity;
                    break;
            }

            EnrollClick += new EventHandler(EnrollButton__Click);
            SaveClick += new EventHandler(SaveButton__Click);
            DisenrollClick += new EventHandler(DisenrollButton__Click);
        }
        
        // copy styles and delegates from existing CourseBox
        public CourseBox(Section section, CourseBox box) : this(section)
        {
            this.fills = box.fills;
            this.strokes = box.strokes;
            this.DisenrollClick = box.DisenrollClick;
            this.EnrollClick = box.EnrollClick;
            this.WaitListClick = box.WaitListClick;
            this.SaveClick = box.SaveClick;
        }

        // copy styles and section
        public CourseBox(CourseBox box) : this(box.section, box) { }

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
            Button saveButton = new System.Windows.Forms.Button();
            SplitContainer headerHorizontalSplitContainer = new System.Windows.Forms.SplitContainer();

            //
            // p1
            //

            ((System.ComponentModel.ISupportInitialize)(mainSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(headerSplitContainer)).BeginInit();
            p1.SuspendLayout();
            p1.Controls.Clear();
            p1.Tag = new CourseBox(this);


            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (CourseBoxSession session in sessions)
            {
                listViewItems.Add(new System.Windows.Forms.ListViewItem(new string[]
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
            mainSplitContainer.Size = new System.Drawing.Size(p1.Width, p1.Height);
            mainSplitContainer.SplitterDistance = p1.Width / 2;
            mainSplitContainer.IsSplitterFixed = true;
            mainSplitContainer.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            titleLabel.Name = "titleLabel";
            titleLabel.TabIndex = 1;
            titleLabel.Text = $"{subject} {number} - {sectionNumber} {name}"; // "XXXX ### - ## Course Title"
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveButton
            // 
            saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            saveButton.Name = "saveButton";
            saveButton.TabIndex = 2;
            saveButton.Text = "★";

            saveButton.ForeColor = ((SolidBrush)fills[CourseType.ENROLLED]).Color;
            if (Student.savedCourses.Contains(section)) saveButton.ForeColor = ((SolidBrush)fills[CourseType.VIEWING]).Color;

            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += new EventHandler(SaveClick);
            // 
            // headerHorizontalSplitContainer
            // 
            headerHorizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            headerHorizontalSplitContainer.Name = "headerHorizontalSplitContainer";
            headerHorizontalSplitContainer.IsSplitterFixed = true;
            // 
            // headerHorizontalSplitContainer.Panel1
            // 
            headerHorizontalSplitContainer.Panel1.Controls.Add(titleLabel);
            // 
            // headerHorizontalSplitContainer.Panel2
            // 
            headerHorizontalSplitContainer.Panel2.Controls.Add(saveButton);
            headerHorizontalSplitContainer.FixedPanel = FixedPanel.Panel2;
            headerHorizontalSplitContainer.SplitterDistance = p1.Width;
            headerHorizontalSplitContainer.TabIndex = 0;
            // 
            // profLabel
            // 
            profLabel.AutoSize = true;
            profLabel.Dock = System.Windows.Forms.DockStyle.Left;
            profLabel.Name = "profLabel";
            profLabel.TabIndex = 0;
            profLabel.Text = professor; // "Professor Name"
            profLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // unitsLabel
            // 
            unitsLabel.AutoSize = true;
            unitsLabel.Dock = System.Windows.Forms.DockStyle.Right;
            unitsLabel.Name = "unitsLabel";
            unitsLabel.TabIndex = 1;
            unitsLabel.Text = $"{credits}.0 Units"; // "#.# Units"
            unitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoGroupBox
            // 
            infoGroupBox.Controls.Add(profLabel);
            infoGroupBox.Controls.Add(unitsLabel);
            infoGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            infoGroupBox.Name = "infoGroupBox";
            infoGroupBox.Size = new System.Drawing.Size(p1.Width / 2, 40);
            infoGroupBox.TabIndex = 2;
            infoGroupBox.TabStop = false;
            // 
            // enrollButton
            // 
            enrollButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            enrollButton.Name = "enrollButton";
            enrollButton.Size = new System.Drawing.Size(p1.Width / 2, 30);
            enrollButton.TabIndex = 3;
               
            string thisText = "";
            switch (status)
            {
                case Status.ENROLLED:
                    thisText = "× Disenroll from this section";
                    enrollButton.Click += DisenrollClick;
                    break;
                case Status.OPEN:
                    thisText = "> Enroll in this section";
                    enrollButton.Click += EnrollClick;
                    break;
                case Status.WAITLIST:
                    thisText = "> Waitlist this section";
                    enrollButton.Click += WaitListClick;
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
            sessionsListView.FullRowSelect = true;
            sessionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            sessionsListView.HideSelection = false;
            sessionsListView.Scrollable = false;
            sessionsListView.Items.AddRange(listViewItems.ToArray());
            sessionsListView.Name = "sessionsListView";
            sessionsListView.TabIndex = 0;
            sessionsListView.UseCompatibleStateImageBehavior = false;
            sessionsListView.Dock = System.Windows.Forms.DockStyle.Top;
            sessionsListView.View = System.Windows.Forms.View.Details;
            // 
            // locationColumnHeader
            // 
            locationColumnHeader.Text = "Location";
            locationColumnHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            // 
            // timeColumnHeader
            // 
            timeColumnHeader.Text = "Time";
            timeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            timeColumnHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            // 
            // dayColumnHeader
            // 
            dayColumnHeader.Text = "Day";
            dayColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dayColumnHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            //
            // columns spacing
            //
            int remaining = p1.Width / 2 - locationColumnHeader.Width - dayColumnHeader.Width - timeColumnHeader.Width;
            locationColumnHeader.Width += remaining / 3;
            dayColumnHeader.Width += remaining / 3;
            timeColumnHeader.Width += remaining / 3;
            // 
            // scheduleTableLayoutPanel
            // 
            scheduleTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            scheduleTableLayoutPanel.ColumnCount = 6;
            for (int i = 0; i < scheduleTableLayoutPanel.ColumnCount; i++)
            {
                scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / scheduleTableLayoutPanel.ColumnCount));
            }
            scheduleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            scheduleTableLayoutPanel.Enabled = false;
            scheduleTableLayoutPanel.Name = "scheduleTableLayoutPanel";
            scheduleTableLayoutPanel.RowCount = 6;
            for (int i = 0; i < scheduleTableLayoutPanel.RowCount; i++)
            {
                scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F / scheduleTableLayoutPanel.RowCount));
            }
            scheduleTableLayoutPanel.TabIndex = 1;
            scheduleTableLayoutPanel.Paint += new PaintEventHandler(ScheduleTableLayoutPanel__Paint);
            scheduleTableLayoutPanel.CellPaint += new TableLayoutCellPaintEventHandler(ScheduleTableLayoutPanel__CellPaint);
            // 
            // headerSplitContainer
            // 
            headerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            headerSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            headerSplitContainer.IsSplitterFixed = true;
            headerSplitContainer.Name = "headerSplitContainer";
            headerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // headerSplitContainer.Panel1
            // 
            headerSplitContainer.Panel1.Controls.Add(headerHorizontalSplitContainer);
            // 
            // headerSplitContainer.Panel2
            // 
            headerSplitContainer.Panel2.Controls.Add(mainSplitContainer);
            headerSplitContainer.SplitterDistance = 40;
            headerSplitContainer.TabIndex = 0;
            // 
            // descRichTextBox
            // 
            descRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            descRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            descRichTextBox.Enabled = false;
            descRichTextBox.Name = "descRichTextBox";
            descRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            descRichTextBox.TabIndex = 4;
            descRichTextBox.Text = description; // "Course description"
            // 
            // panel
            // 
            p1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            p1.Controls.Add(headerSplitContainer);

            ((System.ComponentModel.ISupportInitialize)(mainSplitContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(headerSplitContainer)).EndInit();
            p1.ResumeLayout(false);
        }
        
        private void ScheduleTableLayoutPanel__Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int x = e.ClipRectangle.X;
            int width = e.ClipRectangle.Width;
            int height = e.ClipRectangle.Height;
            
            foreach (Section thisSession in Student.enrolledCourses)
            {
                DrawSchedule(thisSession, CourseType.ENROLLED);
            }
            foreach (Section thisSession in Student.projectedSchedule)
            {
                DrawSchedule(thisSession, CourseType.PROJECTED);
            }
            DrawSchedule(section, CourseType.VIEWING);

            void DrawSchedule(Section thisSection, CourseType key)
            {
                foreach (Session session in thisSection.sessions)
                {
                    DrawSession(session, key);
                }
            }

            void DrawSession(Session thisSession, CourseType key)
            {
                int thisX = x + ((int)thisSession.startTime.DayOfWeek - 1) * width / 6;

                int nStartTime = thisSession.startTime.Hour * 60 + thisSession.startTime.Minute;
                int nEndTime = thisSession.endTime.Hour * 60 + thisSession.endTime.Minute;
                int scheduleStart = 8 * 60;
                int scheduleLength = 12 * 60;

                int thisY = (nStartTime - scheduleStart) * height / scheduleLength;
                int thisWidth = width / 6 - 1;
                int thisHeight = (nEndTime - nStartTime) * height / scheduleLength;

                g.FillRectangle(
                    fills[key],
                    thisX, thisY, thisWidth, thisHeight
                    );
                g.DrawRectangle(
                    strokes[key],
                    thisX, thisY, thisWidth, thisHeight
                    );
            }
        }

        private void ScheduleTableLayoutPanel__CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle cellBounds = e.CellBounds;
            graphics.DrawRectangle(Pens.Black, cellBounds);
        }

        private void Reload(object sender, EventArgs e)
        {
            Panel FindPanel(Control c)
            {
                if (c is Form) return null;
                if (c.Tag != null && c.Tag is CourseBox) return (Panel)c;
                return FindPanel(c.Parent);
            }

            Panel p = FindPanel((Control)sender);
            if (p == null) return;

            p.SuspendLayout();
            p.Controls.Clear();

            CourseBox box = (CourseBox)(p.Tag);
            box = new CourseBox(box);
            box.AddToPanel(ref p);

            p.Tag = new CourseBox(box);

            p.ResumeLayout();
        }

        private void EnrollButton__Click(object sender, EventArgs e)
        {
            try
            {
                Student.Enroll(section);
                Reload(sender, e);
            }
            catch (EnrollException error)
            {
                MessageBox.Show(error.Message, "Enrollment Not Completed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisenrollButton__Click(object sender, EventArgs e)
        {
            Student.enrolledCourses.Remove(section);
            Reload(sender, e);
        }

        private void SaveButton__Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Student.savedCourses.Contains(section))
            {
                Student.savedCourses.Remove(section);
                button.ForeColor = ((SolidBrush)fills[CourseType.ENROLLED]).Color;
            }
            else
            {
                Student.savedCourses.Add(section);
                button.ForeColor = ((SolidBrush)fills[CourseType.VIEWING]).Color;
            }
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

        public int Count { get { return sessions.Count; } }

        public CourseBoxSessions()
        {
            sessions = new List<CourseBoxSession>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public CourseBoxSessionEnum GetEnumerator()
        {
            return new CourseBoxSessionEnum(sessions);
        }

        public void Add(CourseBoxSession session)
        {
            foreach (CourseBoxSession thisSession in sessions)
            {
                if (thisSession == session) // if we already have this one
                {
                    thisSession.Merge(session); // add the extra days
                    return;
                }

            }

            sessions.Add(session); // otherwise add it to the list
        }
    }

    // allows CourseBoxSessions to use foreach syntax
    internal class CourseBoxSessionEnum : IEnumerator
    {
        public List<CourseBoxSession> sessions;

        int position = -1;

        public CourseBoxSessionEnum(List<CourseBoxSession> sessions)
        {
            this.sessions = new List<CourseBoxSession>(sessions);
        }

        public bool MoveNext()
        {
            position++;
            return position < sessions.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public CourseBoxSession Current
        {
            get
            {
                try
                {
                    return sessions[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }

    // extracts and parses data about each class meeting
    internal class CourseBoxSession
    {
        public string location; // e.g. GOL 2000
        private List<DayOfWeek> days = new List<DayOfWeek>(); // e.g. MWF
        public string time; // e.g. 12:00PM-12:50PM

        // converts DayOfWeek back to MTWThFS format
        private enum DayAbbreviation
        {
            M = DayOfWeek.Monday,
            T = DayOfWeek.Tuesday,
            W = DayOfWeek.Wednesday,
            Th = DayOfWeek.Thursday,
            F = DayOfWeek.Friday,
            S = DayOfWeek.Saturday
        }

        // this is the form that we'll want for our control display
        public string Days
        {
            get
            {
                string sDays = "";
                days.Sort();
                foreach (DayOfWeek day in days)
                {
                    sDays += ((DayAbbreviation)day).ToString();
                }

                return sDays;
            }
        }

        public CourseBoxSession(Session session)
        {
            this.location = session.location;
            this.days.Add(session.startTime.DayOfWeek);
            this.time = "" + ((session.startTime.Hour + 11) % 12 + 1);      // 12
            this.time += ":" + (session.startTime.Minute.ToString("D2"));   // 12:00
            this.time += (session.startTime.Hour > 11 ? "PM" : "AM");         // 12:00PM

            this.time += "-";                                               // 12:00PM-

            this.time += (session.endTime.Hour + 11) % 12 + 1;              // 12:00PM-12
            this.time += ":" + (session.endTime.Minute.ToString("D2"));     // 12:00PM-12:50
            this.time += (session.endTime.Hour > 11 ? "PM" : "AM");           // 12:00PM-12:50PM
        }

        // if two sessions are the same other than the day they meet on, we can merge them into one display
        public void Merge(CourseBoxSession session)
        {
            days.AddRange(session.days);
        }

        // can they be merged?
        public static bool operator ==(CourseBoxSession a, CourseBoxSession b)
        {
            return ((a.time == b.time) && (a.location == b.location));
        }

        // obligatory not equals
        public static bool operator !=(CourseBoxSession a, CourseBoxSession b)
        {
            return ((a.time != b.time) || (a.location != b.location));
        }
    }
}
