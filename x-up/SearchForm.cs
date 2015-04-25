using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace x_up
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            search.Text = Configuration.searchString;
            interval.Text = Configuration.interval.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int newInterval = 0;

            if (! Int32.TryParse(interval.Text.ToString(), out newInterval))
            {
                MessageBox.Show("Not a valid interval. Only numbers.", "Invalid interval", MessageBoxButtons.OK);
            }
            else
            {
                Configuration.searchString = search.Text;
                Configuration.interval = newInterval;
                this.Close();
            }
        }
    }
}
