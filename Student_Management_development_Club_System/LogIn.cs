using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Student_Management_development_Club_System.Properties;

namespace Student_Management_development_Club_System
{
    public partial class LogIn : Form
    {

        public LogIn()
        {
            InitializeComponent();


        }


        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }
        public static void Login(string username, string password)
        {
            DBClassesDataContext db = new DBClassesDataContext();

            var employee = db.Employees
                .Where(e => e.E_userName == username && e.E_password == password)
                .FirstOrDefault();

            if (employee != null)
            {
                string role = employee.E_role;

                switch (role)
                {

                    case "Controller":
                        ControlFrom controlFrom = new ControlFrom();
                        controlFrom.ShowDialog();
                        break;
                    case "Admin":
                        AdminForm adminForm = new AdminForm();
                        adminForm.ShowDialog();
                        break;
                    case "Registration":
                        RegistrationForm registrationForm = new RegistrationForm();
                        registrationForm.ShowDialog();
                        break;
                       
                    default:
                        MessageBox.Show("Unknown Role");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Invaild username or passsword", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

            private void LogIn_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1logIn_Click(object sender, EventArgs e)
        {
            string user = guna2TextBox1_userName.Text;
            string pass = guna2TextBox2_password.Text;
            Login(user, pass);
        }

        private void butt_LogIn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


