using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_development_Club_System
{
    public partial class AdminLogIn : Form
    {
        public AdminLogIn()
        {
            InitializeComponent();
        }

        private void AdminLogIn_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            string username = guna2TextBox1_userName.Text;
            string password = guna2TextBox2_password.Text;
            var admin = db.Employees.SingleOrDefault(user => user.E_userName == username && user.E_password == password && user.E_role == "Admin");

            if (admin != null)
            {
                MessageBox.Show("Admin logged in!");
                AccountsUserscs au = new AccountsUserscs();
                au.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password for admin.","Invaild username or passsword", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
