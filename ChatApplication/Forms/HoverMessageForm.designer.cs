using System.Drawing;
using System.Windows.Forms;

namespace ChatApplication
{
    partial class HoverMessageForm
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
            this.MessageLB = new System.Windows.Forms.Label();
            this.ellipseControl2 = new ChatApplication.EllipseControl();
            this.SuspendLayout();
            // 
            // MessageLB
            // 
            this.MessageLB.AutoSize = true;
            this.MessageLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MessageLB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.MessageLB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MessageLB.Location = new System.Drawing.Point(9, 7);
            this.MessageLB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageLB.Name = "MessageLB";
            this.MessageLB.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MessageLB.Size = new System.Drawing.Size(63, 21);
            this.MessageLB.TabIndex = 0;
            this.MessageLB.Text = "Message";
            this.MessageLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ellipseControl2
            // 
            this.ellipseControl2.CornerRadius = 7;
            this.ellipseControl2.TargetControl = this;
            // 
            // HoverMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(148, 41);
            this.Controls.Add(this.MessageLB);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HoverMessageForm";
            this.Padding = new System.Windows.Forms.Padding(9, 7, 9, 12);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "HoverMessageForm";
            this.Load += new System.EventHandler(this.HoverMessageFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label MessageLB;
       
        private EllipseControl ellipseControl2;
    }
}