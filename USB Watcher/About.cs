using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USB_Watcher
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;

            StringBuilder sb = new StringBuilder();
            sb.Append("USB Watcher\n");
            sb.Append("Version 1.0\n");
            sb.Append("Copyright © 2012 by Drsoxen\n");
            sb.Append("All Rights Reserved\n");

            label_MainText.Text = sb.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Shown(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width/2) - (this.Width/2), (Screen.PrimaryScreen.Bounds.Height/2) - (this.Height/2));
            this.button_OK.Location = new System.Drawing.Point((this.Width / 2) - (this.button_OK.Width / 2) - 5, 110);
        }
    }
}
