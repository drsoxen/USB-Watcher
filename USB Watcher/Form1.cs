using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace USB_Watcher
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

        NotifyIcon m_Icon;

        public Form1()
        {
            InitializeComponent();
            this.Text = "";
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Properties.Resources.USB.Width;
            this.Height = Properties.Resources.USB.Height;
            this.BackgroundImage = Properties.Resources.USB;
            this.TopMost = true;
            this.ShowInTaskbar = false;

            m_Icon = new NotifyIcon();
            m_Icon.Icon = Properties.Resources.USB_Icon;

            MenuItem[] items = new MenuItem[2];
            items[1] = new MenuItem("Exit");
            items[1].Click += new EventHandler(Exit);
            items[0] = new MenuItem("About");
            items[0].Click += new EventHandler(About);

            m_Icon.ContextMenu = new ContextMenu(items);
            m_Icon.Visible = true;
            m_Icon.BalloonTipIcon = ToolTipIcon.Info;
            m_Icon.BalloonTipText = "USB Watcher Watching";
            m_Icon.ShowBalloonTip(2000);
            m_Icon.Text = "USB Watcher";

            SetWindowLong(this.Handle, -20, 0x80000 | 0x20);
            SetLayeredWindowAttributes(this.Handle, 0, 175, 0x2);
        }

        private void About(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void Exit(object sender, EventArgs e)
        {
            m_Icon.Visible = false;
            m_Icon.Dispose();
            m_Icon.ContextMenu = null;
            Application.Exit();
            Environment.Exit(0);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Properties.Resources.USB.Width / 2), -Properties.Resources.USB.Height);            
        }

        void MoveIn()
        {
            this.Show();
            while (this.Location.Y < 0)
            {
                this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Properties.Resources.USB.Width / 2), this.Location.Y + 1);
                Thread.Sleep(10);
            }
        }

        void MoveOut()
        {
            while (this.Location.Y > -Properties.Resources.USB.Height)
            {
                this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Properties.Resources.USB.Width / 2), this.Location.Y - 1);
                Thread.Sleep(10);
            }
            this.Hide();
        }

        private const int WM_DEVICECHANGE = 0x0219;
        private const int DBT_DEVICEARRIVAL = 0x8000; // system detected a new device
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004; // removed 
        private const int DBT_DEVTYP_VOLUME = 0x00000002; // drive type is logical volume

        protected override void WndProc(ref Message m)
        {
            int devType;
            base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE)
            {                
                switch (m.WParam.ToInt32())
                {
                    case DBT_DEVICEARRIVAL:
                        devType = Marshal.ReadInt32(m.LParam, 4);
                        if (devType == DBT_DEVTYP_VOLUME)
                            MoveIn();
                        break;

                    case DBT_DEVICEREMOVECOMPLETE:
                        devType = Marshal.ReadInt32(m.LParam, 4);
                        if (devType == DBT_DEVTYP_VOLUME)
                            MoveOut();
                        break;
                }
            }
        }
    }
}
