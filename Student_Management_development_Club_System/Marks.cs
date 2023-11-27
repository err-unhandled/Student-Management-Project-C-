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
    public partial class Marks : Form
    {
        public Marks()
        {
            InitializeComponent();
        }
        public static bool verfy(Form form)
        {
            // Get all text boxes and radio buttons in the form.
            var textBoxes = form.Controls.OfType<TextBox>();
            var radioButtons = form.Controls.OfType<RadioButton>();

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
            var query = from sc in db.StudentCourses join c in db.Courses on sc.C_id equals c.C_Id join s in db.Students on sc.S_id equals s.S_Id select new { StudentName = s.S_firstName + " " + s.S_lastName, c.C_name, sc.S_id, sc.C_id };
            guna2DataGridView_mark.DataSource= query;
            guna2DataGridView_mark.Columns["S_id"].Visible = false;
            guna2DataGridView_mark.Columns["C_id"].Visible=false;
            guna2DataGridView_mark.ReadOnly=true;
        }
        private void Marks_Load(object sender, EventArgs e)
        {
            label4.Visible=false;
            lable.Visible=false;
            lbl_Course_ID.Visible=false;
            lbl_Student_ID.Visible=false;
            showTable();
        }

        private void guna2DataGridView_mark_Click(object sender, EventArgs e)
        {if(guna2DataGridView_mark.DataSource==null)
            {
                return;
            }
            lbl_Student_Name.Text = guna2DataGridView_mark.CurrentRow.Cells[0].Value.ToString();
            lbl_Course_Name.Text = guna2DataGridView_mark.CurrentRow.Cells[1].Value.ToString();
            lbl_Student_ID.Text = guna2DataGridView_mark.CurrentRow.Cells[2].Value.ToString();
            lbl_Course_ID.Text = guna2DataGridView_mark.CurrentRow.Cells[3].Value.ToString();
        }

        private void butt_sSubmit_Click(object sender, EventArgs e)
        {
            if(lbl_Student_ID.Text =="")
            {
                MessageBox.Show("Please select a student", "ADD Marks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!verfy(this))
                {
                    return;
                }
                    DBClassesDataContext db = new DBClassesDataContext();
                    var existingRecord = db.StudentMarks.FirstOrDefault(sm => sm.S_id == int.Parse(lbl_Student_ID.Text) && sm.C_id == int.Parse(lbl_Course_ID.Text));


                    StudentMark studentMark = new StudentMark();
                    studentMark.C_id = int.Parse(lbl_Course_ID.Text);
                    studentMark.S_id = int.Parse(lbl_Student_ID.Text);
                    if (!int.TryParse(guna2TextBox1_mark.Text, out int number))
                    {
                        // Display a message box to the user notifying them that text is not supported.
                        MessageBox.Show("Please enter a valid number for student mark.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        studentMark.S_mark = int.Parse(guna2TextBox1_mark.Text);
                        studentMark.SM_description = textBox3_description.Text;
                    }
                    if (existingRecord == null)
                    {
                        db.StudentMarks.InsertOnSubmit(studentMark);
                        db.SubmitChanges();
                        MessageBox.Show("Student Mark Added Successfuly", "Add Student Mark", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showTable();
                        butt_sClear.PerformClick();
                    }



                    else
                    {
                        MessageBox.Show("A mark for this student and course already exists.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                
               


            }
        }

        private void butt_sClear_Click(object sender, EventArgs e)
        {
            lbl_Course_ID.Text = "";
            lbl_Course_Name.Text = "";
            lbl_Student_ID.Text = "";
            lbl_Student_Name.Text = "";
            guna2TextBox1_mark.Clear();
            textBox3_description.Clear();

        }

        private void butt_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
