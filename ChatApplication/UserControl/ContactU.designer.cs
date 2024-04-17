using ChatApplication;

namespace WindowsFormsApp3
{
    partial class ContactU
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
            this.mainP = new System.Windows.Forms.Panel();
            this.timeP = new System.Windows.Forms.Panel();
            this.timeLB = new System.Windows.Forms.Label();
            this.contactInformationP = new ChatApplication.CustomPanel();
            this.statusIndicator1 = new ChatApplication.StatusIndicator();
            this.contactNameLB = new System.Windows.Forms.Label();
            this.lastMessageLB = new System.Windows.Forms.Label();
            this.bendingMessages1 = new ChatApplication.BendingMessages();
            this.dpPictureBox = new ChatApplication.CustomPictureBox();
            this.mainP.SuspendLayout();
            this.timeP.SuspendLayout();
            this.contactInformationP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainP
            // 
            this.mainP.BackColor = System.Drawing.Color.Transparent;
            this.mainP.Controls.Add(this.contactInformationP);
            this.mainP.Controls.Add(this.timeP);
            this.mainP.Controls.Add(this.dpPictureBox);
            this.mainP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainP.Location = new System.Drawing.Point(2, 2);
            this.mainP.Name = "mainP";
            this.mainP.Padding = new System.Windows.Forms.Padding(5);
            this.mainP.Size = new System.Drawing.Size(322, 60);
            this.mainP.TabIndex = 0;
            // 
            // timeP
            // 
            this.timeP.BackColor = System.Drawing.Color.Transparent;
            this.timeP.Controls.Add(this.bendingMessages1);
            this.timeP.Controls.Add(this.timeLB);
            this.timeP.Dock = System.Windows.Forms.DockStyle.Right;
            this.timeP.Location = new System.Drawing.Point(253, 5);
            this.timeP.MinimumSize = new System.Drawing.Size(64, 48);
            this.timeP.Name = "timeP";
            this.timeP.Padding = new System.Windows.Forms.Padding(1);
            this.timeP.Size = new System.Drawing.Size(64, 50);
            this.timeP.TabIndex = 4;
            // 
            // timeLB
            // 
            this.timeLB.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeLB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.timeLB.Location = new System.Drawing.Point(1, 1);
            this.timeLB.Name = "timeLB";
            this.timeLB.Size = new System.Drawing.Size(62, 13);
            this.timeLB.TabIndex = 3;
            this.timeLB.Text = "00:00";
            this.timeLB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contactInformationP
            // 
            this.contactInformationP.AllBorderRadius = 1;
            this.contactInformationP.BackColor = System.Drawing.Color.Transparent;
            this.contactInformationP.BorderColor = System.Drawing.Color.Transparent;
            this.contactInformationP.BorderMarginSize = 0;
            this.contactInformationP.BottomLeftRadius = 1;
            this.contactInformationP.BottomRight = 1;
            this.contactInformationP.Controls.Add(this.statusIndicator1);
            this.contactInformationP.Controls.Add(this.contactNameLB);
            this.contactInformationP.Controls.Add(this.lastMessageLB);
            this.contactInformationP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactInformationP.Location = new System.Drawing.Point(63, 5);
            this.contactInformationP.Margin = new System.Windows.Forms.Padding(0);
            this.contactInformationP.Name = "contactInformationP";
            this.contactInformationP.Padding = new System.Windows.Forms.Padding(2);
            this.contactInformationP.Size = new System.Drawing.Size(190, 50);
            this.contactInformationP.TabIndex = 5;
            this.contactInformationP.TopLeftRadius = 1;
            this.contactInformationP.TopRightRadius = 1;
            // 
            // statusIndicator1
            // 
            this.statusIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.statusIndicator1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.statusIndicator1.Location = new System.Drawing.Point(6, 29);
            this.statusIndicator1.Name = "statusIndicator1";
            this.statusIndicator1.Size = new System.Drawing.Size(10, 10);
            this.statusIndicator1.TabIndex = 4;
            // 
            // contactNameLB
            // 
            this.contactNameLB.AutoSize = true;
            this.contactNameLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.contactNameLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNameLB.Location = new System.Drawing.Point(2, 2);
            this.contactNameLB.Name = "contactNameLB";
            this.contactNameLB.Size = new System.Drawing.Size(57, 21);
            this.contactNameLB.TabIndex = 1;
            this.contactNameLB.Text = "label1";
            // 
            // lastMessageLB
            // 
            this.lastMessageLB.AutoSize = true;
            this.lastMessageLB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lastMessageLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lastMessageLB.Location = new System.Drawing.Point(2, 35);
            this.lastMessageLB.Name = "lastMessageLB";
            this.lastMessageLB.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lastMessageLB.Size = new System.Drawing.Size(4, 13);
            this.lastMessageLB.TabIndex = 2;
            // 
            // bendingMessages1
            // 
            this.bendingMessages1.Location = new System.Drawing.Point(23, 19);
            this.bendingMessages1.Name = "bendingMessages1";
            this.bendingMessages1.Size = new System.Drawing.Size(20, 20);
            this.bendingMessages1.TabIndex = 4;
            // 
            // dpPictureBox
            // 
            this.dpPictureBox.BackColor = System.Drawing.Color.White;
            this.dpPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpPictureBox.Location = new System.Drawing.Point(5, 5);
            this.dpPictureBox.Name = "dpPictureBox";
            this.dpPictureBox.Size = new System.Drawing.Size(58, 50);
            this.dpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dpPictureBox.TabIndex = 0;
            this.dpPictureBox.TabStop = false;
            // 
            // ContactU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.mainP);
            this.Name = "ContactU";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(326, 64);
            this.mainP.ResumeLayout(false);
            this.timeP.ResumeLayout(false);
            this.contactInformationP.ResumeLayout(false);
            this.contactInformationP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainP;
        private CustomPanel contactInformationP;
        private System.Windows.Forms.Label contactNameLB;
        private System.Windows.Forms.Label lastMessageLB;
        private System.Windows.Forms.Panel timeP;
        private System.Windows.Forms.Label timeLB;
        private CustomPictureBox dpPictureBox;
        private StatusIndicator statusIndicator1;
        private BendingMessages bendingMessages1;
    }
}
