﻿namespace SearchApp
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.advancedGroupBox = new System.Windows.Forms.GroupBox();
            this.numberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.subjectMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.perspectivesGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.perspectiveButton = new System.Windows.Forms.Button();
            this.availabilityGroupBox = new System.Windows.Forms.GroupBox();
            this.closedCheckBox = new System.Windows.Forms.CheckBox();
            this.waitlistButton = new System.Windows.Forms.CheckBox();
            this.availableButton = new System.Windows.Forms.Button();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.timeCheckBox7 = new System.Windows.Forms.CheckBox();
            this.timeCheckBox6 = new System.Windows.Forms.CheckBox();
            this.timeCheckBox5 = new System.Windows.Forms.CheckBox();
            this.timeCheckBox4 = new System.Windows.Forms.CheckBox();
            this.timeCheckBox3 = new System.Windows.Forms.CheckBox();
            this.timeCheckBox2 = new System.Windows.Forms.CheckBox();
            this.timeCheckBox1 = new System.Windows.Forms.CheckBox();
            this.timeButton = new System.Windows.Forms.Button();
            this.daysGroupBox = new System.Windows.Forms.GroupBox();
            this.saturdayCheckBox = new System.Windows.Forms.CheckBox();
            this.fridayCheckBox = new System.Windows.Forms.CheckBox();
            this.thursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.wednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.tuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.mondayCheckBox = new System.Windows.Forms.CheckBox();
            this.daysButton = new System.Windows.Forms.Button();
            this.majorTextBox = new System.Windows.Forms.TextBox();
            this.codeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.formLabel = new System.Windows.Forms.Label();
            this.advancedButton = new System.Windows.Forms.Button();
            this.advancedGroupBox.SuspendLayout();
            this.perspectivesGroupBox.SuspendLayout();
            this.availabilityGroupBox.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            this.daysGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(135, 132);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(389, 20);
            this.keywordTextBox.TabIndex = 0;
            this.keywordTextBox.Text = "Keyword Search";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.searchButton.Location = new System.Drawing.Point(531, 132);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // advancedGroupBox
            // 
            this.advancedGroupBox.Controls.Add(this.numberMaskedTextBox);
            this.advancedGroupBox.Controls.Add(this.subjectMaskedTextBox);
            this.advancedGroupBox.Controls.Add(this.resetButton);
            this.advancedGroupBox.Controls.Add(this.perspectivesGroupBox);
            this.advancedGroupBox.Controls.Add(this.availabilityGroupBox);
            this.advancedGroupBox.Controls.Add(this.timeGroupBox);
            this.advancedGroupBox.Controls.Add(this.daysGroupBox);
            this.advancedGroupBox.Controls.Add(this.majorTextBox);
            this.advancedGroupBox.Controls.Add(this.codeLinkLabel);
            this.advancedGroupBox.Location = new System.Drawing.Point(150, 161);
            this.advancedGroupBox.Name = "advancedGroupBox";
            this.advancedGroupBox.Size = new System.Drawing.Size(503, 277);
            this.advancedGroupBox.TabIndex = 2;
            this.advancedGroupBox.TabStop = false;
            this.advancedGroupBox.Visible = false;
            // 
            // numberMaskedTextBox
            // 
            this.numberMaskedTextBox.Location = new System.Drawing.Point(116, 19);
            this.numberMaskedTextBox.Mask = "000";
            this.numberMaskedTextBox.Name = "numberMaskedTextBox";
            this.numberMaskedTextBox.Size = new System.Drawing.Size(37, 20);
            this.numberMaskedTextBox.TabIndex = 18;
            // 
            // subjectMaskedTextBox
            // 
            this.subjectMaskedTextBox.Location = new System.Drawing.Point(67, 19);
            this.subjectMaskedTextBox.Mask = ">LLLL";
            this.subjectMaskedTextBox.Name = "subjectMaskedTextBox";
            this.subjectMaskedTextBox.Size = new System.Drawing.Size(43, 20);
            this.subjectMaskedTextBox.TabIndex = 17;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(7, 18);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(54, 23);
            this.resetButton.TabIndex = 16;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // perspectivesGroupBox
            // 
            this.perspectivesGroupBox.Controls.Add(this.checkBox7);
            this.perspectivesGroupBox.Controls.Add(this.checkBox8);
            this.perspectivesGroupBox.Controls.Add(this.checkBox9);
            this.perspectivesGroupBox.Controls.Add(this.checkBox10);
            this.perspectivesGroupBox.Controls.Add(this.checkBox11);
            this.perspectivesGroupBox.Controls.Add(this.checkBox12);
            this.perspectivesGroupBox.Controls.Add(this.perspectiveButton);
            this.perspectivesGroupBox.Location = new System.Drawing.Point(253, 46);
            this.perspectivesGroupBox.Name = "perspectivesGroupBox";
            this.perspectivesGroupBox.Size = new System.Drawing.Size(117, 23);
            this.perspectivesGroupBox.TabIndex = 15;
            this.perspectivesGroupBox.TabStop = false;
            this.perspectivesGroupBox.Text = "groupBox5";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(7, 145);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(68, 17);
            this.checkBox7.TabIndex = 14;
            this.checkBox7.Text = "Saturday";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(7, 122);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(54, 17);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.Text = "Friday";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(7, 98);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(70, 17);
            this.checkBox9.TabIndex = 12;
            this.checkBox9.Text = "Thursday";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(7, 74);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(83, 17);
            this.checkBox10.TabIndex = 11;
            this.checkBox10.Text = "Wednesday";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(7, 50);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(67, 17);
            this.checkBox11.TabIndex = 10;
            this.checkBox11.Text = "Tuesday";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(7, 26);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(64, 17);
            this.checkBox12.TabIndex = 9;
            this.checkBox12.Text = "Monday";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // perspectiveButton
            // 
            this.perspectiveButton.Location = new System.Drawing.Point(0, 0);
            this.perspectiveButton.Name = "perspectiveButton";
            this.perspectiveButton.Size = new System.Drawing.Size(117, 23);
            this.perspectiveButton.TabIndex = 8;
            this.perspectiveButton.Text = "Perspectives";
            this.perspectiveButton.UseVisualStyleBackColor = true;
            // 
            // availabilityGroupBox
            // 
            this.availabilityGroupBox.Controls.Add(this.closedCheckBox);
            this.availabilityGroupBox.Controls.Add(this.waitlistButton);
            this.availabilityGroupBox.Controls.Add(this.availableButton);
            this.availabilityGroupBox.Location = new System.Drawing.Point(376, 46);
            this.availabilityGroupBox.Name = "availabilityGroupBox";
            this.availabilityGroupBox.Size = new System.Drawing.Size(117, 23);
            this.availabilityGroupBox.TabIndex = 12;
            this.availabilityGroupBox.TabStop = false;
            this.availabilityGroupBox.Text = "groupBox4";
            // 
            // closedCheckBox
            // 
            this.closedCheckBox.AutoSize = true;
            this.closedCheckBox.Location = new System.Drawing.Point(7, 50);
            this.closedCheckBox.Name = "closedCheckBox";
            this.closedCheckBox.Size = new System.Drawing.Size(88, 17);
            this.closedCheckBox.TabIndex = 11;
            this.closedCheckBox.Text = "Show Closed";
            this.closedCheckBox.UseVisualStyleBackColor = true;
            // 
            // waitlistButton
            // 
            this.waitlistButton.AutoSize = true;
            this.waitlistButton.Location = new System.Drawing.Point(7, 26);
            this.waitlistButton.Name = "waitlistButton";
            this.waitlistButton.Size = new System.Drawing.Size(90, 17);
            this.waitlistButton.TabIndex = 10;
            this.waitlistButton.Text = "Show Waitlist";
            this.waitlistButton.UseVisualStyleBackColor = true;
            // 
            // availableButton
            // 
            this.availableButton.Location = new System.Drawing.Point(0, 0);
            this.availableButton.Name = "availableButton";
            this.availableButton.Size = new System.Drawing.Size(117, 23);
            this.availableButton.TabIndex = 9;
            this.availableButton.Text = "Availability";
            this.availableButton.UseVisualStyleBackColor = true;
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.timeCheckBox7);
            this.timeGroupBox.Controls.Add(this.timeCheckBox6);
            this.timeGroupBox.Controls.Add(this.timeCheckBox5);
            this.timeGroupBox.Controls.Add(this.timeCheckBox4);
            this.timeGroupBox.Controls.Add(this.timeCheckBox3);
            this.timeGroupBox.Controls.Add(this.timeCheckBox2);
            this.timeGroupBox.Controls.Add(this.timeCheckBox1);
            this.timeGroupBox.Controls.Add(this.timeButton);
            this.timeGroupBox.Location = new System.Drawing.Point(7, 46);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(117, 23);
            this.timeGroupBox.TabIndex = 11;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "groupBox3";
            // 
            // timeCheckBox7
            // 
            this.timeCheckBox7.AutoSize = true;
            this.timeCheckBox7.Location = new System.Drawing.Point(7, 169);
            this.timeCheckBox7.Name = "timeCheckBox7";
            this.timeCheckBox7.Size = new System.Drawing.Size(73, 17);
            this.timeCheckBox7.TabIndex = 14;
            this.timeCheckBox7.Text = "6PM-8PM";
            this.timeCheckBox7.UseVisualStyleBackColor = true;
            // 
            // timeCheckBox6
            // 
            this.timeCheckBox6.AutoSize = true;
            this.timeCheckBox6.Location = new System.Drawing.Point(7, 146);
            this.timeCheckBox6.Name = "timeCheckBox6";
            this.timeCheckBox6.Size = new System.Drawing.Size(73, 17);
            this.timeCheckBox6.TabIndex = 13;
            this.timeCheckBox6.Text = "4PM-6PM";
            this.timeCheckBox6.UseVisualStyleBackColor = true;
            // 
            // timeCheckBox5
            // 
            this.timeCheckBox5.AutoSize = true;
            this.timeCheckBox5.Location = new System.Drawing.Point(7, 122);
            this.timeCheckBox5.Name = "timeCheckBox5";
            this.timeCheckBox5.Size = new System.Drawing.Size(73, 17);
            this.timeCheckBox5.TabIndex = 12;
            this.timeCheckBox5.Text = "2PM-4PM";
            this.timeCheckBox5.UseVisualStyleBackColor = true;
            // 
            // timeCheckBox4
            // 
            this.timeCheckBox4.AutoSize = true;
            this.timeCheckBox4.Location = new System.Drawing.Point(7, 98);
            this.timeCheckBox4.Name = "timeCheckBox4";
            this.timeCheckBox4.Size = new System.Drawing.Size(79, 17);
            this.timeCheckBox4.TabIndex = 11;
            this.timeCheckBox4.Text = "12PM-2PM";
            this.timeCheckBox4.UseVisualStyleBackColor = true;
            // 
            // timeCheckBox3
            // 
            this.timeCheckBox3.AutoSize = true;
            this.timeCheckBox3.Location = new System.Drawing.Point(7, 74);
            this.timeCheckBox3.Name = "timeCheckBox3";
            this.timeCheckBox3.Size = new System.Drawing.Size(85, 17);
            this.timeCheckBox3.TabIndex = 10;
            this.timeCheckBox3.Text = "10AM-12PM";
            this.timeCheckBox3.UseVisualStyleBackColor = true;
            // 
            // timeCheckBox2
            // 
            this.timeCheckBox2.AutoSize = true;
            this.timeCheckBox2.Location = new System.Drawing.Point(7, 50);
            this.timeCheckBox2.Name = "timeCheckBox2";
            this.timeCheckBox2.Size = new System.Drawing.Size(79, 17);
            this.timeCheckBox2.TabIndex = 9;
            this.timeCheckBox2.Text = "8AM-10AM";
            this.timeCheckBox2.UseVisualStyleBackColor = true;
            // 
            // timeCheckBox1
            // 
            this.timeCheckBox1.AutoSize = true;
            this.timeCheckBox1.Location = new System.Drawing.Point(7, 26);
            this.timeCheckBox1.Name = "timeCheckBox1";
            this.timeCheckBox1.Size = new System.Drawing.Size(73, 17);
            this.timeCheckBox1.TabIndex = 8;
            this.timeCheckBox1.Text = "6AM-8AM";
            this.timeCheckBox1.UseVisualStyleBackColor = true;
            // 
            // timeButton
            // 
            this.timeButton.Location = new System.Drawing.Point(0, 0);
            this.timeButton.Name = "timeButton";
            this.timeButton.Size = new System.Drawing.Size(117, 23);
            this.timeButton.TabIndex = 7;
            this.timeButton.Text = "Time";
            this.timeButton.UseVisualStyleBackColor = true;
            // 
            // daysGroupBox
            // 
            this.daysGroupBox.Controls.Add(this.saturdayCheckBox);
            this.daysGroupBox.Controls.Add(this.fridayCheckBox);
            this.daysGroupBox.Controls.Add(this.thursdayCheckBox);
            this.daysGroupBox.Controls.Add(this.wednesdayCheckBox);
            this.daysGroupBox.Controls.Add(this.tuesdayCheckBox);
            this.daysGroupBox.Controls.Add(this.mondayCheckBox);
            this.daysGroupBox.Controls.Add(this.daysButton);
            this.daysGroupBox.Location = new System.Drawing.Point(130, 46);
            this.daysGroupBox.Name = "daysGroupBox";
            this.daysGroupBox.Size = new System.Drawing.Size(117, 23);
            this.daysGroupBox.TabIndex = 10;
            this.daysGroupBox.TabStop = false;
            this.daysGroupBox.Text = "groupBox2";
            // 
            // saturdayCheckBox
            // 
            this.saturdayCheckBox.AutoSize = true;
            this.saturdayCheckBox.Location = new System.Drawing.Point(7, 145);
            this.saturdayCheckBox.Name = "saturdayCheckBox";
            this.saturdayCheckBox.Size = new System.Drawing.Size(68, 17);
            this.saturdayCheckBox.TabIndex = 14;
            this.saturdayCheckBox.Text = "Saturday";
            this.saturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // fridayCheckBox
            // 
            this.fridayCheckBox.AutoSize = true;
            this.fridayCheckBox.Location = new System.Drawing.Point(7, 122);
            this.fridayCheckBox.Name = "fridayCheckBox";
            this.fridayCheckBox.Size = new System.Drawing.Size(54, 17);
            this.fridayCheckBox.TabIndex = 13;
            this.fridayCheckBox.Text = "Friday";
            this.fridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // thursdayCheckBox
            // 
            this.thursdayCheckBox.AutoSize = true;
            this.thursdayCheckBox.Location = new System.Drawing.Point(7, 98);
            this.thursdayCheckBox.Name = "thursdayCheckBox";
            this.thursdayCheckBox.Size = new System.Drawing.Size(70, 17);
            this.thursdayCheckBox.TabIndex = 12;
            this.thursdayCheckBox.Text = "Thursday";
            this.thursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // wednesdayCheckBox
            // 
            this.wednesdayCheckBox.AutoSize = true;
            this.wednesdayCheckBox.Location = new System.Drawing.Point(7, 74);
            this.wednesdayCheckBox.Name = "wednesdayCheckBox";
            this.wednesdayCheckBox.Size = new System.Drawing.Size(83, 17);
            this.wednesdayCheckBox.TabIndex = 11;
            this.wednesdayCheckBox.Text = "Wednesday";
            this.wednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // tuesdayCheckBox
            // 
            this.tuesdayCheckBox.AutoSize = true;
            this.tuesdayCheckBox.Location = new System.Drawing.Point(7, 50);
            this.tuesdayCheckBox.Name = "tuesdayCheckBox";
            this.tuesdayCheckBox.Size = new System.Drawing.Size(67, 17);
            this.tuesdayCheckBox.TabIndex = 10;
            this.tuesdayCheckBox.Text = "Tuesday";
            this.tuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // mondayCheckBox
            // 
            this.mondayCheckBox.AutoSize = true;
            this.mondayCheckBox.Location = new System.Drawing.Point(7, 26);
            this.mondayCheckBox.Name = "mondayCheckBox";
            this.mondayCheckBox.Size = new System.Drawing.Size(64, 17);
            this.mondayCheckBox.TabIndex = 9;
            this.mondayCheckBox.Text = "Monday";
            this.mondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // daysButton
            // 
            this.daysButton.Location = new System.Drawing.Point(0, 0);
            this.daysButton.Name = "daysButton";
            this.daysButton.Size = new System.Drawing.Size(117, 23);
            this.daysButton.TabIndex = 8;
            this.daysButton.Text = "Days";
            this.daysButton.UseVisualStyleBackColor = true;
            // 
            // majorTextBox
            // 
            this.majorTextBox.Location = new System.Drawing.Point(159, 19);
            this.majorTextBox.Name = "majorTextBox";
            this.majorTextBox.Size = new System.Drawing.Size(134, 20);
            this.majorTextBox.TabIndex = 6;
            this.majorTextBox.Text = "Major";
            // 
            // codeLinkLabel
            // 
            this.codeLinkLabel.AutoSize = true;
            this.codeLinkLabel.Location = new System.Drawing.Point(373, 26);
            this.codeLinkLabel.Name = "codeLinkLabel";
            this.codeLinkLabel.Size = new System.Drawing.Size(117, 13);
            this.codeLinkLabel.TabIndex = 2;
            this.codeLinkLabel.TabStop = true;
            this.codeLinkLabel.Text = "I know my course code";
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.Location = new System.Drawing.Point(340, 92);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(94, 13);
            this.formLabel.TabIndex = 3;
            this.formLabel.Text = "Search for classes";
            // 
            // advancedButton
            // 
            this.advancedButton.Location = new System.Drawing.Point(612, 132);
            this.advancedButton.Name = "advancedButton";
            this.advancedButton.Size = new System.Drawing.Size(75, 23);
            this.advancedButton.TabIndex = 4;
            this.advancedButton.Text = "Advanced";
            this.advancedButton.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.advancedButton);
            this.Controls.Add(this.formLabel);
            this.Controls.Add(this.advancedGroupBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.keywordTextBox);
            this.Name = "SearchForm";
            this.Text = "Search";
            this.advancedGroupBox.ResumeLayout(false);
            this.advancedGroupBox.PerformLayout();
            this.perspectivesGroupBox.ResumeLayout(false);
            this.perspectivesGroupBox.PerformLayout();
            this.availabilityGroupBox.ResumeLayout(false);
            this.availabilityGroupBox.PerformLayout();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            this.daysGroupBox.ResumeLayout(false);
            this.daysGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox advancedGroupBox;
        private System.Windows.Forms.TextBox majorTextBox;
        private System.Windows.Forms.LinkLabel codeLinkLabel;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.Button advancedButton;
        private System.Windows.Forms.Button availableButton;
        private System.Windows.Forms.Button daysButton;
        private System.Windows.Forms.Button timeButton;
        private System.Windows.Forms.GroupBox availabilityGroupBox;
        private System.Windows.Forms.CheckBox closedCheckBox;
        private System.Windows.Forms.CheckBox waitlistButton;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.CheckBox timeCheckBox6;
        private System.Windows.Forms.CheckBox timeCheckBox5;
        private System.Windows.Forms.CheckBox timeCheckBox4;
        private System.Windows.Forms.CheckBox timeCheckBox3;
        private System.Windows.Forms.CheckBox timeCheckBox2;
        private System.Windows.Forms.CheckBox timeCheckBox1;
        private System.Windows.Forms.GroupBox daysGroupBox;
        private System.Windows.Forms.CheckBox saturdayCheckBox;
        private System.Windows.Forms.CheckBox fridayCheckBox;
        private System.Windows.Forms.CheckBox thursdayCheckBox;
        private System.Windows.Forms.CheckBox wednesdayCheckBox;
        private System.Windows.Forms.CheckBox tuesdayCheckBox;
        private System.Windows.Forms.CheckBox mondayCheckBox;
        private System.Windows.Forms.GroupBox perspectivesGroupBox;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.Button perspectiveButton;
        private System.Windows.Forms.CheckBox timeCheckBox7;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.MaskedTextBox subjectMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox numberMaskedTextBox;
    }
}

