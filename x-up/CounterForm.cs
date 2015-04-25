using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace x_up
{
    public partial class CounterForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private Logs log;

        private Timer timer;

        public CounterForm()
        {
            InitializeComponent();

            log = new Logs();

            if (!log.checkConfig())
            {
                new ConfigPathForm().ShowDialog();
            }

            log.refresh();
            startTask();
        }

        public void startTask()
        {
            timer = new Timer();
            timer.Interval = Configuration.interval;
            timer.Tick += new EventHandler(updateCounter);
            timer.Start();
        }

        public void stopTask()
        {
            timer.Stop();
        }

        private void updateCounter(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>this.Invoke((new MethodInvoker(() => label1.Text = log.ReadLog()))));
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                stopTask();
                log.refresh();
                label1.Text = "0";
                startTask();
            }
        }


        private void label1_MouseDoubleClick(object sender, EventArgs e)
        {
                stopTask();
                new SearchForm().ShowDialog();
                startTask();
        }

        private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
