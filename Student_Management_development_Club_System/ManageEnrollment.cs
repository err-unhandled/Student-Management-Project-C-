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
    public partial class ManageEnrollment : Form
    {
        public ManageEnrollment()
        {

            InitializeComponent();
            cmb_Course_Name.ValueMember = "C_Id";
            Start_Course.ValueMember = "CS_Id";
        }
        private int courseId;
        private int csid;
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            var query = from sc in db.StudentCourses join c in db.Courses on sc.C_id equals c.C_Id join s in db.Students on sc.S_id equals s.S_Id select new { sc.SC_Id, StudentName = s.S_firstName + " " + s.S_lastName, c.C_name, sc.C_startDate, sc.C_endDate,sc.S_id ,sc.CS_id };
            guna2DataGridView_course.DataSource = query;
            guna2DataGridView_course.Columns["S_id"].Visible = false;
            guna2DataGridView_course.ReadOnly = true;
            




        }


        private void ManageEnrollment_Load(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            cmb_Course_Name.DataSource = from course in db.Courses select course;
            cmb_Course_Name.DisplayMember = "C_name";
            lbl_Student_ID.Visible = false; 
            label1.Visible = false;
            label8.Visible = false;
            label9_id.Visible = false;
            showTable();
        }

        private void guna2DataGridView_course_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void butt_En_Update_Click(object sender, EventArgs e)
        {
            if(lbl_Student_ID.Text =="")
            {
                MessageBox.Show("Please select a record for updating", "Update Student Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    StudentCourse sc = db.StudentCourses.SingleOrDefault(sc1 => sc1.SC_Id == int.Parse(label9_id.Text));
                    DateTime startDate = DateTime.Parse(Start_Course.Text);
                    DateTime endDate = DateTime.Parse(End_Course.Text);
                    sc.C_id = courseId;
                    sc.C_startDate = startDate;
                    sc.C_endDate = endDate;
                    sc.S_id = int.Parse(lbl_Student_ID.Text);
                    sc.CS_id = csid;
                    db.SubmitChanges();
                    MessageBox.Show("Student Course Updated Successfuly. ", "Update Student Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                    butt_En_clear.PerformClick();


                }

            }
        }

        private void End_Course_SelectedIndexChanged(object sender, EventArgs e)
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
                csid = (int)Start_Course.SelectedValue;
                var query1 = from cs in db.CoursesSessions where cs.CS_Id == csid select cs;
                End_Course.DisplayMember = "C_endDate";
                //comboBox2.DataSource = query;
                End_Course.DataSource = query1;

            }
        }

        private void butt_En_Delete_Click(object sender, EventArgs e)
        {

            if (lbl_Student_ID.Text == "")
            {
                MessageBox.Show("Please select a record for deletion", "Delete Student Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Student Course", "Delete Student Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBClassesDataContext db = new DBClassesDataContext();
                    StudentCourse sc = db.StudentCourses.SingleOrDefault(sc1 => sc1.SC_Id == int.Parse(label9_id.Text));
                    db.StudentCourses.DeleteOnSubmit(sc);
                    db.SubmitChanges();
                    MessageBox.Show("Student Course Deleted Successfuly", "Delete Student Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                    butt_En_clear.PerformClick();
                    
                }
            }
        }

        private void butt_En_clear_Click(object sender, EventArgs e)
        {
            lbl_Student_ID.Text = "";
            lbl_Student_Name.Text = "";
            cmb_Course_Name.Text = "";
            Start_Course.Text = "";
            End_Course.Text = "";
        }

        private void guna2DataGridView_course_Click(object sender, EventArgs e)
        {
            label9_id.Text = guna2DataGridView_course.CurrentRow.Cells[0].Value.ToString();
            lbl_Student_Name.Text= guna2DataGridView_course.CurrentRow.Cells[1].Value.ToString();
            cmb_Course_Name.Text= guna2DataGridView_course.CurrentRow.Cells[2].Value.ToString();
            Start_Course.Text= guna2DataGridView_course.CurrentRow.Cells[3].Value.ToString();
            End_Course.Text= guna2DataGridView_course.CurrentRow.Cells[4].Value.ToString();
            lbl_Student_ID.Text= guna2DataGridView_course.CurrentRow.Cells[5].Value.ToString();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
