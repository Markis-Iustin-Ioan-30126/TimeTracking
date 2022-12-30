using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimeTrackingClient
{
    public partial class TimeTrackingAuth : Form
    {
        public TimeTrackingAuth()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            Form1 timeTrackingClient = new Form1(10);
            timeTrackingClient.Show();
            this.Hide();
        }
    }
}
