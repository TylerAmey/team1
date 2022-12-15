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
    public partial class CodeForm : Form
    {
        public int enteredCode;
        public CodeForm()
        {
            InitializeComponent();

            // submit button
            submitButton.Click += new EventHandler(SubmitButton__Click);

            // validate code
            codeTextBox.KeyPress += new KeyPressEventHandler(CodeTextBox__KeyPress);

            // back button
            backButton.Click += new EventHandler(BackButton__Click);
        }

        // submitButton__Click
        // check course code
        // message box or whatever on invalid
        // close otherwise and send to out field
        private void SubmitButton__Click(object sender, EventArgs e)
        {
            enteredCode = Int32.Parse(codeTextBox.Text);
            Close();
        }

        // backButton__Click
        // set out to -1
        // close
        private void BackButton__Click(object sender, EventArgs e)
        {
            enteredCode = -1;
            Close();
        }

        // CodeTextBox__KeyPress
        // 5 digits
        private void CodeTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar) && codeTextBox.Text.Length < 5) e.Handled = false;
            if (e.KeyChar == '\b') e.Handled = false;
        }
    }
}
