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
    public partial class ManageSession : Form
    {
        public ManageSession()
        {
            InitializeComponent();
        }

        private void ManageSession_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            var query = from cs in db.CoursesSessions join c in db.Courses on cs.C_id equals c.C_Id select new { cs.CS_Id, CourseName = c.C_name, cs.C_startDate, cs.C_endDate };
            guna2DataGridView_courseSession.DataSource = query;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void butt_Se_Update_Click(object sender, EventArgs e)
        {
           
            DBClassesDataContext db = new DBClassesDataContext();
            if (label5_id.Text =="")
            {
                MessageBox.Show("Please select a record for updating", "Update Session", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else 
            {
                var isAssignedToStudent = db.StudentCourses.Any(sc => sc.CS_id == int.Parse(label5_id.Text));

                if (isAssignedToStudent)
                {
                    MessageBox.Show("Cannot update this course session as it is assigned to a student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    DBClassesDataContext db1 = new DBClassesDataContext();
                    var courseSession = db.CoursesSessions.FirstOrDefault(cs => cs.CS_Id == int.Parse(label5_id.Text));
                    DateTime sd = guna2DateTimePicker1_startDate.Value;
                    DateTime ed = guna2DateTimePicker2_endDate.Value;
                    DateTime originalSD = courseSession.C_startDate;
                    DateTime originalED = courseSession.C_endDate;
                    if (sd < originalSD || ed < originalED)
                    {
                        // Display a message to the user.
                        MessageBox.Show("Cannot update the course session because the start or end date is less than the start and end dates for that specific course session in DB.", "Update Course Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ;
                    }
                    else
                    {
                        CoursesSession coursesSession = db.CoursesSessions.SingleOrDefault(cs => cs.CS_Id == int.Parse(label5_id.Text));
                        coursesSession.C_startDate = sd;
                        coursesSession.C_endDate = ed;
                        db.SubmitChanges();
                        MessageBox.Show("Course Session updated Successfuly", "Update Course Session", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showTable();
                        butt_Se_Clear.PerformClick();   
                    }

                }

            }
        }

        private void butt_Se_Delete_Click(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            if (label5_id.Text == "")
            {
                MessageBox.Show("Please select a record for deleting", "Delete Session", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                var isAssignedToStudent = db.StudentCourses.Any(sc => sc.CS_id == int.Parse(label5_id.Text));
                if (isAssignedToStudent)
                {
                    MessageBox.Show("Cannot delete this course session as it is assigned to a student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this Course Session", "Delete Course Session", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DBClassesDataContext db1 = new DBClassesDataContext();
                        CoursesSession session = db.CoursesSessions.SingleOrDefault(cs => cs.CS_Id == int.Parse(label5_id.Text));
                        db1.CoursesSessions.DeleteOnSubmit(session);
                        db1.SubmitChanges();
                        MessageBox.Show("Course Session Deleted Successfuly", "Delete Course Session", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showTable();
                        butt_Se_Clear.PerformClick();
                    }


                }
            }
        }

        private void guna2DataGridView_courseSession_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView_courseSession_Click(object sender, EventArgs e)
        {
            label5_id.Text =guna2DataGridView_courseSession.CurrentRow.Cells[0].Value.ToString();
            label5_courseName.Text= guna2DataGridView_courseSession.CurrentRow.Cells[1].Value.ToString();
            guna2DateTimePicker1_startDate.Value=DateTime.Parse( guna2DataGridView_courseSession.CurrentRow.Cells[2].Value.ToString());
            guna2DateTimePicker2_endDate.Value= DateTime.Parse(guna2DataGridView_courseSession.CurrentRow.Cells[3].Value.ToString());

        }

        private void butt_Se_Clear_Click(object sender, EventArgs e)
        {
            label5_courseName.Text = "";
            //guna2DateTimePicker1_startDate.Value = DateTime.MinValue;
            //guna2DateTimePicker2_endDate.Value = DateTime.MinValue;
            label5_id.Text = "";

        }

        private void guna2DateTimePicker1_startDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
