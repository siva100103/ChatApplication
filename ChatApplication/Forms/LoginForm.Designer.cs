﻿namespace ChatApplication
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.centerP = new ChatApplication.CustomPanel();
            this.ipAddressLB = new System.Windows.Forms.Label();
            this.dpPictureU = new ChatApplication.DpPictureU();
            this.nextBtn = new ChatApplication.EllipseButton();
            this.lastNameTB = new ChatApplication.TextBoxU();
            this.firstNameTB = new ChatApplication.TextBoxU();
            this.customPanel1 = new ChatApplication.CustomPanel();
            this.ellipseControl1 = new ChatApplication.EllipseControl();
            this.panel1.SuspendLayout();
            this.centerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.centerP);
            this.panel1.Controls.Add(this.customPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 525);
            this.panel1.TabIndex = 1;
            // 
            // centerP
            // 
            this.centerP.AllBorderRadius = 25;
            this.centerP.BackColor = System.Drawing.Color.White;
            this.centerP.BorderColor = System.Drawing.Color.Transparent;
            this.centerP.BorderMarginSize = 1;
            this.centerP.BottomLeftRadius = 25;
            this.centerP.BottomRight = 25;
            this.centerP.Controls.Add(this.ipAddressLB);
            this.centerP.Controls.Add(this.dpPictureU);
            this.centerP.Controls.Add(this.nextBtn);
            this.centerP.Controls.Add(this.lastNameTB);
            this.centerP.Controls.Add(this.firstNameTB);
            this.centerP.Location = new System.Drawing.Point(90, 50);
            this.centerP.Margin = new System.Windows.Forms.Padding(2);
            this.centerP.Name = "centerP";
            this.centerP.Size = new System.Drawing.Size(560, 438);
            this.centerP.TabIndex = 7;
            this.centerP.TopLeftRadius = 25;
            this.centerP.TopRightRadius = 25;
            // 
            // ipAddressLB
            // 
            this.ipAddressLB.AutoSize = true;
            this.ipAddressLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLB.ForeColor = System.Drawing.Color.Black;
            this.ipAddressLB.Location = new System.Drawing.Point(152, 292);
            this.ipAddressLB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressLB.Name = "ipAddressLB";
            this.ipAddressLB.Size = new System.Drawing.Size(85, 18);
            this.ipAddressLB.TabIndex = 10;
            this.ipAddressLB.Text = "IpAddress : ";
            // 
            // dpPictureU
            // 
            this.dpPictureU.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dpPictureU.DpPicturPath = "";
            this.dpPictureU.Location = new System.Drawing.Point(212, 20);
            this.dpPictureU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dpPictureU.Name = "dpPictureU";
            this.dpPictureU.Size = new System.Drawing.Size(106, 92);
            this.dpPictureU.TabIndex = 9;
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(135)))), ((int)(((byte)(85)))));
            this.nextBtn.BackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(135)))), ((int)(((byte)(85)))));
            this.nextBtn.BorderColor = System.Drawing.Color.White;
            this.nextBtn.BorderRadius1 = 10;
            this.nextBtn.BorderSize1 = 0;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.ForeColor = System.Drawing.Color.White;
            this.nextBtn.Location = new System.Drawing.Point(212, 342);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(119, 42);
            this.nextBtn.TabIndex = 8;
            this.nextBtn.Text = "Next";
            this.nextBtn.TextColor = System.Drawing.Color.White;
            this.nextBtn.UseVisualStyleBackColor = false;
            // 
            // lastNameTB
            // 
            this.lastNameTB.BackColor = System.Drawing.Color.White;
            this.lastNameTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lastNameTB.Location = new System.Drawing.Point(147, 215);
            this.lastNameTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lastNameTB.Multiline = true;
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Padding = new System.Windows.Forms.Padding(18, 20, 6, 6);
            this.lastNameTB.PasswordChar = '\0';
            this.lastNameTB.PlaceholderLabelAtCenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lastNameTB.PlaceholderLabelAtTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(125)))), ((int)(((byte)(225)))));
            this.lastNameTB.PlaceholderText = "Lastname";
            this.lastNameTB.Size = new System.Drawing.Size(260, 54);
            this.lastNameTB.TabIndex = 6;
            this.lastNameTB.TabStop = false;
            this.lastNameTB.TextBoxDock = System.Windows.Forms.DockStyle.Fill;
            this.lastNameTB.TextBoxtext = "";
            this.lastNameTB.UseSystemPasswordChar = false;
            // 
            // firstNameTB
            // 
            this.firstNameTB.BackColor = System.Drawing.Color.White;
            this.firstNameTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.firstNameTB.Location = new System.Drawing.Point(147, 144);
            this.firstNameTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.firstNameTB.Multiline = true;
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Padding = new System.Windows.Forms.Padding(18, 20, 6, 6);
            this.firstNameTB.PasswordChar = '\0';
            this.firstNameTB.PlaceholderLabelAtCenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.firstNameTB.PlaceholderLabelAtTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(125)))), ((int)(((byte)(225)))));
            this.firstNameTB.PlaceholderText = "Firstname";
            this.firstNameTB.Size = new System.Drawing.Size(260, 54);
            this.firstNameTB.TabIndex = 5;
            this.firstNameTB.TabStop = false;
            this.firstNameTB.TextBoxDock = System.Windows.Forms.DockStyle.Fill;
            this.firstNameTB.TextBoxtext = "";
            this.firstNameTB.UseSystemPasswordChar = false;
            // 
            // customPanel1
            // 
            this.customPanel1.AllBorderRadius = 1;
            this.customPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(135)))), ((int)(((byte)(85)))));
            this.customPanel1.BorderColor = System.Drawing.Color.Black;
            this.customPanel1.BorderMarginSize = 0;
            this.customPanel1.BottomLeftRadius = 1;
            this.customPanel1.BottomRight = 1;
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPanel1.Location = new System.Drawing.Point(0, 0);
            this.customPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(753, 81);
            this.customPanel1.TabIndex = 6;
            this.customPanel1.TopLeftRadius = 1;
            this.customPanel1.TopRightRadius = 1;
            // 
            // ellipseControl1
            // 
            this.ellipseControl1.CornerRadius = 20;
            this.ellipseControl1.TargetControl = this.dpPictureU;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 525);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            this.centerP.ResumeLayout(false);
            this.centerP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private TextBoxU firstNameTB;
        private CustomPanel customPanel1;
        private CustomPanel centerP;
        private EllipseButton nextBtn;
        private TextBoxU lastNameTB;
        private EllipseControl ellipseControl1;
        private DpPictureU dpPictureU;
        private System.Windows.Forms.Label ipAddressLB;
    }
}