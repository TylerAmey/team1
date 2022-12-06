using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchApp
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();

            // add autocomplete strings to Major

            // Advanced should pop out advanced box

            // time, days, perspectives, and availability should pop out their respective boxes
            
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
        }

        // advancedButton__Click
        // big group box
        // or small
        // its a toggle

        // timeButton__Click
        // same deal

        // daysButton__Click
        // samer deal

        // perspectivesButton__Click
        // samest deal

        // availabilityButton__Click
        // samester deal

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

        // perspectivesCheckBox__CheckedChanged
        // update filter

        // availabilityCheckBox__CheckedChanged
        // update filter 

        // resetButton__Click
        // update filter
        // clear everything
    }
}
