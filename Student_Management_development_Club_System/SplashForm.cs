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
    public partial class SplashForm : Form
    {

        Random random = new Random();  
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashTime_Tick(object sender, EventArgs e)
        {
            SplashTime.Enabled = true;
            guna2ProgressBar1.Increment(1);

            if (guna2ProgressBar1.Value == 100)
            {
                SplashTime.Stop();

                this.Hide();

                LogIn logIn = new LogIn();
                logIn.ShowDialog();

                return;
            }
            try
            {
                guna2ProgressBar1.Value += random.Next(1, 10);
            }
            catch (Exception)
            {
                SplashTime.Stop();

                this.Hide();

                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
        }
    }
}
