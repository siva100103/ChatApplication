
namespace ChatApplication.UserControls
{
    partial class HoverMessageU
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
            this.ellipseControl2 = new ChatApplication.UserControls.EllipseControl();
            this.MessageLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ellipseControl2
            // 
            this.ellipseControl2.CornerRadius = 7;
            this.ellipseControl2.TargetControl = this;
            // 
            // MessageLB
            // 
            this.MessageLB.AutoSize = true;
            this.MessageLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MessageLB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.MessageLB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MessageLB.Location = new System.Drawing.Point(0, 0);
            this.MessageLB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageLB.Name = "MessageLB";
            this.MessageLB.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MessageLB.Size = new System.Drawing.Size(61, 19);
            this.MessageLB.TabIndex = 1;
            this.MessageLB.Text = "Message";
            this.MessageLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HoverMessageU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MessageLB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HoverMessageU";
            this.Size = new System.Drawing.Size(127, 34);
            this.Load += new System.EventHandler(this.HoverMessageU_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EllipseControl ellipseControl2;
        private System.Windows.Forms.Label MessageLB;
    }
}
