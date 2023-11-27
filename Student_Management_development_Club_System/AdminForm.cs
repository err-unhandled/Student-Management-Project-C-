﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimtToo.VisualReactive;

namespace Student_Management_development_Club_System
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        bool mnuExpanded = false;
        private void MouseDetect_Tick(object sender, EventArgs e)
        {
            // detect if the mouse is within the menu bounds

            if (!guna2Transition1.IsCompleted) return;

            // wxpand the panel by animating
            // else close the panel by animating

            if (panelMainMenu.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
            {
                if (!mnuExpanded)
                {
                    mnuExpanded = true;
                    panelMainMenu.Visible = false;
                    panelMainMenu.Width = 225;
                    guna2Transition1.Show(panelMainMenu);
                }
            }
            else
            {
                if (mnuExpanded)
                {
                    mnuExpanded = false;
                    panelMainMenu.Visible = false;
                    panelMainMenu.Width = 55;
                    guna2Transition1.Show(panelMainMenu);
                }
            }
        }

        private void sideMenu_Click(object sender, EventArgs e)
        {
            VSReactive<int>.SetState("menu", int.Parse(((Control)sender).Tag.ToString()));
        }

        private void subMenuAdmin1_Load(object sender, EventArgs e)
        {

        }

        private void butt_Ad_LogOut_Click(object sender, EventArgs e)
        {
            
            LogIn logIn = new LogIn();
            logIn.ShowDialog();
            this.Close();

        }
    }
}
