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
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
            cmb_Course_Name.ValueMember = "C_Id";
            Start_Course.ValueMember = "CS_Id";
        }
        private int courseId;
        private int cs_id;
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            var query = from s in db.Students select new { s.S_Id, studentName = s.S_firstName + " " + s.S_lastName };
            guna2DataGridView_course.DataSource = query;
            guna2DataGridView_course.ReadOnly = true;
            
        }
        private void Enrollment_Load(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            cmb_Course_Name.DataSource = from course in db.Courses select course;
            cmb_Course_Name.DisplayMember = "C_name";
            showTable();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_Course_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            courseId = (int)cmb_Course_Name.SelectedValue;

            var query = from cs in db.CoursesSessions where cs.C_id == courseId select cs;



            Start_Course.DisplayMember = "C_startDate";

            //dateTimePicker1.DataBindings.Add("Value", query, "C_startDate");
            //dateTimePicker2.DataBindings.Add("Value", query, "C_endDate");
            if (query.Count() == 0)
            {
                End_Course.Text = "No dates available";
                Start_Course.DataSource = null;
                End_Course.DataSource = null;

            }
            else
            {
                Start_Course.DataSource = query;
                //comboBox3.DataSource = query1;

            }
        }

        private void Start_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            //comboBox2.DataSource = from cs in db.CourseSessions select cs;
            if (Start_Course.SelectedValue != null)
            {
                cs_id = (int)Start_Course.SelectedValue;
                var query1 = from cs in db.CoursesSessions where cs.CS_Id == cs_id select cs;
                End_Course.DisplayMember = "C_endDate";
                //comboBox2.DataSource = query;
                End_Course.DataSource = query1;

            }
        }

        private void butt_En_Add_Click(object sender, EventArgs e)
        {
            if(lbl_Student_ID.Text == "")
            {
                MessageBox.Show("Please select a student.", "Add Student Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (Start_Course.Text == "")
                {
                    MessageBox.Show("There is no date for selected course.", "Add Student Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    DBClassesDataContext db = new DBClassesDataContext();
                    StudentCourse sc = new StudentCourse();
                    DateTime startDate = DateTime.Parse(Start_Course.Text);
                    DateTime endDate = DateTime.Parse(End_Course.Text);
                    var existingRecord = db.StudentCourses.FirstOrDefault(sc1 => sc1.S_id == int.Parse(lbl_Student_ID.Text) && sc1.C_id == courseId);
                    if (existingRecord == null)
                    {
                        sc.C_id = courseId;
                        sc.C_startDate = startDate;
                        sc.C_endDate = endDate;
                        sc.S_id = int.Parse(lbl_Student_ID.Text);
                        sc.CS_id = cs_id;
                        db.StudentCourses.InsertOnSubmit(sc);
                        db.SubmitChanges();
                        MessageBox.Show("Student Course info added Successfuly", "Add Student Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        butt_En_Clear.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Student already has this course.", "Add Student Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void guna2DataGridView_course_Click(object sender, EventArgs e)
        {
            lbl_Student_ID.Text =guna2DataGridView_course.CurrentRow.Cells[0].Value.ToString();
            lbl_Student_Name.Text= guna2DataGridView_course.CurrentRow.Cells[1].Value.ToString();
        }

        private void butt_En_Clear_Click(object sender, EventArgs e)
        {
            lbl_Student_ID.Text = "";
            lbl_Student_Name.Text = "";
            cmb_Course_Name.Text = "";
            Start_Course.Text = "";
            End_Course.Text = "";

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView_course_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
