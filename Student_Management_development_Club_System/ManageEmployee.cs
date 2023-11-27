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
    public partial class ManageEmployee : Form
    {
        public ManageEmployee()
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
            label12_id.Text = "";
            guna2ComboBox1.Text = "";
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            showTable();
            guna2ComboBox1.Text = "";
            label11.Visible = false;
            label12_id.Visible = false;
        }

        private void guna2DataGridView1_employee_Click(object sender, EventArgs e)
        {
            label12_id.Text = guna2DataGridView1_employee.CurrentRow.Cells[0].Value.ToString();
            txb_S_First_Name.Text = guna2DataGridView1_employee.CurrentRow.Cells[1].Value.ToString();
            txb_S_Last_Name.Text = guna2DataGridView1_employee.CurrentRow.Cells[2].Value.ToString();
            guna2DateTimePicker3_DOB.Value = DateTime.Parse(guna2DataGridView1_employee.CurrentRow.Cells[3].Value.ToString());
            if (guna2DataGridView1_employee.CurrentRow.Cells[4].Value.ToString() == "Male")
            {
                radio_Male.Checked = true;
            }
            else
            {
                guna2RadioButton1_female.Checked = true;
            }
            txb_S_Phone.Text = guna2DataGridView1_employee.CurrentRow.Cells[5].Value.ToString();
            txb_User_Name.Text = guna2DataGridView1_employee.CurrentRow.Cells[6].Value.ToString();
            guna2TextBox1_password.Text = guna2DataGridView1_employee.CurrentRow.Cells[7].Value.ToString();
            textBox1_address.Text = guna2DataGridView1_employee.CurrentRow.Cells[8].Value.ToString();
            guna2ComboBox1.Text = guna2DataGridView1_employee.CurrentRow.Cells[9].Value.ToString();


        }

        private void butt_Em_Delete_Click(object sender, EventArgs e)
        {

            if (label12_id.Text == "")
            {
                MessageBox.Show("Please select a record for deletion", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(label12_id.Text);
                if (MessageBox.Show("Are you sure you want to delete this Employee", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBClassesDataContext db = new DBClassesDataContext();
                    Employee emp = db.Employees.SingleOrDefault(e1 => e1.E_Id == id);
                    db.Employees.DeleteOnSubmit(emp);
                    db.SubmitChanges();
                    MessageBox.Show("Employee info Deleted Successfuly", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (employee.deleteEmployee(id))

                    showTable();
                    butt_Em_Clear.PerformClick();
                }
            }
        }

        private void butt_Em_Update_Click(object sender, EventArgs e)
        {
            int bornY = guna2DateTimePicker3_DOB.Value.Year;
            int currentY = DateTime.Now.Year;
            if (label12_id.Text == "")
            {
                MessageBox.Show("Please select a record for updating", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // Prevent the user from inserting data if any text box button is null.
            else if (!verfy(this))
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
                Employee employee = db.Employees.SingleOrDefault(E => E.E_Id == int.Parse(label12_id.Text));
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
                db.SubmitChanges();
                MessageBox.Show("Employee info updated Successfuly", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showTable();
                butt_Em_Clear.PerformClick();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

