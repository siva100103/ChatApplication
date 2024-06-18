using System.Drawing;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
    partial class ChatU
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
            messageLB = new Label();
            ChatUBottomP = new Panel();
            timingLB = new Label();
            MessageSendIconPB = new PictureBox();
            ChatUBottomP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MessageSendIconPB).BeginInit();
            SuspendLayout();
            // 
            // messageLB
            // 
            messageLB.AutoSize = true;
            messageLB.Dock = DockStyle.Top;
            messageLB.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageLB.Location = new Point(12, 3);
            messageLB.Margin = new Padding(0);
            messageLB.Name = "messageLB";
            messageLB.Size = new Size(22, 19);
            messageLB.TabIndex = 0;
            messageLB.Text = "Hi";
            // 
            // ChatUBottomP
            // 
            ChatUBottomP.Controls.Add(timingLB);
            ChatUBottomP.Controls.Add(MessageSendIconPB);
            ChatUBottomP.Dock = DockStyle.Bottom;
            ChatUBottomP.Location = new Point(12, 37);
            ChatUBottomP.Margin = new Padding(2);
            ChatUBottomP.MinimumSize = new Size(0, 14);
            ChatUBottomP.Name = "ChatUBottomP";
            ChatUBottomP.Padding = new Padding(0, 1, 4, 2);
            ChatUBottomP.Size = new Size(134, 17);
            ChatUBottomP.TabIndex = 1;
            // 
            // timingLB
            // 
            timingLB.AutoSize = true;
            timingLB.Dock = DockStyle.Right;
            timingLB.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timingLB.ForeColor = SystemColors.ControlDarkDark;
            timingLB.Location = new Point(82, 1);
            timingLB.Margin = new Padding(2, 0, 2, 0);
            timingLB.Name = "timingLB";
            timingLB.Padding = new Padding(0, 0, 2, 3);
            timingLB.Size = new Size(29, 15);
            timingLB.TabIndex = 0;
            timingLB.Text = "12:00";
            timingLB.TextAlign = ContentAlignment.TopCenter;
            // 
            // MessageSendIconPB
            // 
            MessageSendIconPB.Dock = DockStyle.Right;
            MessageSendIconPB.Image = Properties.Resources.icons8_done_14__1_;
            MessageSendIconPB.Location = new Point(111, 1);
            MessageSendIconPB.Margin = new Padding(1);
            MessageSendIconPB.Name = "MessageSendIconPB";
            MessageSendIconPB.Size = new Size(19, 14);
            MessageSendIconPB.SizeMode = PictureBoxSizeMode.CenterImage;
            MessageSendIconPB.TabIndex = 1;
            MessageSendIconPB.TabStop = false;
            MessageSendIconPB.Visible = false;
            // 
            // ChatU
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(216, 252, 210);
            Controls.Add(messageLB);
            Controls.Add(ChatUBottomP);
            DoubleBuffered = true;
            Margin = new Padding(0);
            MinimumSize = new Size(105, 37);
            Name = "ChatU";
            Padding = new Padding(12, 3, 0, 0);
            Size = new Size(146, 54);
            Load += ChatULoad;
            Click += ChatUClick;
            ChatUBottomP.ResumeLayout(false);
            ChatUBottomP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MessageSendIconPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label messageLB;
        private Panel ChatUBottomP;
        private Label timingLB;
        private PictureBox MessageSendIconPB;
    }
}
