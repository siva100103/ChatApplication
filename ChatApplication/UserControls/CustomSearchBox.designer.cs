namespace ChatApplication.UserControls
{
    partial class CustomSearchBox
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
            this.TextBoxPanel = new System.Windows.Forms.Panel();
            this.textBox = new ChatApplication.UserControls.PlaceHolderTextBox();
            this.SearchIcon = new System.Windows.Forms.PictureBox();
            this.TextBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxPanel
            // 
            this.TextBoxPanel.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxPanel.Controls.Add(this.textBox);
            this.TextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxPanel.Location = new System.Drawing.Point(49, 4);
            this.TextBoxPanel.Name = "TextBoxPanel";
            this.TextBoxPanel.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.TextBoxPanel.Size = new System.Drawing.Size(257, 35);
            this.TextBoxPanel.TabIndex = 2;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.Black;
            this.textBox.IsPassword = false;
            this.textBox.Location = new System.Drawing.Point(2, 4);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.PlaceHolderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.textBox.PlaceHolderText = "Search or start new chat";
            this.textBox.Size = new System.Drawing.Size(253, 29);
            this.textBox.TabIndex = 1;
            this.textBox.Text = "Search or start new chat";
            this.textBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // SearchIcon
            // 
            this.SearchIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.SearchIcon.Image = global::ChatApplication.Properties.Resources.icons8_search_19;
            this.SearchIcon.Location = new System.Drawing.Point(4, 4);
            this.SearchIcon.Name = "SearchIcon";
            this.SearchIcon.Size = new System.Drawing.Size(45, 35);
            this.SearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SearchIcon.TabIndex = 0;
            this.SearchIcon.TabStop = false;
            // 
            // CustomSearchBox
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.Controls.Add(this.TextBoxPanel);
            this.Controls.Add(this.SearchIcon);
            this.Name = "CustomSearchBox";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(310, 43);
            this.TextBoxPanel.ResumeLayout(false);
            this.TextBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.PictureBox SearchIcon;
        private PlaceHolderTextBox textBox;
        private System.Windows.Forms.Panel TextBoxPanel;
    }
}
