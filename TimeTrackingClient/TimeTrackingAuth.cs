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
        private AuthenticationService Service = new AuthenticationService();
        public TimeTrackingAuth()
        {
            InitializeComponent();
            Service.CreateConnection();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            AuthenticationWrapper wrapper = new AuthenticationWrapper(nameInput.Text, passwordInput.Text);
            try
            {
                var authResult = Service.Authentication(wrapper);
                if (authResult > 0)
                {
                    Form1 timeTrackingClient = new Form1(authResult);
                    timeTrackingClient.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("We could not find a user with the coresponding password! Try again!");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Authentication error: " + ex.Message);
            }
            
        }
    }
}
