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
    public partial class NewStudent : Form
    {
        public NewStudent()
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
            

            //foreach (var radioButton in radioButtons)
            //{
            //    if (!radioButton.Checked)
            //    {
            //        // Display an error message to the user.
            //        MessageBox.Show("Please select one of the radio buttons.");
            //        return false;
            //    }
            //}

            // If all text boxes and radio buttons are filled in, return true.
            return true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butt_sAdd_Click(object sender, EventArgs e)
        {
            int bornY = guna2DateTimePicker3_DOB.Value.Year;
            int currentY = DateTime.Now.Year;
            // Prevent the user from inserting data if any text box button is null.
            if (!verfy(this))
            {
                
                return;  
            }
            else if (!radio_Male.Checked && !guna2RadioButton1_female.Checked)
            {
                MessageBox.Show("Please select the gender.", "invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
         
            else if ((currentY - bornY) < 11 || (currentY - bornY) > 70)
            {
                MessageBox.Show("The student age must be between 11 and 70 years old", "invalid DOB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DBClassesDataContext db = new DBClassesDataContext();
                Student student = new Student();
                student.S_firstName = txb_S_First_Name.Text;
                student.S_lastName = txb_S_Last_Name.Text;
                student.S_parentPhone = guna2TextBox1_parentPhone.Text;
                student.S_gender = radio_Male.Text;
                if (radio_Male.Checked == true)
                {
                    student.S_gender = radio_Male.Text;
                }
                else
                {
                    student.S_gender = guna2RadioButton1_female.Text;
                }
                student.S_phone = txb_S_Phone.Text;
                student.S_address = textBox3_address.Text;
                student.S_birthDate = guna2DateTimePicker3_DOB.Value;
                db.Students.InsertOnSubmit(student);
                db.SubmitChanges();
                MessageBox.Show("Student info added Successfuly", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showTable();
                butt_sClear.PerformClick();
            }

        }
            
            
               
               

            

        
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();

            guna2DataGridView1_student.DataSource = db.Students.ToList();
        
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            showTable();
            guna2DataGridView1_student.ReadOnly = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_student_Click(object sender, EventArgs e)
        {
            //label10_id.Text =guna2DataGridView1_student.CurrentRow.Cells[0].Value.ToString();
            //txb_S_First_Name.Text= guna2DataGridView1_student.CurrentRow.Cells[1].Value.ToString();
            //txb_S_Last_Name.Text= guna2DataGridView1_student.CurrentRow.Cells[2].Value.ToString();
            //if (guna2DataGridView1_student.CurrentRow.Cells[3].Value.ToString() == "Male")
            //{
            //    radio_Male.Checked = true;
            //}
            //else
            //{
            //    guna2RadioButton1_female.Checked = true;
            //}
            ////radio_Male.Checked= guna2DataGridView1_student.CurrentRow.Cells[3].Value.ToString();
            //guna2DateTimePicker3_DOB.Value= DateTime.Parse( guna2DataGridView1_student.CurrentRow.Cells[4].Value.ToString());
            //txb_S_Phone.Text= guna2DataGridView1_student.CurrentRow.Cells[5].Value.ToString();
            //guna2TextBox1_parentPhone.Text= guna2DataGridView1_student.CurrentRow.Cells[6].Value.ToString();
            //textBox3_address.Text= guna2DataGridView1_student.CurrentRow.Cells[7].Value.ToString();
        }

        private void butt_sClear_Click(object sender, EventArgs e)
        {
            txb_S_First_Name.Text = "";
            txb_S_Last_Name.Text = "";
            guna2TextBox1_parentPhone.Text = "";
            txb_S_Phone.Text = "";
            textBox3_address.Text = "";
            radio_Male.Checked= false;
            guna2RadioButton1_female.Checked= false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
