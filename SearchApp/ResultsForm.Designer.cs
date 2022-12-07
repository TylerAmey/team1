namespace SearchApp
{
    partial class ResultsForm
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "XXX ####",
            "",
            ""}, -1);
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.descRichTextBox = new System.Windows.Forms.RichTextBox();
            this.enrollButton = new System.Windows.Forms.Button();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.profLabel = new System.Windows.Forms.Label();
            this.unitsLabel = new System.Windows.Forms.Label();
            this.scheduleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sessionsListView = new System.Windows.Forms.ListView();
            this.locationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dayColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleLabel = new System.Windows.Forms.Label();
            this.headerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.infoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerSplitContainer)).BeginInit();
            this.headerSplitContainer.Panel1.SuspendLayout();
            this.headerSplitContainer.Panel2.SuspendLayout();
            this.headerSplitContainer.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.IsSplitterFixed = true;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.descRichTextBox);
            this.mainSplitContainer.Panel1.Controls.Add(this.enrollButton);
            this.mainSplitContainer.Panel1.Controls.Add(this.infoGroupBox);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.scheduleTableLayoutPanel);
            this.mainSplitContainer.Panel2.Controls.Add(this.sessionsListView);
            this.mainSplitContainer.Size = new System.Drawing.Size(686, 255);
            this.mainSplitContainer.SplitterDistance = 343;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // descRichTextBox
            // 
            this.descRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descRichTextBox.Enabled = false;
            this.descRichTextBox.Location = new System.Drawing.Point(0, 41);
            this.descRichTextBox.Name = "descRichTextBox";
            this.descRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.descRichTextBox.Size = new System.Drawing.Size(343, 180);
            this.descRichTextBox.TabIndex = 4;
            this.descRichTextBox.Text = "Course description";
            this.descRichTextBox.Visible = false;
            // 
            // enrollButton
            // 
            this.enrollButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.enrollButton.Location = new System.Drawing.Point(0, 221);
            this.enrollButton.Name = "enrollButton";
            this.enrollButton.Size = new System.Drawing.Size(343, 34);
            this.enrollButton.TabIndex = 3;
            this.enrollButton.Text = "> Enroll in this section";
            this.enrollButton.UseVisualStyleBackColor = true;
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.profLabel);
            this.infoGroupBox.Controls.Add(this.unitsLabel);
            this.infoGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoGroupBox.Location = new System.Drawing.Point(0, 0);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(343, 41);
            this.infoGroupBox.TabIndex = 2;
            this.infoGroupBox.TabStop = false;
            // 
            // profLabel
            // 
            this.profLabel.AutoSize = true;
            this.profLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.profLabel.Location = new System.Drawing.Point(3, 16);
            this.profLabel.Name = "profLabel";
            this.profLabel.Size = new System.Drawing.Size(82, 13);
            this.profLabel.TabIndex = 0;
            this.profLabel.Text = "Professor Name";
            this.profLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // unitsLabel
            // 
            this.unitsLabel.AutoSize = true;
            this.unitsLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.unitsLabel.Location = new System.Drawing.Point(289, 16);
            this.unitsLabel.Name = "unitsLabel";
            this.unitsLabel.Size = new System.Drawing.Size(51, 13);
            this.unitsLabel.TabIndex = 1;
            this.unitsLabel.Text = "#.# Units";
            this.unitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scheduleTableLayoutPanel
            // 
            this.scheduleTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.scheduleTableLayoutPanel.ColumnCount = 6;
            this.scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleTableLayoutPanel.Enabled = false;
            this.scheduleTableLayoutPanel.Location = new System.Drawing.Point(0, 53);
            this.scheduleTableLayoutPanel.Name = "scheduleTableLayoutPanel";
            this.scheduleTableLayoutPanel.RowCount = 6;
            this.scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.scheduleTableLayoutPanel.Size = new System.Drawing.Size(339, 202);
            this.scheduleTableLayoutPanel.TabIndex = 1;
            // 
            // sessionsListView
            // 
            this.sessionsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sessionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.locationColumnHeader,
            this.dayColumnHeader,
            this.timeColumnHeader});
            this.sessionsListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.sessionsListView.FullRowSelect = true;
            this.sessionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.sessionsListView.HideSelection = false;
            this.sessionsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.sessionsListView.Location = new System.Drawing.Point(0, 0);
            this.sessionsListView.Name = "sessionsListView";
            this.sessionsListView.Size = new System.Drawing.Size(339, 53);
            this.sessionsListView.TabIndex = 0;
            this.sessionsListView.UseCompatibleStateImageBehavior = false;
            this.sessionsListView.View = System.Windows.Forms.View.Details;
            // 
            // locationColumnHeader
            // 
            this.locationColumnHeader.Text = "Location";
            this.locationColumnHeader.Width = 62;
            // 
            // dayColumnHeader
            // 
            this.dayColumnHeader.Text = "Day";
            this.dayColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dayColumnHeader.Width = 65;
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timeColumnHeader.Width = 109;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(686, 41);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "XXXX ### - ## Course Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerSplitContainer
            // 
            this.headerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.headerSplitContainer.IsSplitterFixed = true;
            this.headerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.headerSplitContainer.Name = "headerSplitContainer";
            this.headerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // headerSplitContainer.Panel1
            // 
            this.headerSplitContainer.Panel1.Controls.Add(this.titleLabel);
            // 
            // headerSplitContainer.Panel2
            // 
            this.headerSplitContainer.Panel2.Controls.Add(this.mainSplitContainer);
            this.headerSplitContainer.Size = new System.Drawing.Size(686, 300);
            this.headerSplitContainer.SplitterDistance = 41;
            this.headerSplitContainer.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.headerSplitContainer);
            this.panel.Location = new System.Drawing.Point(61, 62);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(688, 302);
            this.panel.TabIndex = 1;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Name = "ResultsForm";
            this.Text = "Search Results";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.infoGroupBox.ResumeLayout(false);
            this.infoGroupBox.PerformLayout();
            this.headerSplitContainer.Panel1.ResumeLayout(false);
            this.headerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerSplitContainer)).EndInit();
            this.headerSplitContainer.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Label unitsLabel;
        private System.Windows.Forms.Label profLabel;
        private System.Windows.Forms.Button enrollButton;
        private System.Windows.Forms.GroupBox infoGroupBox;
        private System.Windows.Forms.TableLayoutPanel scheduleTableLayoutPanel;
        private System.Windows.Forms.ListView sessionsListView;
        private System.Windows.Forms.ColumnHeader locationColumnHeader;
        private System.Windows.Forms.ColumnHeader dayColumnHeader;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.SplitContainer headerSplitContainer;
        private System.Windows.Forms.RichTextBox descRichTextBox;
        private System.Windows.Forms.Panel panel;
    }
}