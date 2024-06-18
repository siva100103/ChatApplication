using ChatApplication.UserControls;
using System.Drawing;
using System.Windows.Forms;

namespace ChatApplication.Forms
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
            MessageLB = new Label();
            ellipseControl2 = new EllipseControl();
            SuspendLayout();
            // 
            // MessageLB
            // 
            MessageLB.AutoSize = true;
            MessageLB.Dock = DockStyle.Fill;
            MessageLB.FlatStyle = FlatStyle.Flat;
            MessageLB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageLB.ForeColor = Color.FromArgb(25, 26, 26);
            MessageLB.ImageAlign = ContentAlignment.TopCenter;
            MessageLB.Location = new Point(9, 7);
            MessageLB.Margin = new Padding(2, 0, 2, 0);
            MessageLB.Name = "MessageLB";
            MessageLB.Padding = new Padding(5, 3, 5, 3);
            MessageLB.Size = new Size(63, 21);
            MessageLB.TabIndex = 0;
            MessageLB.Text = "Message";
            MessageLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ellipseControl2
            // 
            ellipseControl2.CornerRadius = 7;
            ellipseControl2.TargetControl = this;
            // 
            // HoverMessageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(148, 41);
            Controls.Add(MessageLB);
            DoubleBuffered = true;
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "HoverMessageForm";
            Padding = new Padding(9, 7, 9, 12);
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            Text = "HoverMessageForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MessageLB;

        private EllipseControl ellipseControl2;
    }
}