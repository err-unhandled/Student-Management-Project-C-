using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimtToo.VisualReactive;

namespace Student_Management_development_Club_System
{
    public partial class subMenuRegistration : UserControl
    {
        public subMenuRegistration()
        {
            InitializeComponent();

            if (Program.IsInDesignMode()) return;

            Hider.Height = 25;
            Hider.Width = 224;


            VSReactive<int>.Subscribe("menu", e => tabControl1.SelectedIndex = e);
        }

        private void tab1_Click(object sender, EventArgs e)
        {
            NewStudent newStudent = new NewStudent();
            newStudent.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ManageStudent manageStudent = new ManageStudent();
            manageStudent.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ManageEnrollment manageEnrollment = new ManageEnrollment();
            manageEnrollment.ShowDialog();
        }
    }
}
