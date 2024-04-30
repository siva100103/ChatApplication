﻿namespace ChatApplication
{
    partial class MenuForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeleteLabel = new System.Windows.Forms.Label();
            this.CopyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteLabel
            // 
            this.DeleteLabel.BackColor = System.Drawing.Color.Transparent;
            this.DeleteLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteLabel.Location = new System.Drawing.Point(0, 0);
            this.DeleteLabel.Name = "DeleteLabel";
            this.DeleteLabel.Padding = new System.Windows.Forms.Padding(10, 4, 0, 0);
            this.DeleteLabel.Size = new System.Drawing.Size(125, 30);
            this.DeleteLabel.TabIndex = 3;
            this.DeleteLabel.Text = "Delete";
            this.DeleteLabel.Click += new System.EventHandler(this.DeleteLabelClick);
            this.DeleteLabel.MouseEnter += new System.EventHandler(this.MenuFormMouseEnter);
            this.DeleteLabel.MouseLeave += new System.EventHandler(this.MenuFormMouseLeave);
            // 
            // CopyLabel
            // 
            this.CopyLabel.BackColor = System.Drawing.Color.Transparent;
            this.CopyLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CopyLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyLabel.Location = new System.Drawing.Point(0, 30);
            this.CopyLabel.Name = "CopyLabel";
            this.CopyLabel.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.CopyLabel.Size = new System.Drawing.Size(125, 30);
            this.CopyLabel.TabIndex = 4;
            this.CopyLabel.Text = "Copy";
            this.CopyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CopyLabel.Click += new System.EventHandler(this.CopyLabel_Click);
            this.CopyLabel.MouseEnter += new System.EventHandler(this.MenuFormMouseEnter);
            this.CopyLabel.MouseLeave += new System.EventHandler(this.MenuFormMouseLeave);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(230)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(125, 106);
            this.Controls.Add(this.CopyLabel);
            this.Controls.Add(this.DeleteLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DeleteLabel;
        private System.Windows.Forms.Label CopyLabel;
    }
}