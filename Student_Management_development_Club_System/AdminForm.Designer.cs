﻿namespace Student_Management_development_Club_System
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.panelMainMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.tab2 = new Guna.UI2.WinForms.Guna2Button();
            this.tab1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.MouseDetect = new System.Windows.Forms.Timer(this.components);
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.butt_Ad_LogOut = new Guna.UI2.WinForms.Guna2Button();
            this.subMenuAdmin1 = new Student_Management_development_Club_System.subMenuAdmin();
            this.panelMainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.panelMainMenu.Controls.Add(this.tab2);
            this.panelMainMenu.Controls.Add(this.tab1);
            this.panelMainMenu.Controls.Add(this.panel1);
            this.guna2Transition1.SetDecoration(this.panelMainMenu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(55, 522);
            this.panelMainMenu.TabIndex = 0;
            // 
            // tab2
            // 
            this.tab2.Animated = true;
            this.guna2Transition1.SetDecoration(this.tab2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tab2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tab2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tab2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tab2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tab2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tab2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.tab2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab2.ForeColor = System.Drawing.Color.White;
            this.tab2.Image = ((System.Drawing.Image)(resources.GetObject("tab2.Image")));
            this.tab2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tab2.ImageSize = new System.Drawing.Size(30, 30);
            this.tab2.IndicateFocus = true;
            this.tab2.Location = new System.Drawing.Point(0, 145);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(55, 45);
            this.tab2.TabIndex = 3;
            this.tab2.Tag = "1";
            this.tab2.Text = "  Control";
            this.tab2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tab2.Click += new System.EventHandler(this.sideMenu_Click);
            // 
            // tab1
            // 
            this.tab1.Animated = true;
            this.guna2Transition1.SetDecoration(this.tab1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tab1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tab1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tab1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tab1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tab1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tab1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.tab1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab1.ForeColor = System.Drawing.Color.White;
            this.tab1.Image = ((System.Drawing.Image)(resources.GetObject("tab1.Image")));
            this.tab1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tab1.ImageSize = new System.Drawing.Size(30, 30);
            this.tab1.IndicateFocus = true;
            this.tab1.Location = new System.Drawing.Point(0, 100);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(55, 45);
            this.tab1.TabIndex = 1;
            this.tab1.Tag = "0";
            this.tab1.Text = "  Registration";
            this.tab1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tab1.Click += new System.EventHandler(this.sideMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Transition1.SetDecoration(this.panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 100);
            this.panel1.TabIndex = 2;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2Transition1.SetDecoration(this.guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(1, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(49, 53);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // MouseDetect
            // 
            this.MouseDetect.Enabled = true;
            this.MouseDetect.Tick += new System.EventHandler(this.MouseDetect_Tick);
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizBlind;
            this.guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation1;
            this.guna2Transition1.TimeStep = 0.05F;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.subMenuAdmin1);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Transition1.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(55, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(289, 522);
            this.guna2Panel1.TabIndex = 1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Transition1.SetDecoration(this.guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(289, 75);
            this.guna2Panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(59, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dashboard";
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2Transition1.SetDecoration(this.guna2ContextMenuStrip1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BorderRadius = 30;
            this.guna2Transition1.SetDecoration(this.guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2PictureBox2.Image = global::Student_Management_development_Club_System.Properties.Resources.Screenshot_20231028_112727_Canva_transformed;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(544, 14);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(467, 498);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 39;
            this.guna2PictureBox2.TabStop = false;
            // 
            // butt_Ad_LogOut
            // 
            this.butt_Ad_LogOut.Animated = true;
            this.butt_Ad_LogOut.AutoRoundedCorners = true;
            this.butt_Ad_LogOut.BackColor = System.Drawing.Color.White;
            this.butt_Ad_LogOut.BorderRadius = 13;
            this.guna2Transition1.SetDecoration(this.butt_Ad_LogOut, Guna.UI2.AnimatorNS.DecorationType.None);
            this.butt_Ad_LogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.butt_Ad_LogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.butt_Ad_LogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.butt_Ad_LogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.butt_Ad_LogOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(48)))), ((int)(((byte)(100)))));
            this.butt_Ad_LogOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.butt_Ad_LogOut.ForeColor = System.Drawing.Color.White;
            this.butt_Ad_LogOut.Location = new System.Drawing.Point(1208, 481);
            this.butt_Ad_LogOut.Name = "butt_Ad_LogOut";
            this.butt_Ad_LogOut.Size = new System.Drawing.Size(93, 29);
            this.butt_Ad_LogOut.TabIndex = 129;
            this.butt_Ad_LogOut.Text = "LogOut";
            this.butt_Ad_LogOut.Click += new System.EventHandler(this.butt_Ad_LogOut_Click);
            // 
            // subMenuAdmin1
            // 
            this.guna2Transition1.SetDecoration(this.subMenuAdmin1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.subMenuAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subMenuAdmin1.Location = new System.Drawing.Point(0, 75);
            this.subMenuAdmin1.Name = "subMenuAdmin1";
            this.subMenuAdmin1.Size = new System.Drawing.Size(289, 447);
            this.subMenuAdmin1.TabIndex = 1;
            this.subMenuAdmin1.Load += new System.EventHandler(this.subMenuAdmin1_Load);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1313, 522);
            this.Controls.Add(this.butt_Ad_LogOut);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panelMainMenu);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.panelMainMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMainMenu;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button tab1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button tab2;
        private System.Windows.Forms.Timer MouseDetect;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private subMenuAdmin subMenuAdmin1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private Guna.UI2.WinForms.Guna2Button butt_Ad_LogOut;
    }
}