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
            this.testPanel1 = new System.Windows.Forms.Panel();
            this.testPanel2 = new System.Windows.Forms.Panel();
            this.testPanel3 = new System.Windows.Forms.Panel();
            this.testPanel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // testPanel1
            // 
            this.testPanel1.Location = new System.Drawing.Point(24, 12);
            this.testPanel1.Name = "testPanel1";
            this.testPanel1.Size = new System.Drawing.Size(284, 179);
            this.testPanel1.TabIndex = 2;
            // 
            // testPanel2
            // 
            this.testPanel2.Location = new System.Drawing.Point(25, 205);
            this.testPanel2.Name = "testPanel2";
            this.testPanel2.Size = new System.Drawing.Size(392, 182);
            this.testPanel2.TabIndex = 3;
            // 
            // testPanel3
            // 
            this.testPanel3.Location = new System.Drawing.Point(314, 12);
            this.testPanel3.Name = "testPanel3";
            this.testPanel3.Size = new System.Drawing.Size(332, 179);
            this.testPanel3.TabIndex = 4;
            // 
            // testPanel4
            // 
            this.testPanel4.Location = new System.Drawing.Point(423, 205);
            this.testPanel4.Name = "testPanel4";
            this.testPanel4.Size = new System.Drawing.Size(281, 182);
            this.testPanel4.TabIndex = 5;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testPanel4);
            this.Controls.Add(this.testPanel3);
            this.Controls.Add(this.testPanel2);
            this.Controls.Add(this.testPanel1);
            this.Name = "ResultsForm";
            this.Text = "Search Results";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel testPanel1;
        private System.Windows.Forms.Panel testPanel2;
        private System.Windows.Forms.Panel testPanel3;
        private System.Windows.Forms.Panel testPanel4;
    }
}