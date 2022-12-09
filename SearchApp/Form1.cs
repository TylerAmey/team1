using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SearchLib;

namespace SearchApp
{
    public partial class SearchForm : Form
    {
        private List<QueryCondition> filter;
        public SearchForm()
        {
            InitializeComponent();

            // add autocomplete strings to Major

            // Advanced should pop out advanced box
            advancedButton.Click += new EventHandler(AdvancedButton__Click);

            // time, days, perspectives, and availability should pop out their respective boxes
            timeButton.Click += new EventHandler(TimeButton__Click);
            daysButton.Click += new EventHandler(DaysButton__Click);
            perspectiveButton.Click += new EventHandler(PerspectivesButton__Click);
            availableButton.Click += new EventHandler(AvailabilityButton__Click);

            // unfocusing time/days/pers/avai should cloes the box

            // course code should open a course code dialog
            // if validated, skip to search results

            // ----------------
            // update filter on:

            // keyword entry

            // subject entry

            // number entry

            // major entry

            // time

            // days

            // perspetive

            // availability

            // reset

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

        // subjectMaskedTextBox__TextChanged
        // update filter

        // numberMaskedTextBox__TextChanged
        // update filter

        // majorTextBox__TextChanged
        // update filter

        // timeCheckBox__CheckedChanged
        // update filter

        // daysCheckBox__CheckedChanged
        // update filter
        // update text

        // perspectivesCheckBox__CheckedChanged
        // update filter

        // availabilityCheckBox__CheckedChanged
        // update filter 

        // resetButton__Click
        // update filter
        // clear everything

        // searchButton__Click
        // open ResultsForm
        private void SearchButton__Click(object sender, EventArgs e)
        {
            List<SearchResult> results = SearchManager.Search(filter);

            ResultsForm resultsForm = new ResultsForm(results);
            resultsForm.Show();
        }

        private void CompileFilter()
        {
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
                        case "subjectMaskedTextBox":
                            if (tb.Text.Length > 0)
                            {
                                filter.Add(new QuerySubject(tb.Text));
                            }
                            break;
                        case "numberMaskedTextBox":
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
            filter.Add(new QueryDays(query));
        }
    }
}
