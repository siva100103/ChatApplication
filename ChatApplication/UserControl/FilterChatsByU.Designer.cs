namespace ChatApplication
{
    partial class FilterChatsByU
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
            this.draftsBtn = new ChatApplication.EllipseButton();
            this.groupsBtn = new ChatApplication.EllipseButton();
            this.nonContactBtn = new ChatApplication.EllipseButton();
            this.contactBtn = new ChatApplication.EllipseButton();
            this.unreadBtn = new ChatApplication.EllipseButton();
            this.panel1.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 15);
            this.panel1.Size = new System.Drawing.Size(217, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(169)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(15, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Chats By";
            // 
            // draftsBtn
            // 
            this.draftsBtn.BackColor = System.Drawing.Color.Transparent;
            this.draftsBtn.BackgroudColor = System.Drawing.Color.Transparent;
            this.draftsBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.draftsBtn.BorderRadius1 = 10;
            this.draftsBtn.BorderSize1 = 0;
            this.draftsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.draftsBtn.FlatAppearance.BorderSize = 0;
            this.draftsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.draftsBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.draftsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.draftsBtn.Image = global::ChatApplication.Properties.Resources.pen;
            this.draftsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.draftsBtn.Location = new System.Drawing.Point(0, 197);
            this.draftsBtn.Name = "draftsBtn";
            this.draftsBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.draftsBtn.Size = new System.Drawing.Size(217, 40);
            this.draftsBtn.TabIndex = 5;
            this.draftsBtn.Text = "   Drafts";
            this.draftsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.draftsBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.draftsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.draftsBtn.UseVisualStyleBackColor = false;
            this.draftsBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.draftsBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // groupsBtn
            // 
            this.groupsBtn.BackColor = System.Drawing.Color.Transparent;
            this.groupsBtn.BackgroudColor = System.Drawing.Color.Transparent;
            this.groupsBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.groupsBtn.BorderRadius1 = 10;
            this.groupsBtn.BorderSize1 = 0;
            this.groupsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupsBtn.FlatAppearance.BorderSize = 0;
            this.groupsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupsBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.groupsBtn.Image = global::ChatApplication.Properties.Resources.user;
            this.groupsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupsBtn.Location = new System.Drawing.Point(0, 157);
            this.groupsBtn.Name = "groupsBtn";
            this.groupsBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.groupsBtn.Size = new System.Drawing.Size(217, 40);
            this.groupsBtn.TabIndex = 4;
            this.groupsBtn.Text = "   Groups";
            this.groupsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupsBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.groupsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.groupsBtn.UseVisualStyleBackColor = false;
            this.groupsBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.groupsBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // nonContactBtn
            // 
            this.nonContactBtn.BackColor = System.Drawing.Color.Transparent;
            this.nonContactBtn.BackgroudColor = System.Drawing.Color.Transparent;
            this.nonContactBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.nonContactBtn.BorderRadius1 = 10;
            this.nonContactBtn.BorderSize1 = 0;
            this.nonContactBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.nonContactBtn.FlatAppearance.BorderSize = 0;
            this.nonContactBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nonContactBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonContactBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.nonContactBtn.Image = global::ChatApplication.Properties.Resources.block_user__1_;
            this.nonContactBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nonContactBtn.Location = new System.Drawing.Point(0, 117);
            this.nonContactBtn.Name = "nonContactBtn";
            this.nonContactBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.nonContactBtn.Size = new System.Drawing.Size(217, 40);
            this.nonContactBtn.TabIndex = 3;
            this.nonContactBtn.Text = "   Non-Contact";
            this.nonContactBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nonContactBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.nonContactBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.nonContactBtn.UseVisualStyleBackColor = false;
            this.nonContactBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.nonContactBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // contactBtn
            // 
            this.contactBtn.BackColor = System.Drawing.Color.Transparent;
            this.contactBtn.BackgroudColor = System.Drawing.Color.Transparent;
            this.contactBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.contactBtn.BorderRadius1 = 10;
            this.contactBtn.BorderSize1 = 0;
            this.contactBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactBtn.FlatAppearance.BorderSize = 0;
            this.contactBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contactBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.contactBtn.Image = global::ChatApplication.Properties.Resources.icons8_contact_26;
            this.contactBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactBtn.Location = new System.Drawing.Point(0, 77);
            this.contactBtn.Name = "contactBtn";
            this.contactBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.contactBtn.Size = new System.Drawing.Size(217, 40);
            this.contactBtn.TabIndex = 2;
            this.contactBtn.Text = "   Contact";
            this.contactBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.contactBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.contactBtn.UseVisualStyleBackColor = false;
            this.contactBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.contactBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // unreadBtn
            // 
            this.unreadBtn.BackColor = System.Drawing.Color.Transparent;
            this.unreadBtn.BackgroudColor = System.Drawing.Color.Transparent;
            this.unreadBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.unreadBtn.BorderRadius1 = 10;
            this.unreadBtn.BorderSize1 = 0;
            this.unreadBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.unreadBtn.FlatAppearance.BorderSize = 0;
            this.unreadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unreadBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unreadBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.unreadBtn.Image = global::ChatApplication.Properties.Resources.chat;
            this.unreadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unreadBtn.Location = new System.Drawing.Point(0, 37);
            this.unreadBtn.Name = "unreadBtn";
            this.unreadBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.unreadBtn.Size = new System.Drawing.Size(217, 40);
            this.unreadBtn.TabIndex = 1;
            this.unreadBtn.Text = "   Unread";
            this.unreadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unreadBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.unreadBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.unreadBtn.UseVisualStyleBackColor = false;
            this.unreadBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.unreadBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // FilterChatsByU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.draftsBtn);
            this.Controls.Add(this.groupsBtn);
            this.Controls.Add(this.nonContactBtn);
            this.Controls.Add(this.contactBtn);
            this.Controls.Add(this.unreadBtn);
            this.Controls.Add(this.panel1);
            this.Name = "FilterChatsByU";
            this.Size = new System.Drawing.Size(217, 238);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EllipseControl ellipseControl1;
        private EllipseButton unreadBtn;
        private System.Windows.Forms.Panel panel1;
        private EllipseButton draftsBtn;
        private EllipseButton groupsBtn;
        private EllipseButton nonContactBtn;
        private EllipseButton contactBtn;
        private System.Windows.Forms.Label label1;
    }
}
