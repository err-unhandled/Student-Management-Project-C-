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
    public partial class Manage_Marks : Form
    {
        public Manage_Marks()
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
            var query = from sm in db.StudentMarks join c in db.Courses on sm.C_id equals c.C_Id join s in db.Students on sm.S_id equals s.S_Id select new { sm.SM_Id, StudentName = s.S_firstName + " " + s.S_lastName, c.C_name, sm.S_mark, sm.SM_description };
            guna2DataGridView_studentMarrk.DataSource = query;
            guna2DataGridView_studentMarrk.ReadOnly = true;
        }
        private void Manage_Marks_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void guna2DataGridView_studentMarrk_Click(object sender, EventArgs e)
        {
            label6_smid.Text = guna2DataGridView_studentMarrk.CurrentRow.Cells[0].Value.ToString();
            lbl_Student_Name.Text = guna2DataGridView_studentMarrk.CurrentRow.Cells[1].Value.ToString();
            lbl_Course_Name.Text = guna2DataGridView_studentMarrk.CurrentRow.Cells[2].Value.ToString();
            guna2TextBox1_mark.Text = guna2DataGridView_studentMarrk.CurrentRow.Cells[3].Value.ToString();
            textBox3_description.Text = guna2DataGridView_studentMarrk.CurrentRow.Cells[4].Value.ToString();
        }

        private void butt_sUpdate_Click(object sender, EventArgs e)
        {
            if (label6_smid.Text == "")
            {
                MessageBox.Show("Please select a record for updating", "Update Student Mark", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(!verfy(this))
                {
                    return;
                }
                DBClassesDataContext db = new DBClassesDataContext();
                StudentMark studentMark = db.StudentMarks.SingleOrDefault(sm => sm.SM_Id == int.Parse(label6_smid.Text));
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
                    db.SubmitChanges();
                    MessageBox.Show("Student Mark Updated Successfuly", "Update Student Mark", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                    butt_sClear.PerformClick();
                }
            }
        }

        private void butt_sClear_Click(object sender, EventArgs e)
        {
            lbl_Course_Name.Text = "";
            lbl_Student_Name.Text = "";
            label6_smid.Text = "";
            guna2TextBox1_mark.Clear();
            textBox3_description.Clear();
        }

        private void butt_sDelete_Click(object sender, EventArgs e)
        {
            if (label6_smid.Text == "")
            {
                MessageBox.Show("Please select a record for deletion", "Delete Student Mark", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Student Mark", "Delete Student Mark", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBClassesDataContext db = new DBClassesDataContext();
                    StudentMark studentMark = db.StudentMarks.SingleOrDefault(sm => sm.SM_Id == int.Parse(label6_smid.Text));
                    db.StudentMarks.DeleteOnSubmit(studentMark);
                    db.SubmitChanges();
                    MessageBox.Show("Student Mark Deleted Successfuly", "Delete Student Mark", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                    butt_sClear.PerformClick();
                }
            }
        }

        private void butt_Search_Click(object sender, EventArgs e)
        {
            DBClassesDataContext db = new DBClassesDataContext();
            string searchName = txb_Search.Text.Trim();
            var searchResult = from std in db.Students where std.S_firstName.Contains(searchName) || std.S_lastName.Contains(searchName) select std;
            guna2DataGridView_studentMarrk.DataSource = searchResult.ToList();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
