﻿namespace ChatApplication
{
    partial class ProfilePage
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GuideToChangeProfile = new System.Windows.Forms.Label();
            this.ProfilePicture = new ChatApplication.CustomPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AboutBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new ChatApplication.HoverButton();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopPanel.Controls.Add(this.NameLabel);
            this.TopPanel.Controls.Add(this.GuideToChangeProfile);
            this.TopPanel.Controls.Add(this.ProfilePicture);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 29);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 276);
            this.TopPanel.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(0, 225);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(800, 51);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "label1";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GuideToChangeProfile
            // 
            this.GuideToChangeProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.GuideToChangeProfile.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuideToChangeProfile.Location = new System.Drawing.Point(0, 209);
            this.GuideToChangeProfile.Name = "GuideToChangeProfile";
            this.GuideToChangeProfile.Size = new System.Drawing.Size(800, 16);
            this.GuideToChangeProfile.TabIndex = 3;
            this.GuideToChangeProfile.Text = "Click to change the profile \r\n";
            this.GuideToChangeProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.BackColor = System.Drawing.Color.Transparent;
            this.ProfilePicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProfilePicture.Image = global::ChatApplication.Properties.Resources.user__2_;
            this.ProfilePicture.Location = new System.Drawing.Point(0, 0);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(800, 209);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ProfilePicture.TabIndex = 2;
            this.ProfilePicture.TabStop = false;
            this.ProfilePicture.Click += new System.EventHandler(this.ProfilePictureClick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "About";
            // 
            // AboutBox
            // 
            this.AboutBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutBox.BackColor = System.Drawing.SystemColors.Window;
            this.AboutBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AboutBox.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutBox.Location = new System.Drawing.Point(12, 333);
            this.AboutBox.Multiline = true;
            this.AboutBox.Name = "AboutBox";
            this.AboutBox.Size = new System.Drawing.Size(766, 67);
            this.AboutBox.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 29);
            this.panel1.TabIndex = 6;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.SkyBlue;
            this.CloseButton.BackgroudColor = System.Drawing.Color.SkyBlue;
            this.CloseButton.BorderColor = System.Drawing.Color.Transparent;
            this.CloseButton.BorderRadius1 = 10;
            this.CloseButton.BorderSize1 = 0;
            this.CloseButton.ButtonSideHoverlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(247)))));
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.EndPoint = -3;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Image = global::ChatApplication.Properties.Resources.icons8_close_24;
            this.CloseButton.IsFormUp = false;
            this.CloseButton.IsSelected = false;
            this.CloseButton.Location = new System.Drawing.Point(756, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(44, 29);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.TextColor = System.Drawing.Color.White;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AboutBox);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfilePage";
            this.Text = "ProfilePage";
            this.Load += new System.EventHandler(this.ProfilePageLoad);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private CustomPictureBox ProfilePicture;
        private System.Windows.Forms.Label GuideToChangeProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AboutBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Panel panel1;
        private HoverButton CloseButton;
    }
}