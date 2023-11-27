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
    public partial class Employeecs : Form
    {
        public Employeecs()
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
        public void showTable()
        {
            DBClassesDataContext db = new DBClassesDataContext();
            guna2DataGridView1_employee.DataSource = db.Employees.ToList();
            guna2DataGridView1_employee.ReadOnly = true;
            guna2DataGridView1_employee.Columns["E_userName"].Visible = false;
            guna2DataGridView1_employee.Columns["E_password"].Visible = false;

        }
        private void Employeecs_Load(object sender, EventArgs e)
        {
            showTable();
            guna2ComboBox1.Text = "";
        }

        private void butt_Em_Add_Click(object sender, EventArgs e)
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

            else if ((currentY - bornY) < 22 || (currentY - bornY) > 75)
            {
                MessageBox.Show("The employee age must be between 22 and 75 years old", "invalid DOB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (guna2ComboBox1.Text == "")
            {
                MessageBox.Show("Please choose the role", "invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DBClassesDataContext db = new DBClassesDataContext();
                Employee employee = new Employee();
                employee.E_firstName = txb_S_First_Name.Text;
                employee.E_lastName = txb_S_Last_Name.Text;
                employee.E_userName = txb_User_Name.Text;
                employee.E_password = guna2TextBox1_password.Text;
                employee.E_dateBirth = guna2DateTimePicker3_DOB.Value;
                if (radio_Male.Checked == true)
                {
                    employee.E_gender = radio_Male.Text;
                }
                else
                {
                    employee.E_gender = guna2RadioButton1_female.Text;
                }
                employee.E_phone = txb_S_Phone.Text;
                employee.E_address = textBox1_address.Text;
                employee.E_role = guna2ComboBox1.Text;
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
                MessageBox.Show("Employee info added Successfuly", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showTable();
                butt_Em_Clear.PerformClick();

            }
        }

        private void butt_Em_Clear_Click(object sender, EventArgs e)
        {
            txb_S_First_Name.Text = "";
            txb_S_Last_Name.Text = "";
            txb_S_Phone.Text = "";
            textBox1_address.Text = "";
            txb_User_Name.Text = "";
            guna2TextBox1_password.Text = "";
            radio_Male.Checked = false;
            guna2RadioButton1_female.Checked = false;
            guna2ComboBox1.Text = " ";
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
