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
    public partial class Session : Form
    {
        public Session()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            var query = from cs in db.CoursesSessions join c in db.Courses on cs.C_id equals c.C_Id select new { cs.CS_Id, CourseName = c.C_name, cs.C_startDate, cs.C_endDate };
            guna2DataGridView_courseSession.DataSource = query;

        }
        private bool IsDuplicateCourse(int courseID, DateTime startDate, DateTime endDate)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            bool isDuplicate = db.CoursesSessions
           .Any(c => c.C_id == courseID && c.C_startDate == startDate && c.C_endDate == endDate);


            return isDuplicate;
        }

        private void Session_Load(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            guna2ComboBox1.DataSource = from course in db.Courses select course;
            guna2ComboBox1.DisplayMember = "C_name";
            guna2ComboBox1.Text = "";
            showTable();
        }

        private void butt_Se_Submit_Click(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
           
            
            

                //string courseName = comboBox1.Text;
                guna2ComboBox1.ValueMember = "C_Id";
                int courseId = (int)guna2ComboBox1.SelectedValue;
                //var courseId = (from c in db.Courses
                //                where c.C_name == courseName
                //                select c.C_Id).SingleOrDefault();
                DateTime startDate = guna2DateTimePicker1_SD.Value;
                DateTime endDate = guna2DateTimePicker2_ED.Value;
                DateTime currentDate = DateTime.Now;
                if (startDate >= endDate)
                {
                    MessageBox.Show("End date must be after the start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method without performing the insert
                }
                if (IsDuplicateCourse(courseId, startDate, endDate))
                {
                    MessageBox.Show("This course with the same date range already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method without performing the insert
                }
                if (startDate < currentDate)
                {
                    MessageBox.Show("Start date cannot be in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method without performing the insert
                }

                //if (endDate < currentDate)
                //{
                //    MessageBox.Show("End date cannot be in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return; // Exit the method without performing the insert
                //}
                else
                {
                    CoursesSession CS = new CoursesSession();
                    CS.C_id = courseId;
                    CS.C_startDate = guna2DateTimePicker1_SD.Value;
                    CS.C_endDate = guna2DateTimePicker2_ED.Value;
                    db.CoursesSessions.InsertOnSubmit(CS);
                    db.SubmitChanges();
                    MessageBox.Show("Course Session Added Successfuly", "Add Course Session", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();

                }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
