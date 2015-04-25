using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace x_up
{
    public partial class ConfigPathForm : Form
    {
        public ConfigPathForm()
        {
            InitializeComponent();
            folderpath.Text = Configuration.logDir;
        }

        private void search_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderpath.Text = folderBrowser.SelectedPath;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(folderpath.Text);
            
            if (!dirInfo.Exists)
            {
                MessageBox.Show("Folder not found!", "Folder not found!", MessageBoxButtons.OK);
            }
            else
            {
                Configuration.logDir = folderpath.Text;
                this.Close();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(0);
        }

        private void Config_Load(object sender, EventArgs e)
        {

        }

        private void Config_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(0);
        }

    }
}
