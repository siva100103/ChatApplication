using ChatApplication.UserControls;

namespace ChatApplication.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.centerP = new ChatApplication.UserControls.CustomPanel();
            this.IPLabelIndicator = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.dpPictureU = new ChatApplication.UserControls.DpPictureU();
            this.SignUpButton = new ChatApplication.UserControls.EllipseButton();
            this.lastNameTB = new ChatApplication.UserControls.TextBoxU();
            this.firstNameTB = new ChatApplication.UserControls.TextBoxU();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.centerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.MainPanel.Controls.Add(this.centerP);
            this.MainPanel.Controls.Add(this.TopPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(753, 525);
            this.MainPanel.TabIndex = 1;
            // 
            // centerP
            // 
            this.centerP.AllBorderRadius = 25;
            this.centerP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.centerP.BackColor = System.Drawing.Color.White;
            this.centerP.BorderColor = System.Drawing.Color.Transparent;
            this.centerP.BorderMarginSize = 1;
            this.centerP.BottomLeftRadius = 25;
            this.centerP.BottomRight = 25;
            this.centerP.Controls.Add(this.IPLabelIndicator);
            this.centerP.Controls.Add(this.IPLabel);
            this.centerP.Controls.Add(this.dpPictureU);
            this.centerP.Controls.Add(this.SignUpButton);
            this.centerP.Controls.Add(this.lastNameTB);
            this.centerP.Controls.Add(this.firstNameTB);
            this.centerP.Location = new System.Drawing.Point(96, 53);
            this.centerP.Margin = new System.Windows.Forms.Padding(2);
            this.centerP.Name = "centerP";
            this.centerP.Size = new System.Drawing.Size(567, 426);
            this.centerP.TabIndex = 7;
            this.centerP.TopLeftRadius = 25;
            this.centerP.TopRightRadius = 25;
            // 
            // IPLabelIndicator
            // 
            this.IPLabelIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabelIndicator.Location = new System.Drawing.Point(144, 292);
            this.IPLabelIndicator.Name = "IPLabelIndicator";
            this.IPLabelIndicator.Size = new System.Drawing.Size(100, 27);
            this.IPLabelIndicator.TabIndex = 12;
            this.IPLabelIndicator.Text = "IpAddress:";
            this.IPLabelIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IPLabel
            // 
            this.IPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(263, 292);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(100, 27);
            this.IPLabel.TabIndex = 11;
            this.IPLabel.Text = "label1";
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpPictureU
            // 
            this.dpPictureU.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dpPictureU.DpPicturPath = "";
            this.dpPictureU.Location = new System.Drawing.Point(212, 20);
            this.dpPictureU.Margin = new System.Windows.Forms.Padding(2);
            this.dpPictureU.Name = "dpPictureU";
            this.dpPictureU.Size = new System.Drawing.Size(106, 92);
            this.dpPictureU.TabIndex = 9;
            // 
            // SignUpButton
            // 
            this.SignUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
            this.SignUpButton.BackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
            this.SignUpButton.BorderColor = System.Drawing.Color.White;
            this.SignUpButton.BorderRadius1 = 10;
            this.SignUpButton.BorderSize1 = 0;
            this.SignUpButton.FlatAppearance.BorderSize = 0;
            this.SignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUpButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpButton.ForeColor = System.Drawing.Color.White;
            this.SignUpButton.Location = new System.Drawing.Point(212, 342);
            this.SignUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(119, 42);
            this.SignUpButton.TabIndex = 8;
            this.SignUpButton.Text = "Sign Up";
            this.SignUpButton.TextColor = System.Drawing.Color.White;
            this.SignUpButton.UseVisualStyleBackColor = false;
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
            this.lastNameTB.PlaceholderLabelAtTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
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
            this.firstNameTB.PlaceholderLabelAtTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
            this.firstNameTB.PlaceholderText = "Firstname";
            this.firstNameTB.Size = new System.Drawing.Size(260, 54);
            this.firstNameTB.TabIndex = 5;
            this.firstNameTB.TabStop = false;
            this.firstNameTB.TextBoxDock = System.Windows.Forms.DockStyle.Fill;
            this.firstNameTB.TextBoxtext = "";
            this.firstNameTB.UseSystemPasswordChar = false;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(753, 122);
            this.TopPanel.TabIndex = 8;
            this.TopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanelPaint);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 525);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.MainPanel.ResumeLayout(false);
            this.centerP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private TextBoxU firstNameTB;
        private CustomPanel centerP;
        private EllipseButton SignUpButton;
        private TextBoxU lastNameTB;
        private DpPictureU dpPictureU;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label IPLabelIndicator;
        private System.Windows.Forms.Panel TopPanel;
    }
}