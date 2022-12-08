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
            this.testPanel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // testPanel2
            // 
            this.testPanel2.Location = new System.Drawing.Point(12, 50);
            this.testPanel2.Name = "testPanel2";
            this.testPanel2.Size = new System.Drawing.Size(700, 302);
            this.testPanel2.TabIndex = 3;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testPanel2);
            this.Name = "ResultsForm";
            this.Text = "Search Results";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel testPanel2;
    }
}