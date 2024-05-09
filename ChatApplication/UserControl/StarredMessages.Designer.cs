namespace ChatApplication
{
    partial class StarredMessages
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
            this.messageLB = new System.Windows.Forms.Label();
            this.ChatUBottomP = new System.Windows.Forms.Panel();
            this.FromLabel = new System.Windows.Forms.Label();
            this.FromIndicateLabel = new System.Windows.Forms.Label();
            this.StarIcon = new System.Windows.Forms.PictureBox();
            this.ChatUBottomP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StarIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // messageLB
            // 
            this.messageLB.AutoSize = true;
            this.messageLB.BackColor = System.Drawing.Color.Transparent;
            this.messageLB.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageLB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLB.Location = new System.Drawing.Point(10, 2);
            this.messageLB.Margin = new System.Windows.Forms.Padding(0);
            this.messageLB.Name = "messageLB";
            this.messageLB.Size = new System.Drawing.Size(22, 19);
            this.messageLB.TabIndex = 1;
            this.messageLB.Text = "Hi";
            // 
            // ChatUBottomP
            // 
            this.ChatUBottomP.BackColor = System.Drawing.Color.Transparent;
            this.ChatUBottomP.Controls.Add(this.FromLabel);
            this.ChatUBottomP.Controls.Add(this.FromIndicateLabel);
            this.ChatUBottomP.Controls.Add(this.StarIcon);
            this.ChatUBottomP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ChatUBottomP.Location = new System.Drawing.Point(10, 40);
            this.ChatUBottomP.Margin = new System.Windows.Forms.Padding(2);
            this.ChatUBottomP.MinimumSize = new System.Drawing.Size(0, 12);
            this.ChatUBottomP.Name = "ChatUBottomP";
            this.ChatUBottomP.Padding = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.ChatUBottomP.Size = new System.Drawing.Size(184, 15);
            this.ChatUBottomP.TabIndex = 2;
            // 
            // FromLabel
            // 
            this.FromLabel.CausesValidation = false;
            this.FromLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FromLabel.Font = new System.Drawing.Font("Microsoft YaHei", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(249)))));
            this.FromLabel.Location = new System.Drawing.Point(45, 1);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(116, 12);
            this.FromLabel.TabIndex = 3;
            this.FromLabel.Text = "Mathan\r\n";
            this.FromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FromIndicateLabel
            // 
            this.FromIndicateLabel.CausesValidation = false;
            this.FromIndicateLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FromIndicateLabel.Font = new System.Drawing.Font("Microsoft YaHei", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromIndicateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(249)))));
            this.FromIndicateLabel.Location = new System.Drawing.Point(0, 1);
            this.FromIndicateLabel.Name = "FromIndicateLabel";
            this.FromIndicateLabel.Size = new System.Drawing.Size(45, 12);
            this.FromIndicateLabel.TabIndex = 2;
            this.FromIndicateLabel.Text = "From  :-";
            // 
            // StarIcon
            // 
            this.StarIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.StarIcon.Image = global::ChatApplication.Properties.Resources.icons8_star_48;
            this.StarIcon.Location = new System.Drawing.Point(161, 1);
            this.StarIcon.Margin = new System.Windows.Forms.Padding(1);
            this.StarIcon.Name = "StarIcon";
            this.StarIcon.Size = new System.Drawing.Size(20, 12);
            this.StarIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StarIcon.TabIndex = 1;
            this.StarIcon.TabStop = false;
            // 
            // StarredMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChatUBottomP);
            this.Controls.Add(this.messageLB);
            this.Name = "StarredMessages";
            this.Padding = new System.Windows.Forms.Padding(10, 2, 0, 0);
            this.Size = new System.Drawing.Size(194, 55);
            this.Load += new System.EventHandler(this.StarredMessagesLoad);
            this.ChatUBottomP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StarIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLB;
        private System.Windows.Forms.Panel ChatUBottomP;
        private System.Windows.Forms.PictureBox StarIcon;
        private System.Windows.Forms.Label FromIndicateLabel;
        private System.Windows.Forms.Label FromLabel;
    }
}
