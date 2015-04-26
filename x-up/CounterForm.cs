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
            timer = new Timer();

            if (!log.checkConfig())
            {
                new ConfigPathForm().ShowDialog();
            }

            log.refresh();
            startTask();
        }

        public void startTask()
        {
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
            Task.Factory.StartNew(() =>this.Invoke((new MethodInvoker(() => counterLabel.Text = log.ReadLog()))));
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                stopTask();
                new SearchForm().ShowDialog();
                startTask();
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                stopTask();
                log.refresh();
                counterLabel.Text = "0";
                startTask();
            }
        }
    }
}
