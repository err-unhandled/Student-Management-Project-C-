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
    public partial class NewCourse : Form
    {

        public NewCourse()
        {
            InitializeComponent();
        }




        public static bool verfy(Form form)
        {
            // Get all text boxes and radio buttons in the form.
            var textBoxes = form.Controls.OfType<TextBox>();

            // Check if any text box or radio button is null.
            foreach (var textBox in textBoxes)
            {
                if (textBox.Text == null || textBox.Text == "")
                {
                    // Display an error message to the user.
                    MessageBox.Show("Please fill in all required text box.", "invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            guna2DataGridView_course.DataSource = db.Courses.ToList();
            guna2DataGridView_course.ReadOnly = true;
        }
        private void NewCourse_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void butt_cAdd_Click(object sender, EventArgs e)
        {
            if (!verfy(this))
            {

                return;
            }
            else
            {
                DBClassesDataContext db = new DBClassesDataContext();
                Course course = new Course();
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
                }
                course.C_description = txb_description.Text;
                db.Courses.InsertOnSubmit(course);
                db.SubmitChanges();
                MessageBox.Show("Course info added Successfuly", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showTable();
                butt_cClear.PerformClick();


            }
        }

        private void butt_cClear_Click(object sender, EventArgs e)
        {
            txb_cName.Text = "";
            txb_cHour.Text = "";
            txb_description.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}