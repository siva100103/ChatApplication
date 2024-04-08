namespace ChatApplication
{
    partial class ContactListU
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
            this.ellipseControl1 = new ChatApplication.EllipseControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.customSearchBox1 = new ChatApplication.CustomSearchBox();
            this.contactLoadP = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ellipseControl1
            // 
            this.ellipseControl1.CornerRadius = 10;
            this.ellipseControl1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.panel1.Size = new System.Drawing.Size(306, 48);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Chat";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.customSearchBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 50);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6);
            this.panel2.Size = new System.Drawing.Size(306, 56);
            this.panel2.TabIndex = 1;
            // 
            // customSearchBox1
            // 
            this.customSearchBox1.BackColor = System.Drawing.Color.White;
            this.customSearchBox1.BorderColor = System.Drawing.Color.Black;
            this.customSearchBox1.BorderSize = 4;
            this.customSearchBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customSearchBox1.IsSearchIconVisible = false;
            this.customSearchBox1.IsUnderLine = true;
            this.customSearchBox1.Location = new System.Drawing.Point(6, 6);
            this.customSearchBox1.Name = "customSearchBox1";
            this.customSearchBox1.Padding = new System.Windows.Forms.Padding(15, 7, 7, 7);
            this.customSearchBox1.PlaceholderText = "Search Name";
            this.customSearchBox1.Size = new System.Drawing.Size(294, 44);
            this.customSearchBox1.TabIndex = 1;
            // 
            // contactLoadP
            // 
            this.contactLoadP.AutoScroll = true;
            this.contactLoadP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactLoadP.Location = new System.Drawing.Point(2, 106);
            this.contactLoadP.Name = "contactLoadP";
            this.contactLoadP.Padding = new System.Windows.Forms.Padding(4);
            this.contactLoadP.Size = new System.Drawing.Size(306, 245);
            this.contactLoadP.TabIndex = 2;
            // 
            // ContactListU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.contactLoadP);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ContactListU";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(310, 353);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EllipseControl ellipseControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel contactLoadP;
        private CustomSearchBox customSearchBox1;
    }
}
