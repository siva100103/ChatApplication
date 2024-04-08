namespace ChatApplication
{
    partial class ContentForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.ProfilePicture = new ChatApplication.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(0, 215);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(400, 50);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "label1";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameLabel.MouseEnter += new System.EventHandler(this.ContactMouseEnter);
            this.NameLabel.MouseLeave += new System.EventHandler(this.ContactMouseLeave);
            // 
            // ContactLabel
            // 
            this.ContactLabel.BackColor = System.Drawing.Color.Transparent;
            this.ContactLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ContactLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactLabel.Location = new System.Drawing.Point(0, 265);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(400, 34);
            this.ContactLabel.TabIndex = 3;
            this.ContactLabel.Text = "label1";
            this.ContactLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ContactLabel.Click += new System.EventHandler(this.ContactLabelClick);
            this.ContactLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContactMouseDown);
            this.ContactLabel.MouseEnter += new System.EventHandler(this.ContactMouseEnter);
            this.ContactLabel.MouseLeave += new System.EventHandler(this.ContactMouseLeave);
            this.ContactLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ContactMouseUp);
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.BackColor = System.Drawing.Color.Transparent;
            this.ProfilePicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProfilePicture.Image = global::ChatApplication.Properties.Resources.user__2_;
            this.ProfilePicture.Location = new System.Drawing.Point(0, 0);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(400, 215);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ProfilePicture.TabIndex = 1;
            this.ProfilePicture.TabStop = false;
            // 
            // ContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.ContactLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ProfilePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContentForm";
            this.Text = "ContentForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPictureBox ProfilePicture;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ContactLabel;
    }
}