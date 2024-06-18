namespace ChatApplication.Forms
{
    partial class DataBaseDetailsForm
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
            MainPanel = new System.Windows.Forms.Panel();
            PortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            PasswordTextBox = new System.Windows.Forms.TextBox();
            UidTextBox = new System.Windows.Forms.TextBox();
            SubmitButton = new System.Windows.Forms.Button();
            ColorPanel = new System.Windows.Forms.Panel();
            CreateButton = new System.Windows.Forms.Button();
            PasswordLabel = new System.Windows.Forms.Label();
            UIdLabel = new System.Windows.Forms.Label();
            PortLabel = new System.Windows.Forms.Label();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PortNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = System.Drawing.Color.White;
            MainPanel.Controls.Add(PortNumericUpDown);
            MainPanel.Controls.Add(PasswordTextBox);
            MainPanel.Controls.Add(UidTextBox);
            MainPanel.Controls.Add(SubmitButton);
            MainPanel.Controls.Add(ColorPanel);
            MainPanel.Controls.Add(CreateButton);
            MainPanel.Controls.Add(PasswordLabel);
            MainPanel.Controls.Add(UIdLabel);
            MainPanel.Controls.Add(PortLabel);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new System.Drawing.Size(418, 363);
            MainPanel.TabIndex = 2;
            // 
            // PortNumericUpDown
            // 
            PortNumericUpDown.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            PortNumericUpDown.Location = new System.Drawing.Point(150, 93);
            PortNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PortNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PortNumericUpDown.Name = "PortNumericUpDown";
            PortNumericUpDown.Size = new System.Drawing.Size(192, 24);
            PortNumericUpDown.TabIndex = 14;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            PasswordTextBox.Location = new System.Drawing.Point(150, 209);
            PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new System.Drawing.Size(192, 24);
            PasswordTextBox.TabIndex = 13;
            // 
            // UidTextBox
            // 
            UidTextBox.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UidTextBox.Location = new System.Drawing.Point(150, 152);
            UidTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            UidTextBox.Name = "UidTextBox";
            UidTextBox.Size = new System.Drawing.Size(192, 24);
            UidTextBox.TabIndex = 12;
            // 
            // SubmitButton
            // 
            SubmitButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SubmitButton.Location = new System.Drawing.Point(150, 290);
            SubmitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new System.Drawing.Size(102, 39);
            SubmitButton.TabIndex = 10;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButtonClick;
            // 
            // ColorPanel
            // 
            ColorPanel.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            ColorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            ColorPanel.Location = new System.Drawing.Point(0, 0);
            ColorPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ColorPanel.Name = "ColorPanel";
            ColorPanel.Size = new System.Drawing.Size(418, 69);
            ColorPanel.TabIndex = 9;
            // 
            // CreateButton
            // 
            CreateButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            CreateButton.Location = new System.Drawing.Point(178, 366);
            CreateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new System.Drawing.Size(102, 39);
            CreateButton.TabIndex = 8;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            // 
            // PasswordLabel
            // 
            PasswordLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            PasswordLabel.Location = new System.Drawing.Point(14, 209);
            PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new System.Drawing.Size(115, 33);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password:";
            // 
            // UIdLabel
            // 
            UIdLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            UIdLabel.Location = new System.Drawing.Point(29, 152);
            UIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            UIdLabel.Name = "UIdLabel";
            UIdLabel.Size = new System.Drawing.Size(100, 33);
            UIdLabel.TabIndex = 2;
            UIdLabel.Text = "UId:";
            // 
            // PortLabel
            // 
            PortLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            PortLabel.Location = new System.Drawing.Point(29, 93);
            PortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new System.Drawing.Size(100, 33);
            PortLabel.TabIndex = 0;
            PortLabel.Text = "Port:";
            // 
            // DataBaseDetailsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(418, 363);
            Controls.Add(MainPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DataBaseDetailsForm";
            Text = "DataBaseDetailsForm";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PortNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UIdLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UidTextBox;
        private System.Windows.Forms.NumericUpDown PortNumericUpDown;
    }
}