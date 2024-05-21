namespace ChatApplication.UserControls
{
    partial class FileMessage
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
            this.MainPanel = new ChatApplication.UserControls.CustomPanel();
            this.PicturePanel = new System.Windows.Forms.Panel();
            this.FilePicture = new System.Windows.Forms.PictureBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.PicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.AllBorderRadius = 20;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.BorderColor = System.Drawing.Color.Transparent;
            this.MainPanel.BorderMarginSize = 0;
            this.MainPanel.BottomLeftRadius = 20;
            this.MainPanel.BottomRight = 20;
            this.MainPanel.Controls.Add(this.PicturePanel);
            this.MainPanel.Controls.Add(this.FileNameLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(98, 114);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.TopLeftRadius = 20;
            this.MainPanel.TopRightRadius = 20;
            // 
            // PicturePanel
            // 
            this.PicturePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.PicturePanel.Controls.Add(this.FilePicture);
            this.PicturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicturePanel.Location = new System.Drawing.Point(0, 0);
            this.PicturePanel.Name = "PicturePanel";
            this.PicturePanel.Padding = new System.Windows.Forms.Padding(10);
            this.PicturePanel.Size = new System.Drawing.Size(98, 91);
            this.PicturePanel.TabIndex = 3;
            // 
            // FilePicture
            // 
            this.FilePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.FilePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilePicture.Image = global::ChatApplication.Properties.Resources.icons8_file_64;
            this.FilePicture.Location = new System.Drawing.Point(10, 10);
            this.FilePicture.Name = "FilePicture";
            this.FilePicture.Size = new System.Drawing.Size(78, 71);
            this.FilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FilePicture.TabIndex = 1;
            this.FilePicture.TabStop = false;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.FileNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(0, 91);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(98, 23);
            this.FileNameLabel.TabIndex = 2;
            this.FileNameLabel.Text = "label1";
            this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MainPanel);
            this.Name = "FileMessage";
            this.Size = new System.Drawing.Size(98, 114);
            this.Load += new System.EventHandler(this.FileMessageLoad);
            this.MainPanel.ResumeLayout(false);
            this.PicturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPanel MainPanel;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Panel PicturePanel;
        private System.Windows.Forms.PictureBox FilePicture;
    }
}
