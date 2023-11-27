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
    public partial class subMenuControl : UserControl
    {
        public subMenuControl()
        {
            InitializeComponent();

            if (Program.IsInDesignMode()) return;

            Hider.Height = 25;
            Hider.Width = 229;

            VSReactive<int>.Subscribe("menu", e => tabControl1.SelectedIndex = e);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            NewCourse newCourse = new NewCourse();
            newCourse.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ManageCourse manageCourse = new ManageCourse();
            manageCourse.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Session session = new Session();
            session.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ManageSession manageSession = new ManageSession();  
            manageSession.ShowDialog();
        }

        private void tab1_Click(object sender, EventArgs e)
        {
            Marks marks = new Marks();
            marks.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Manage_Marks marks = new Manage_Marks();
            marks.ShowDialog();
        }
    }
}
