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
    public partial class AccountsUserscs : Form
    {
        public AccountsUserscs()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            var query = from emp in db.Employees select new { emp.E_Id, EmployeeName = emp.E_firstName + " " + emp.E_lastName, emp.E_userName, emp.E_password };
            guna2DataGridView1_users.DataSource = query;
            guna2DataGridView1_users.ReadOnly = true;

        }
        private void AccountsUserscs_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void butt_Ac_Search_Click(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            string searchName = txb_Search.Text.Trim();
            var searchResult = from emp in db.Employees where emp.E_firstName.Contains(searchName) || emp.E_lastName.Contains(searchName) select new { emp.E_Id, EmployeeName = emp.E_firstName + " " + emp.E_lastName, emp.E_userName, emp.E_password };
            guna2DataGridView1_users.DataSource = searchResult.ToList();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txb_Search_TextChanged(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            string searchName = txb_Search.Text.Trim();
            var searchResult = from emp in db.Employees where emp.E_firstName.Contains(searchName) || emp.E_lastName.Contains(searchName) select new { emp.E_Id, EmployeeName = emp.E_firstName + " " + emp.E_lastName, emp.E_userName, emp.E_password };
            guna2DataGridView1_users.DataSource = searchResult.ToList();
        }
    }
}
