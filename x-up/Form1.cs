using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace x_up
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private Logs log;

        public Form1()
        {
            InitializeComponent();

            log = new Logs();
            log.refresh();
            Timer MyTimer = new Timer();
            MyTimer.Interval = 1000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>this.Invoke((new MethodInvoker(() => label1.Text = log.ReadLog()))));
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
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
                log.refresh();
                label1.Text = "0"; 
            }
        }
    }
}
