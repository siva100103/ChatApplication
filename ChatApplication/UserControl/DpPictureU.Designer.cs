namespace ChatApplication
{
    partial class DpPictureU
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
            this.addDpBtn = new ChatApplication.EllipseButton();
            this.dpPB = new ChatApplication.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dpPB)).BeginInit();
            this.SuspendLayout();
            // 
            // addDpBtn
            // 
            this.addDpBtn.BackColor = System.Drawing.Color.Transparent;
            this.addDpBtn.BackgroudColor = System.Drawing.Color.Transparent;
            this.addDpBtn.BorderColor = System.Drawing.Color.Transparent;
            this.addDpBtn.BorderRadius1 = 12;
            this.addDpBtn.BorderSize1 = 0;
            this.addDpBtn.FlatAppearance.BorderSize = 0;
            this.addDpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDpBtn.ForeColor = System.Drawing.Color.Wheat;
            this.addDpBtn.Image = global::ChatApplication.Properties.Resources.icons8_add_24__4_;
            this.addDpBtn.Location = new System.Drawing.Point(115, 104);
            this.addDpBtn.Name = "addDpBtn";
            this.addDpBtn.Size = new System.Drawing.Size(23, 24);
            this.addDpBtn.TabIndex = 1;
            this.addDpBtn.TextColor = System.Drawing.Color.Wheat;
            this.addDpBtn.UseVisualStyleBackColor = false;
            // 
            // dpPB
            // 
            this.dpPB.BackColor = System.Drawing.Color.Transparent;
            this.dpPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpPB.Image = global::ChatApplication.Properties.Resources.user__7_;
            this.dpPB.Location = new System.Drawing.Point(0, 0);
            this.dpPB.Name = "dpPB";
            this.dpPB.Padding = new System.Windows.Forms.Padding(4);
            this.dpPB.Size = new System.Drawing.Size(139, 129);
            this.dpPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dpPB.TabIndex = 0;
            this.dpPB.TabStop = false;
            // 
            // DpPictureU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addDpBtn);
            this.Controls.Add(this.dpPB);
            this.Name = "DpPictureU";
            this.Size = new System.Drawing.Size(139, 129);
            ((System.ComponentModel.ISupportInitialize)(this.dpPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPictureBox dpPB;
        private EllipseButton addDpBtn;
    }
}
