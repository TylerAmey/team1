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
    public partial class SearchForm : Form
    {
        private List<QueryCondition> filter;

        public SearchForm()
        {
            InitializeComponent();
            filter = new List<QueryCondition>();

            // add autocomplete strings to Major

            // Advanced should pop out advanced box
            advancedButton.Click += new EventHandler(AdvancedButton__Click);

            // time, days, perspectives, and availability should pop out their respective boxes
            timeButton.Click += new EventHandler(TimeButton__Click);
            daysButton.Click += new EventHandler(DaysButton__Click);
            perspectivesButton.Click += new EventHandler(PerspectivesButton__Click);
            availabilityButton.Click += new EventHandler(AvailabilityButton__Click);

            // unfocusing time/days/pers/avai should close the box
            timeGroupBox.Leave += new EventHandler(DropBox__Leave);
            daysGroupBox.Leave += new EventHandler(DropBox__Leave);
            perspectivesGroupBox.Leave += new EventHandler(DropBox__Leave);
            availabilityGroupBox.Leave += new EventHandler(DropBox__Leave);

            // course code should open a course code dialog
            // if validated, skip to search results

            // ----------------

            // subject entry
            subjectTextBox.CharacterCasing = CharacterCasing.Upper;
            subjectTextBox.KeyPress += new KeyPressEventHandler(SubjectTextBox__KeyPress);

            // number entry
            numberTextBox.KeyPress += new KeyPressEventHandler(NumberTextBox__KeyPress);

            // reset
            resetButton.Click += new EventHandler(ResetButton__Click);

            // ----------------
            // search button
            searchButton.Click += new EventHandler(SearchButton__Click);
        }

        // advancedButton__Click
        // big group box
        // or small
        // its a toggle
        private void AdvancedButton__Click(object sender, EventArgs e)
        {
            if (advancedGroupBox.Visible) advancedGroupBox.Visible = false;
            else advancedGroupBox.Visible = true;
        }

        // timeButton__Click
        // same deal
        private void TimeButton__Click(object sender, EventArgs e)
        {
            if (timeGroupBox.Height == 23) timeGroupBox.Height = 163;
            else timeGroupBox.Height = 23;
        }

        // daysButton__Click
        // samer deal
        private void DaysButton__Click(object sender, EventArgs e)
        {
            if (daysGroupBox.Height == 23) daysGroupBox.Height = 163;
            else daysGroupBox.Height = 23;
        }

        // perspectivesButton__Click
        // samest deal
        private void PerspectivesButton__Click(object sender, EventArgs e)
        {
            if (perspectivesGroupBox.Height == 23) perspectivesGroupBox.Height = 192;
            else perspectivesGroupBox.Height = 23;
        }

        // availabilityButton__Click
        // samester deal
        private void AvailabilityButton__Click(object sender, EventArgs e)
        {
            if (availabilityGroupBox.Height == 23) availabilityGroupBox.Height = 75;
            else availabilityGroupBox.Height = 23;
        }

        // close boxes
        private void DropBox__Leave(object sender, EventArgs e)
        {
            GroupBox groupBox = (GroupBox)sender;
            groupBox.Height = 23;
        }

        // timeGroupBox__Leave
        // close box

        // daysGroupBox__Leave
        // close box

        // perspectivesGroupBox__Leave
        // close box

        // availabilityGroupBox__Leave
        // close box

        // codeLinkLabel__Click
        // open new dialog
        // dialog__Closing
        // get code out, form will validate on its side before closing
        // if code is -1, ignore it (cancelled form)

        // keywordTextBox__TextChanged
        // update filter

        // subjectTextBox__TextChanged
        // update filter
        private void SubjectTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            TextBox tb = (TextBox)sender;
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b') e.Handled = false;
            if (tb.Text.Length == 4 && e.KeyChar != '\b') e.Handled = true;
        }

        // numberTextBox__TextChanged
        // update filter
        private void NumberTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            TextBox tb = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b') e.Handled = false;
            if (tb.Text.Length == 3 && e.KeyChar != '\b') e.Handled = true;
        }

        // TODO
        // resetButton__Click
        // clear everything
        private void ResetButton__Click(object sender, EventArgs e)
        {
            keywordTextBox.Text = "";
            subjectTextBox.Text = "";
            numberTextBox.Text = "";
            majorTextBox.Text = "";
        }

        // searchButton__Click
        // open ResultsForm
        private void SearchButton__Click(object sender, EventArgs e)
        {
            CompileFilter();
            List<SearchResult> results = SearchManager.Search(filter);

            ResultsForm resultsForm = new ResultsForm(results);
        }

        private void CompileFilter()
        {
            filter = new List<QueryCondition>();

            if (keywordTextBox.Text.Length > 0) filter.Add(new QueryKeyword(keywordTextBox.Text));

            foreach (Control control in advancedGroupBox.Controls)
            {
                if (control is GroupBox)
                {
                    GroupBox groupBox = (GroupBox)control;

                    switch (groupBox.Name)
                    {
                        case "timeGroupBox":
                            CompileTimes(groupBox);
                            break;
                        case "daysGroupBox":
                            CompileDays(groupBox);
                            break;
                        case "perspectivesGroupBox":
                            CompilePerspectives(groupBox);
                            break;
                        case "availabilityGroupBox":
                            CompileAvailability(groupBox);
                            break;
                        default:
                            return;
                    }
                }

                if (control is TextBox)
                {
                    TextBox tb = (TextBox)control;
                    switch (tb.Name)
                    {
                        case "subjectTextBox":
                            if (tb.Text.Length > 0)
                            {
                                filter.Add(new QuerySubject(tb.Text));
                            }
                            break;
                        case "numberTextBox":
                            if (tb.Text.Length > 0)
                            {
                                filter.Add(new QueryNumber(Int32.Parse(tb.Text)));
                            }
                            break;
                        case "majorTextBox":
                            if (tb.Text.Length > 0)
                            {
                                filter.Add(new QueryMajor(tb.Text));
                            }
                            break;
                        default:
                            continue;
                    }
                }
            }
        }
        
        private void CompileTimes(GroupBox groupBox)
        {
            TimeBlocks query = new TimeBlocks();

            foreach (Control control in groupBox.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    if (cb.Checked)
                    {
                        switch(cb.Name)
                        {
                            case "timeCheckBox1":
                                query.Add(new TimeBlock(
                                    new DateTime(0001, 01, 01, 8, 0, 0),
                                    new DateTime(0001, 01, 01, 10, 0, 0)));
                                break;
                            case "timeCheckBox2":
                                query.Add(new TimeBlock(
                                    new DateTime(0001, 01, 01, 10, 0, 0),
                                    new DateTime(0001, 01, 01, 12, 0, 0)));
                                break;
                            case "timeCheckBox3":
                                query.Add(new TimeBlock(
                                    new DateTime(0001, 01, 01, 12, 0, 0),
                                    new DateTime(0001, 01, 01, 14, 0, 0)));
                                break;
                            case "timeCheckBox4":
                                query.Add(new TimeBlock(
                                    new DateTime(0001, 01, 01, 14, 0, 0),
                                    new DateTime(0001, 01, 01, 16, 0, 0)));
                                break;
                            case "timeCheckBox5":
                                query.Add(new TimeBlock(
                                    new DateTime(0001, 01, 01, 16, 0, 0),
                                    new DateTime(0001, 01, 01, 18, 0, 0)));
                                break;
                            case "timeCheckBox6":
                                query.Add(new TimeBlock(
                                    new DateTime(0001, 01, 01, 18, 0, 0),
                                    new DateTime(0001, 01, 01, 20, 0, 0)));
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }
            if (query.Count > 0) filter.Add(new QueryTimes(query));
        }

        private void CompileDays(GroupBox groupBox)
        {
            Days query = 0;
            foreach (Control control in groupBox.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    if (cb.Checked)
                    {
                        Days thisQuery;
                        if (Days.TryParse(cb.Text, true, out thisQuery))
                        {
                            query |= thisQuery;
                        }
                    }
                }
            }
            if (query != 0) filter.Add(new QueryDays(query));
        }

        private void CompilePerspectives(GroupBox groupBox)
        {
            List<string> query = new List<string>();

            foreach (Control control in groupBox.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    if (cb.Checked)
                    {
                        switch(cb.Name)
                        {
                            case "artisticPerspectiveGroupBox":
                                query.Add("Artistic Perspective");
                                break;
                            case "ethicalPerspectiveGroupBox":
                                query.Add("Ethical Perspective");
                                break;
                            case "globalPerspectiveGroupBox":
                                query.Add("Global Perspective");
                                break;
                            case "mathematicalPerspectiveGroupBox":
                                query.Add("Mathematical Perspective");
                                break;
                            case "naturalSciencePerspectiveGroupBox":
                                query.Add("Natural Science Perspective");
                                break;
                            case "scientificPrinciplesPerspectiveGroupBox":
                                query.Add("Scientific Principles Perspective");
                                break;
                            case "socialPerspectiveGroupBox":
                                query.Add("Social Perspective");
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }
            if (query.Count > 0) filter.Add(new QueryPerspective(query));
        }

        private void CompileAvailability(GroupBox groupBox)
        {
            Status query = Status.OPEN;

            foreach (Control control in groupBox.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    if (cb.Checked)
                    {
                        switch (cb.Name)
                        {
                            case "waitlistCheckBox":
                                query |= Status.WAITLIST;
                                break;
                            case "closedCheckBox":
                                query |= Status.CLOSED;
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }

            if(query != Status.OPEN) filter.Add(new QueryAvailability(query));
        }
    }
}
