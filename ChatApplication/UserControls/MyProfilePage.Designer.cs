namespace ChatApplication.UserControls
{
    partial class MyProfilePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ThemePanel = new ChatApplication.UserControls.CustomPanel();
            this.DarkTheme = new System.Windows.Forms.PictureBox();
            this.SpacePanel = new System.Windows.Forms.Panel();
            this.LightTheme = new System.Windows.Forms.PictureBox();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.CancelLabel = new System.Windows.Forms.Label();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.EditBox = new System.Windows.Forms.TextBox();
            this.ThemeInfoLabel = new System.Windows.Forms.Label();
            this.AboutPanel = new System.Windows.Forms.Panel();
            this.AboutBox = new System.Windows.Forms.Label();
            this.AboutEdit = new System.Windows.Forms.Label();
            this.AboutInfoLabel = new System.Windows.Forms.Label();
            this.NamePanel = new ChatApplication.UserControls.CustomPanel();
            this.NameEdit = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.Label();
            this.NameInfoLabel = new System.Windows.Forms.Label();
            this.ProfilePanel = new System.Windows.Forms.Panel();
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            this.ProfileEditPanel = new System.Windows.Forms.Panel();
            this.ProfileEdit = new System.Windows.Forms.Label();
            this.GuideToChangeProfile = new System.Windows.Forms.Label();
            this.ProfileInfoLabel = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BackButton = new ChatApplication.UserControls.EllipseButton();
            this.MainPanel.SuspendLayout();
            this.ThemePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DarkTheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightTheme)).BeginInit();
            this.EditPanel.SuspendLayout();
            this.AboutPanel.SuspendLayout();
            this.NamePanel.SuspendLayout();
            this.ProfilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.ProfileEditPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.ThemePanel);
            this.MainPanel.Controls.Add(this.EditPanel);
            this.MainPanel.Controls.Add(this.ThemeInfoLabel);
            this.MainPanel.Controls.Add(this.AboutPanel);
            this.MainPanel.Controls.Add(this.AboutInfoLabel);
            this.MainPanel.Controls.Add(this.NamePanel);
            this.MainPanel.Controls.Add(this.NameInfoLabel);
            this.MainPanel.Controls.Add(this.ProfilePanel);
            this.MainPanel.Controls.Add(this.ProfileInfoLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 29);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.MainPanel.Size = new System.Drawing.Size(348, 749);
            this.MainPanel.TabIndex = 24;
            // 
            // ThemePanel
            // 
            this.ThemePanel.AllBorderRadius = 30;
            this.ThemePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(101)))), ((int)(((byte)(118)))));
            this.ThemePanel.BorderColor = System.Drawing.Color.Transparent;
            this.ThemePanel.BorderMarginSize = 0;
            this.ThemePanel.BottomLeftRadius = 30;
            this.ThemePanel.BottomRight = 30;
            this.ThemePanel.Controls.Add(this.DarkTheme);
            this.ThemePanel.Controls.Add(this.SpacePanel);
            this.ThemePanel.Controls.Add(this.LightTheme);
            this.ThemePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ThemePanel.Location = new System.Drawing.Point(2, 551);
            this.ThemePanel.Name = "ThemePanel";
            this.ThemePanel.Padding = new System.Windows.Forms.Padding(6);
            this.ThemePanel.Size = new System.Drawing.Size(331, 65);
            this.ThemePanel.TabIndex = 33;
            this.ThemePanel.TopLeftRadius = 30;
            this.ThemePanel.TopRightRadius = 30;
            // 
            // DarkTheme
            // 
            this.DarkTheme.BackColor = System.Drawing.Color.Transparent;
            this.DarkTheme.Cursor = System.Windows.Forms.Cursors.Default;
            this.DarkTheme.Dock = System.Windows.Forms.DockStyle.Left;
            this.DarkTheme.Image = global::ChatApplication.Properties.Resources.icons8_cloudy_night_30;
            this.DarkTheme.Location = new System.Drawing.Point(82, 6);
            this.DarkTheme.Name = "DarkTheme";
            this.DarkTheme.Size = new System.Drawing.Size(66, 53);
            this.DarkTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DarkTheme.TabIndex = 14;
            this.DarkTheme.TabStop = false;
            this.DarkTheme.Click += new System.EventHandler(this.ThemeClick);
            // 
            // SpacePanel
            // 
            this.SpacePanel.BackColor = System.Drawing.Color.Transparent;
            this.SpacePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SpacePanel.Location = new System.Drawing.Point(72, 6);
            this.SpacePanel.Name = "SpacePanel";
            this.SpacePanel.Size = new System.Drawing.Size(10, 53);
            this.SpacePanel.TabIndex = 15;
            // 
            // LightTheme
            // 
            this.LightTheme.BackColor = System.Drawing.Color.Transparent;
            this.LightTheme.Cursor = System.Windows.Forms.Cursors.Default;
            this.LightTheme.Dock = System.Windows.Forms.DockStyle.Left;
            this.LightTheme.Image = global::ChatApplication.Properties.Resources.icons8_partly_cloudy_day_30;
            this.LightTheme.Location = new System.Drawing.Point(6, 6);
            this.LightTheme.Name = "LightTheme";
            this.LightTheme.Size = new System.Drawing.Size(66, 53);
            this.LightTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LightTheme.TabIndex = 13;
            this.LightTheme.TabStop = false;
            this.LightTheme.Click += new System.EventHandler(this.ThemeClick);
            // 
            // EditPanel
            // 
            this.EditPanel.Controls.Add(this.CancelLabel);
            this.EditPanel.Controls.Add(this.SaveLabel);
            this.EditPanel.Controls.Add(this.EditBox);
            this.EditPanel.Location = new System.Drawing.Point(7, 737);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Padding = new System.Windows.Forms.Padding(5);
            this.EditPanel.Size = new System.Drawing.Size(331, 28);
            this.EditPanel.TabIndex = 31;
            this.EditPanel.Visible = false;
            // 
            // CancelLabel
            // 
            this.CancelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CancelLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(209)))), ((int)(((byte)(149)))));
            this.CancelLabel.Location = new System.Drawing.Point(124, 105);
            this.CancelLabel.Name = "CancelLabel";
            this.CancelLabel.Size = new System.Drawing.Size(90, 36);
            this.CancelLabel.TabIndex = 19;
            this.CancelLabel.Text = "Cancel";
            this.CancelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CancelLabel.Click += new System.EventHandler(this.OnClickFromEditPanel);
            // 
            // SaveLabel
            // 
            this.SaveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaveLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(209)))), ((int)(((byte)(149)))));
            this.SaveLabel.Location = new System.Drawing.Point(230, 105);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(90, 36);
            this.SaveLabel.TabIndex = 18;
            this.SaveLabel.Text = "Save";
            this.SaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveLabel.Click += new System.EventHandler(this.OnClickFromEditPanel);
            // 
            // EditBox
            // 
            this.EditBox.BackColor = System.Drawing.Color.White;
            this.EditBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EditBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBox.ForeColor = System.Drawing.Color.Black;
            this.EditBox.Location = new System.Drawing.Point(5, 5);
            this.EditBox.Multiline = true;
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(321, 85);
            this.EditBox.TabIndex = 17;
            // 
            // ThemeInfoLabel
            // 
            this.ThemeInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.ThemeInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ThemeInfoLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThemeInfoLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ThemeInfoLabel.Location = new System.Drawing.Point(2, 505);
            this.ThemeInfoLabel.Name = "ThemeInfoLabel";
            this.ThemeInfoLabel.Padding = new System.Windows.Forms.Padding(2, 8, 0, 0);
            this.ThemeInfoLabel.Size = new System.Drawing.Size(331, 46);
            this.ThemeInfoLabel.TabIndex = 27;
            this.ThemeInfoLabel.Text = "Theme                                         ▼";
            this.ThemeInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThemeInfoLabel.Click += new System.EventHandler(this.ThemeInfoLabelClick);
            // 
            // AboutPanel
            // 
            this.AboutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.AboutPanel.Controls.Add(this.AboutBox);
            this.AboutPanel.Controls.Add(this.AboutEdit);
            this.AboutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AboutPanel.Location = new System.Drawing.Point(2, 422);
            this.AboutPanel.Name = "AboutPanel";
            this.AboutPanel.Padding = new System.Windows.Forms.Padding(4);
            this.AboutPanel.Size = new System.Drawing.Size(331, 83);
            this.AboutPanel.TabIndex = 26;
            // 
            // AboutBox
            // 
            this.AboutBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(55)))), ((int)(((byte)(78)))));
            this.AboutBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.AboutBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F);
            this.AboutBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AboutBox.Location = new System.Drawing.Point(4, 4);
            this.AboutBox.Name = "AboutBox";
            this.AboutBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.AboutBox.Size = new System.Drawing.Size(260, 75);
            this.AboutBox.TabIndex = 8;
            this.AboutBox.Text = "About...";
            // 
            // AboutEdit
            // 
            this.AboutEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.AboutEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.AboutEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(137)))), ((int)(((byte)(242)))));
            this.AboutEdit.Location = new System.Drawing.Point(257, 4);
            this.AboutEdit.Margin = new System.Windows.Forms.Padding(0);
            this.AboutEdit.Name = "AboutEdit";
            this.AboutEdit.Size = new System.Drawing.Size(70, 75);
            this.AboutEdit.TabIndex = 7;
            this.AboutEdit.Text = "✎";
            this.AboutEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AboutEdit.Click += new System.EventHandler(this.OnEditClick);
            // 
            // AboutInfoLabel
            // 
            this.AboutInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.AboutInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AboutInfoLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutInfoLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AboutInfoLabel.Location = new System.Drawing.Point(2, 376);
            this.AboutInfoLabel.Name = "AboutInfoLabel";
            this.AboutInfoLabel.Padding = new System.Windows.Forms.Padding(2, 8, 0, 0);
            this.AboutInfoLabel.Size = new System.Drawing.Size(331, 46);
            this.AboutInfoLabel.TabIndex = 24;
            this.AboutInfoLabel.Text = "About";
            this.AboutInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NamePanel
            // 
            this.NamePanel.AllBorderRadius = 30;
            this.NamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.NamePanel.BorderColor = System.Drawing.Color.Transparent;
            this.NamePanel.BorderMarginSize = 0;
            this.NamePanel.BottomLeftRadius = 30;
            this.NamePanel.BottomRight = 30;
            this.NamePanel.Controls.Add(this.NameEdit);
            this.NamePanel.Controls.Add(this.NameBox);
            this.NamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NamePanel.Location = new System.Drawing.Point(2, 312);
            this.NamePanel.Name = "NamePanel";
            this.NamePanel.Padding = new System.Windows.Forms.Padding(6);
            this.NamePanel.Size = new System.Drawing.Size(331, 64);
            this.NamePanel.TabIndex = 32;
            this.NamePanel.TopLeftRadius = 30;
            this.NamePanel.TopRightRadius = 30;
            // 
            // NameEdit
            // 
            this.NameEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.NameEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.NameEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(137)))), ((int)(((byte)(242)))));
            this.NameEdit.Location = new System.Drawing.Point(255, 6);
            this.NameEdit.Margin = new System.Windows.Forms.Padding(0);
            this.NameEdit.Name = "NameEdit";
            this.NameEdit.Size = new System.Drawing.Size(70, 52);
            this.NameEdit.TabIndex = 13;
            this.NameEdit.Text = "✎";
            this.NameEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameEdit.Click += new System.EventHandler(this.OnEditClick);
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(55)))), ((int)(((byte)(78)))));
            this.NameBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.NameBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.NameBox.Location = new System.Drawing.Point(6, 6);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(257, 52);
            this.NameBox.TabIndex = 12;
            this.NameBox.Text = "Name";
            this.NameBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameInfoLabel
            // 
            this.NameInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameInfoLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameInfoLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.NameInfoLabel.Location = new System.Drawing.Point(2, 266);
            this.NameInfoLabel.Name = "NameInfoLabel";
            this.NameInfoLabel.Padding = new System.Windows.Forms.Padding(2, 8, 0, 0);
            this.NameInfoLabel.Size = new System.Drawing.Size(331, 46);
            this.NameInfoLabel.TabIndex = 25;
            this.NameInfoLabel.Text = "Name";
            this.NameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProfilePanel
            // 
            this.ProfilePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.ProfilePanel.Controls.Add(this.ProfilePicture);
            this.ProfilePanel.Controls.Add(this.ProfileEditPanel);
            this.ProfilePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProfilePanel.Location = new System.Drawing.Point(2, 44);
            this.ProfilePanel.Name = "ProfilePanel";
            this.ProfilePanel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 3);
            this.ProfilePanel.Size = new System.Drawing.Size(331, 222);
            this.ProfilePanel.TabIndex = 30;
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(55)))), ((int)(((byte)(78)))));
            this.ProfilePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfilePicture.Image = global::ChatApplication.Properties.Resources.user__2_;
            this.ProfilePicture.Location = new System.Drawing.Point(4, 4);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(323, 190);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePicture.TabIndex = 6;
            this.ProfilePicture.TabStop = false;
            // 
            // ProfileEditPanel
            // 
            this.ProfileEditPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProfileEditPanel.Controls.Add(this.ProfileEdit);
            this.ProfileEditPanel.Controls.Add(this.GuideToChangeProfile);
            this.ProfileEditPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProfileEditPanel.Location = new System.Drawing.Point(4, 194);
            this.ProfileEditPanel.Name = "ProfileEditPanel";
            this.ProfileEditPanel.Padding = new System.Windows.Forms.Padding(2);
            this.ProfileEditPanel.Size = new System.Drawing.Size(323, 25);
            this.ProfileEditPanel.TabIndex = 7;
            // 
            // ProfileEdit
            // 
            this.ProfileEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ProfileEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.ProfileEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(137)))), ((int)(((byte)(242)))));
            this.ProfileEdit.Location = new System.Drawing.Point(250, 2);
            this.ProfileEdit.Margin = new System.Windows.Forms.Padding(0);
            this.ProfileEdit.Name = "ProfileEdit";
            this.ProfileEdit.Size = new System.Drawing.Size(71, 21);
            this.ProfileEdit.TabIndex = 9;
            this.ProfileEdit.Text = "✎";
            this.ProfileEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProfileEdit.Click += new System.EventHandler(this.ProfilePictureClick);
            // 
            // GuideToChangeProfile
            // 
            this.GuideToChangeProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(55)))), ((int)(((byte)(78)))));
            this.GuideToChangeProfile.Dock = System.Windows.Forms.DockStyle.Left;
            this.GuideToChangeProfile.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuideToChangeProfile.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GuideToChangeProfile.Location = new System.Drawing.Point(2, 2);
            this.GuideToChangeProfile.Name = "GuideToChangeProfile";
            this.GuideToChangeProfile.Size = new System.Drawing.Size(255, 21);
            this.GuideToChangeProfile.TabIndex = 8;
            this.GuideToChangeProfile.Text = "Click to change the profile \r\n";
            this.GuideToChangeProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfileInfoLabel
            // 
            this.ProfileInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProfileInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProfileInfoLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileInfoLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ProfileInfoLabel.Location = new System.Drawing.Point(2, 0);
            this.ProfileInfoLabel.Name = "ProfileInfoLabel";
            this.ProfileInfoLabel.Padding = new System.Windows.Forms.Padding(2, 8, 0, 0);
            this.ProfileInfoLabel.Size = new System.Drawing.Size(331, 44);
            this.ProfileInfoLabel.TabIndex = 29;
            this.ProfileInfoLabel.Text = "Profile";
            this.ProfileInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.TopPanel.Controls.Add(this.BackButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(348, 29);
            this.TopPanel.TabIndex = 25;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroudColor = System.Drawing.Color.Transparent;
            this.BackButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BackButton.BorderRadius1 = 10;
            this.BackButton.BorderSize1 = 0;
            this.BackButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(0, 0);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(42, 29);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "⌫";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.TextColor = System.Drawing.Color.White;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // MyProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "MyProfilePage";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Size = new System.Drawing.Size(350, 778);
            this.Load += new System.EventHandler(this.MyProfilePageLoad);
            this.MainPanel.ResumeLayout(false);
            this.ThemePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DarkTheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightTheme)).EndInit();
            this.EditPanel.ResumeLayout(false);
            this.EditPanel.PerformLayout();
            this.AboutPanel.ResumeLayout(false);
            this.NamePanel.ResumeLayout(false);
            this.ProfilePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.ProfileEditPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label ThemeInfoLabel;
        private System.Windows.Forms.Panel AboutPanel;
        private System.Windows.Forms.Label AboutEdit;
        private System.Windows.Forms.Label AboutInfoLabel;
        private System.Windows.Forms.Label NameInfoLabel;
        private System.Windows.Forms.Panel ProfilePanel;
        private System.Windows.Forms.Label ProfileInfoLabel;
        private System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.TextBox EditBox;
        private System.Windows.Forms.Label CancelLabel;
        private System.Windows.Forms.Label SaveLabel;
        private System.Windows.Forms.Label AboutBox;
        private System.Windows.Forms.PictureBox ProfilePicture;
        private System.Windows.Forms.Panel ProfileEditPanel;
        private System.Windows.Forms.Label ProfileEdit;
        private System.Windows.Forms.Label GuideToChangeProfile;
        private System.Windows.Forms.Panel TopPanel;
        private CustomPanel NamePanel;
        private System.Windows.Forms.Label NameEdit;
        private System.Windows.Forms.Label NameBox;
        private CustomPanel ThemePanel;
        private System.Windows.Forms.PictureBox DarkTheme;
        private System.Windows.Forms.Panel SpacePanel;
        private System.Windows.Forms.PictureBox LightTheme;
        private EllipseButton BackButton;
    }
}
