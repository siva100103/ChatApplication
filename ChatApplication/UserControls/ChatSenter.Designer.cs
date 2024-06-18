namespace ChatApplication.UserControls
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
            MainPanel = new System.Windows.Forms.Panel();
            TextArea = new System.Windows.Forms.RichTextBox();
            FileShareIcon = new System.Windows.Forms.PictureBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            SendButton = new System.Windows.Forms.PictureBox();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FileShareIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SendButton).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = System.Drawing.Color.Transparent;
            MainPanel.Controls.Add(TextArea);
            MainPanel.Controls.Add(FileShareIcon);
            MainPanel.Controls.Add(pictureBox1);
            MainPanel.Controls.Add(SendButton);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MainPanel.Name = "MainPanel";
            MainPanel.Padding = new System.Windows.Forms.Padding(2);
            MainPanel.Size = new System.Drawing.Size(607, 46);
            MainPanel.TabIndex = 6;
            // 
            // TextArea
            // 
            TextArea.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
            TextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            TextArea.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            TextArea.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            TextArea.Location = new System.Drawing.Point(116, 2);
            TextArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TextArea.Name = "TextArea";
            TextArea.Size = new System.Drawing.Size(431, 42);
            TextArea.TabIndex = 2;
            TextArea.Text = " Type a message";
            TextArea.MouseClick += TextAreaMouseClick;
            TextArea.TextChanged += TextAreaTextChanged;
            TextArea.KeyDown += TextAreaKeyDown;
            // 
            // FileShareIcon
            // 
            FileShareIcon.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
            FileShareIcon.Dock = System.Windows.Forms.DockStyle.Left;
            FileShareIcon.Image = Properties.Resources.icons8_paper_clip_48_black;
            FileShareIcon.Location = new System.Drawing.Point(60, 2);
            FileShareIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FileShareIcon.Name = "FileShareIcon";
            FileShareIcon.Size = new System.Drawing.Size(56, 42);
            FileShareIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            FileShareIcon.TabIndex = 1;
            FileShareIcon.TabStop = false;
            FileShareIcon.Visible = false;
            FileShareIcon.Click += FileShareIconClick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            pictureBox1.Image = Properties.Resources.icons8_happy_30;
            pictureBox1.Location = new System.Drawing.Point(2, 2);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(58, 42);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // SendButton
            // 
            SendButton.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
            SendButton.Dock = System.Windows.Forms.DockStyle.Right;
            SendButton.Image = Properties.Resources.icons8_paper_plane_50__2_;
            SendButton.Location = new System.Drawing.Point(547, 2);
            SendButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SendButton.Name = "SendButton";
            SendButton.Size = new System.Drawing.Size(58, 42);
            SendButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            SendButton.TabIndex = 3;
            SendButton.TabStop = false;
            SendButton.Click += SendButtonClick;
            // 
            // ChatSenter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
            Controls.Add(MainPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ChatSenter";
            Size = new System.Drawing.Size(607, 46);
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FileShareIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)SendButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.RichTextBox TextArea;
        private System.Windows.Forms.PictureBox FileShareIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox SendButton;
    }
}
