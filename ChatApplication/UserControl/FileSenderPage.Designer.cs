﻿namespace ChatApplication
{
    partial class FileSenderPage
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
            this.FileNamePanel = new System.Windows.Forms.Panel();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.PreviewPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SendButton = new System.Windows.Forms.PictureBox();
            this.Chat = new ChatApplication.ChatSenter();
            this.CloseButton = new ChatApplication.HoverButton();
            this.FileNamePanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).BeginInit();
            this.SuspendLayout();
            // 
            // FileNamePanel
            // 
            this.FileNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.FileNamePanel.Controls.Add(this.FileNameLabel);
            this.FileNamePanel.Controls.Add(this.CloseButton);
            this.FileNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileNamePanel.Location = new System.Drawing.Point(0, 0);
            this.FileNamePanel.Name = "FileNamePanel";
            this.FileNamePanel.Size = new System.Drawing.Size(482, 55);
            this.FileNamePanel.TabIndex = 0;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(44, 0);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(438, 55);
            this.FileNameLabel.TabIndex = 10;
            this.FileNameLabel.Text = "File Name";
            this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviewPanel
            // 
            this.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewPanel.Location = new System.Drawing.Point(0, 55);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Size = new System.Drawing.Size(482, 340);
            this.PreviewPanel.TabIndex = 1;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.Chat);
            this.BottomPanel.Controls.Add(this.SendButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 395);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(482, 42);
            this.BottomPanel.TabIndex = 2;
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(133)))));
            this.SendButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SendButton.Image = global::ChatApplication.Properties.Resources.send__3_;
            this.SendButton.Location = new System.Drawing.Point(438, 0);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(44, 42);
            this.SendButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SendButton.TabIndex = 4;
            this.SendButton.TabStop = false;
            this.SendButton.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // Chat
            // 
            this.Chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chat.FileShareIconVisibility = false;
            this.Chat.Location = new System.Drawing.Point(0, 0);
            this.Chat.Name = "Chat";
            this.Chat.SendButtonVisibility = false;
            this.Chat.Size = new System.Drawing.Size(438, 42);
            this.Chat.TabIndex = 3;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroudColor = System.Drawing.Color.Transparent;
            this.CloseButton.BorderColor = System.Drawing.Color.Transparent;
            this.CloseButton.BorderRadius1 = 10;
            this.CloseButton.BorderSize1 = 0;
            this.CloseButton.ButtonSideHoverlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CloseButton.EndPoint = -3;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Image = global::ChatApplication.Properties.Resources.icons8_x_48;
            this.CloseButton.IsFormUp = false;
            this.CloseButton.IsSelected = false;
            this.CloseButton.Location = new System.Drawing.Point(0, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(44, 55);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.TextColor = System.Drawing.Color.White;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // FileSenderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.PreviewPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.FileNamePanel);
            this.Name = "FileSenderPage";
            this.Size = new System.Drawing.Size(482, 437);
            this.FileNamePanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FileNamePanel;
        private HoverButton CloseButton;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Panel PreviewPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private ChatSenter Chat;
        private System.Windows.Forms.PictureBox SendButton;
    }
}