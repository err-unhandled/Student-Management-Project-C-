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
    public partial class ManageCourse : Form
    {
        public ManageCourse()
        {
            InitializeComponent();
        }
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            guna2DataGridView_course.DataSource = db.Courses.ToList();
            guna2DataGridView_course.ReadOnly = true;
        }
        private void ManageCourse_Load(object sender, EventArgs e)
        {
            showTable();
            label3.Visible = false;
            lbl_Course_ID.Visible = false;  
        }

        private void guna2DataGridView_course_Click(object sender, EventArgs e)
        {
            lbl_Course_ID.Text = guna2DataGridView_course.CurrentRow.Cells[0].Value.ToString();
            txb_cName.Text = guna2DataGridView_course.CurrentRow.Cells[1].Value.ToString();
            txb_cHour.Text = guna2DataGridView_course.CurrentRow.Cells[2].Value.ToString();
            txb_description.Text = guna2DataGridView_course.CurrentRow.Cells[3].Value.ToString();
        }

        private void butt_cDelete_Click(object sender, EventArgs e)
        {
            if (lbl_Course_ID.Text == "")
            {
                MessageBox.Show("Please select a record for deletion", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Course", "Delete Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBClassesDataContext db = new DBClassesDataContext();
                    int cid = int.Parse(lbl_Course_ID.Text);
                    var courseSessions = db.CoursesSessions.Where(cs => cs.C_id == cid);
                    if (courseSessions.Any())
                    {
                        // Display a message to the user.
                        MessageBox.Show("Cannot delete the course because it is associated with one or more course sessions.");
                    }
                    else
                    {
                        // Delete the course.
                        Course course = db.Courses.SingleOrDefault(c => c.C_Id == cid);
                        db.Courses.DeleteOnSubmit(course);
                        db.SubmitChanges();
                        MessageBox.Show("Course Deleted Successfuly", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showTable();
                        butt_cClear.PerformClick();


                    }
                }

            }
        }

        private void butt_cClear_Click(object sender, EventArgs e)
        {
            txb_cName.Text = "";
            txb_cHour.Text = "";
            txb_description.Text = "";
            lbl_Course_ID.Text = "";

        }

        private void butt_cUpdate_Click(object sender, EventArgs e)
        {
            if (lbl_Course_ID.Text == "")
            {
                MessageBox.Show("Please select a record for updating", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBClassesDataContext db = new DBClassesDataContext();
                int cid = int.Parse(lbl_Course_ID.Text);
                var courseSessions = db.CoursesSessions.Where(cs => cs.C_id == cid);
                if (courseSessions.Any())
                {
                    // Display a message to the user.
                    MessageBox.Show("Cannot update the course because it is associated with one or more course sessions.");
                }
                else
                {
                    Course course = db.Courses.SingleOrDefault(c => c.C_Id == cid);
                    course.C_name = txb_cName.Text;
                    // Check if the text in the text box is a number.
                    if (!int.TryParse(txb_cHour.Text, out int number))
                    {
                        // Display a message box to the user notifying them that text is not supported.
                        MessageBox.Show("Please enter a valid number for course hours.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {

                        course.C_hours = int.Parse(txb_cHour.Text);

                        course.C_description = txb_description.Text;
                        db.SubmitChanges();
                        MessageBox.Show("Course info updated Successfuly", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showTable();
                        butt_cClear.PerformClick();

                    }
                }

            }
        }

        private void guna2DataGridView_course_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txb_cName_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView_course_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
