namespace ChatApplication
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.centerP = new ChatApplication.CustomPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpPictureU = new ChatApplication.DpPictureU();
            this.nextBtn = new ChatApplication.EllipseButton();
            this.lastNameTB = new ChatApplication.TextBoxU();
            this.firstNameTB = new ChatApplication.TextBoxU();
            this.ellipseControl1 = new ChatApplication.EllipseControl();
            this.BackTopColorPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.centerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.centerP);
            this.panel1.Controls.Add(this.BackTopColorPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
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
            this.centerP.Controls.Add(this.label2);
            this.centerP.Controls.Add(this.label1);
            this.centerP.Controls.Add(this.dpPictureU);
            this.centerP.Controls.Add(this.nextBtn);
            this.centerP.Controls.Add(this.lastNameTB);
            this.centerP.Controls.Add(this.firstNameTB);
            this.centerP.Location = new System.Drawing.Point(96, 53);
            this.centerP.Margin = new System.Windows.Forms.Padding(2);
            this.centerP.Name = "centerP";
            this.centerP.Size = new System.Drawing.Size(560, 438);
            this.centerP.TabIndex = 7;
            this.centerP.TopLeftRadius = 25;
            this.centerP.TopRightRadius = 25;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 27);
            this.label2.TabIndex = 12;
            this.label2.Text = "IpAddress:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
            this.nextBtn.BackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
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
            this.nextBtn.Text = "Sign Up";
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
            // ellipseControl1
            // 
            this.ellipseControl1.CornerRadius = 20;
            this.ellipseControl1.TargetControl = this.dpPictureU;
            // 
            // BackTopColorPanel
            // 
            this.BackTopColorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
            this.BackTopColorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BackTopColorPanel.Location = new System.Drawing.Point(0, 0);
            this.BackTopColorPanel.Name = "BackTopColorPanel";
            this.BackTopColorPanel.Size = new System.Drawing.Size(753, 122);
            this.BackTopColorPanel.TabIndex = 8;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 525);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            this.centerP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private TextBoxU firstNameTB;
        private CustomPanel centerP;
        private EllipseButton nextBtn;
        private TextBoxU lastNameTB;
        private EllipseControl ellipseControl1;
        private DpPictureU dpPictureU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel BackTopColorPanel;
    }
}