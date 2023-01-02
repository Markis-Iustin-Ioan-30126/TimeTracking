using System;
using System.Windows.Forms;

namespace TimeTrackingClient
{
    public partial class Form1 : Form
    {
        private TimeTrackingService Service = new TimeTrackingService();
        private Employee Employee;
        public Form1(int employeeId)
        {
            InitializeComponent();
            Service.CreateConnection();
            Employee = Service.GetEmployeeById(employeeId);
            welcomeLabel.Text = "Welcome, "+Employee.Name+"!";
            DateTime today = DateTime.Now;
            dateLabel.Text = "Enter your working time interval\nfor today: " + today.Year + "-" + today.Month + "-" + today.Day;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string[] checkIn = new string[2];
            string[] checkOut = new string[2];
            try
            {
                checkIn = checkInInput.Text.Split(":");
                checkOut = checkOutInput.Text.Split(":");
                if (checkIn.Length == 3 && checkOut.Length == 3)
                {

                    TimeTrackingRecordWrapper record = new TimeTrackingRecordWrapper(Employee.Id, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        int.Parse(checkIn[0]), int.Parse(checkIn[1]), int.Parse(checkIn[2]),
                        int.Parse(checkOut[0]), int.Parse(checkOut[1]), int.Parse(checkOut[2]));
                    Boolean response = Service.AddNewTimeRecord(record);
                    if (response)
                    {
                        MessageBox.Show("Record added successfully!");
                    } else
                    {
                        MessageBox.Show("There is already a saved record for the day!");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Date and time input error: " + ex.Message);
            }
        }

        private void exitAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
