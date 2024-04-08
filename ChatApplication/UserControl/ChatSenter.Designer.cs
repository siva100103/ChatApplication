namespace ChatApplication
{
    partial class ChatSenter
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
            this.TextArea = new System.Windows.Forms.RichTextBox();
            this.FileShareIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SendButton = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileShareIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextArea);
            this.panel1.Controls.Add(this.FileShareIcon);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.SendButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 46);
            this.panel1.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.TextArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.TextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextArea.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.TextArea.Location = new System.Drawing.Point(100, 0);
            this.TextArea.Name = "richTextBox1";
            this.TextArea.Size = new System.Drawing.Size(370, 46);
            this.TextArea.TabIndex = 2;
            this.TextArea.Text = " Type a message";
            this.TextArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextAreaMouseClick);
            this.TextArea.TextChanged += new System.EventHandler(this.TextAreaTextChanged);
            // 
            // FileShareIcon
            // 
            this.FileShareIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.FileShareIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileShareIcon.Image = global::ChatApplication.Properties.Resources.paper_clip__3_;
            this.FileShareIcon.Location = new System.Drawing.Point(50, 0);
            this.FileShareIcon.Name = "FileShareIcon";
            this.FileShareIcon.Size = new System.Drawing.Size(50, 46);
            this.FileShareIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.FileShareIcon.TabIndex = 1;
            this.FileShareIcon.TabStop = false;
            this.FileShareIcon.Click += new System.EventHandler(this.FileShareIconClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ChatApplication.Properties.Resources.icons8_happy_30;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.SendButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SendButton.Image = global::ChatApplication.Properties.Resources.send__3_;
            this.SendButton.Location = new System.Drawing.Point(470, 0);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(50, 46);
            this.SendButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SendButton.TabIndex = 3;
            this.SendButton.TabStop = false;
            this.SendButton.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // ChatSenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ChatSenter";
            this.Size = new System.Drawing.Size(520, 46);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileShareIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox TextArea;
        private System.Windows.Forms.PictureBox FileShareIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox SendButton;
    }
}
