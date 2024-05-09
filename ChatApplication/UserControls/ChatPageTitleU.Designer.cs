namespace ChatApplication.UserControls
{
    partial class ChatPageTitleU
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.infoLB = new System.Windows.Forms.Label();
            this.nameLB = new System.Windows.Forms.Label();
            this.searchBtn = new ChatApplication.UserControls.EllipseButton();
            this.contactDpPicturePB = new ChatApplication.UserControls.CustomPictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactDpPicturePB)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(75, 6);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(509, 52);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.infoLB);
            this.panel2.Controls.Add(this.nameLB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.panel2.Size = new System.Drawing.Size(459, 44);
            this.panel2.TabIndex = 6;
            this.panel2.Click += new System.EventHandler(this.ChatPageTitleUClick);
            // 
            // infoLB
            // 
            this.infoLB.AutoSize = true;
            this.infoLB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.infoLB.Location = new System.Drawing.Point(3, 28);
            this.infoLB.Name = "infoLB";
            this.infoLB.Size = new System.Drawing.Size(105, 13);
            this.infoLB.TabIndex = 5;
            this.infoLB.Text = "Select the group info";
            this.infoLB.Click += new System.EventHandler(this.ChatPageTitleUClick);
            // 
            // nameLB
            // 
            this.nameLB.AutoSize = true;
            this.nameLB.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLB.Location = new System.Drawing.Point(3, 1);
            this.nameLB.Name = "nameLB";
            this.nameLB.Size = new System.Drawing.Size(45, 17);
            this.nameLB.TabIndex = 4;
            this.nameLB.Text = "label1";
            this.nameLB.Click += new System.EventHandler(this.ChatPageTitleUClick);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.Transparent;
            this.searchBtn.BackgroudColor = System.Drawing.Color.Transparent;
            this.searchBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.searchBtn.BorderRadius1 = 10;
            this.searchBtn.BorderSize1 = 0;
            this.searchBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchBtn.FlatAppearance.BorderSize = 0;
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.ForeColor = System.Drawing.Color.White;
            this.searchBtn.Image = global::ChatApplication.Properties.Resources.icons8_search_19;
            this.searchBtn.Location = new System.Drawing.Point(463, 4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(42, 44);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.TextColor = System.Drawing.Color.White;
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Visible = false;
            // 
            // contactDpPicturePB
            // 
            this.contactDpPicturePB.BackColor = System.Drawing.Color.LightGray;
            this.contactDpPicturePB.Dock = System.Windows.Forms.DockStyle.Left;
            this.contactDpPicturePB.Image = global::ChatApplication.Properties.Resources.icons8_guardian_40;
            this.contactDpPicturePB.Location = new System.Drawing.Point(6, 6);
            this.contactDpPicturePB.Name = "contactDpPicturePB";
            this.contactDpPicturePB.Size = new System.Drawing.Size(69, 52);
            this.contactDpPicturePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.contactDpPicturePB.TabIndex = 0;
            this.contactDpPicturePB.TabStop = false;
            this.contactDpPicturePB.Click += new System.EventHandler(this.ChatPageTitleUClick);
            // 
            // ChatPageTitleU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contactDpPicturePB);
            this.Name = "ChatPageTitleU";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(590, 64);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactDpPicturePB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPictureBox contactDpPicturePB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label infoLB;
        private System.Windows.Forms.Label nameLB;
        private EllipseButton searchBtn;
    }
}
