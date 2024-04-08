namespace ChatApplication
{
    partial class ContactSimpleU
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
            this.dpPictureBox = new ChatApplication.CustomPictureBox();
            this.nameLB = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Panel();
            this.ellipseControl1 = new ChatApplication.EllipseControl();
            ((System.ComponentModel.ISupportInitialize)(this.dpPictureBox)).BeginInit();
            this.labelP.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpPictureBox
            // 
            this.dpPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpPictureBox.Image = global::ChatApplication.Properties.Resources.profile_user;
            this.dpPictureBox.Location = new System.Drawing.Point(2, 2);
            this.dpPictureBox.Name = "dpPictureBox";
            this.dpPictureBox.Size = new System.Drawing.Size(36, 35);
            this.dpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dpPictureBox.TabIndex = 0;
            this.dpPictureBox.TabStop = false;
            this.dpPictureBox.Click += new System.EventHandler(this.ContactSimpleUClick);
            // 
            // nameLB
            // 
            this.nameLB.AutoSize = true;
            this.nameLB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLB.Location = new System.Drawing.Point(59, 10);
            this.nameLB.Name = "nameLB";
            this.nameLB.Size = new System.Drawing.Size(44, 17);
            this.nameLB.TabIndex = 1;
            this.nameLB.Text = "Name";
            this.nameLB.Click += new System.EventHandler(this.ContactSimpleUClick);
            // 
            // labelP
            // 
            this.labelP.Controls.Add(this.nameLB);
            this.labelP.Location = new System.Drawing.Point(50, 4);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(187, 32);
            this.labelP.TabIndex = 2;
            this.labelP.Click += new System.EventHandler(this.ContactSimpleUClick);
            // 
            // ellipseControl1
            // 
            this.ellipseControl1.CornerRadius = 10;
            this.ellipseControl1.TargetControl = this;
            // 
            // ContactSimpleU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.dpPictureBox);
            this.Name = "ContactSimpleU";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(249, 39);
            this.Click += new System.EventHandler(this.ContactSimpleUClick);
            ((System.ComponentModel.ISupportInitialize)(this.dpPictureBox)).EndInit();
            this.labelP.ResumeLayout(false);
            this.labelP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPictureBox dpPictureBox;
        private System.Windows.Forms.Label nameLB;
        private System.Windows.Forms.Panel labelP;
        private EllipseControl ellipseControl1;
    }
}
