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
    public partial class ResultsForm : Form
    {
        private int pHeight = 200;

        List<SearchResult> results;

        public ResultsForm(List<SearchResult> results)
        {
            InitializeComponent();

            if (results.Count == 0)
            {
                MessageBox.Show("No Results Found");
                Close();
                return;
            }

            this.results = results;
            this.results.Sort((a, b) => a.relevance.CompareTo(b.relevance));

            LoadResults();

            ShowDialog();
        }

        private void LoadResults()
        {
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 6; i++)
            {
                if (!AddPanel()) break;
            }
        }

        private bool AddPanel()
        {
            int index = flowLayoutPanel1.Controls.Count;

            Panel panel = new Panel();
            panel.Name = "panel" + index;
            panel.Width = flowLayoutPanel1.Width - 25;
            panel.Height = pHeight;
            panel.Location = new Point(flowLayoutPanel1.Width / 2, pHeight * index);
            panel.AutoSize = false;

            if (index == results.Count) return false;

            CourseBox box = new CourseBox(results[index].section);
            box.EnrollClick += (sender, e) =>
            {
                LoadResults();
            };
            box.AddToPanel(ref panel);

            flowLayoutPanel1.Controls.Add(panel);

            return true;
        }
    }
}
