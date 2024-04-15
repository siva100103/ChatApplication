namespace ChatApplication
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MessagePagePanel = new System.Windows.Forms.Panel();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.chatContactPanel = new System.Windows.Forms.Panel();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.ChatHeaderPanel = new System.Windows.Forms.Panel();
            this.SearchBox = new ChatApplication.CustomSearchBox();
            this.ChatContainer = new ChatApplication.CustomPanel();
            this.ContactButton = new ChatApplication.EllipseButton();
            this.OptionButton = new ChatApplication.EllipseButton();
            this.ChatLabel = new System.Windows.Forms.Label();
            this.SideMenuBar = new ChatApplication.MenuControl();
            this.MainPanel.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.ChatHeaderPanel.SuspendLayout();
            this.ChatContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MessagePagePanel);
            this.MainPanel.Controls.Add(this.ChatPanel);
            this.MainPanel.Controls.Add(this.SideMenuBar);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(934, 611);
            this.MainPanel.TabIndex = 3;
            // 
            // MessagePagePanel
            // 
            this.MessagePagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.MessagePagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagePagePanel.Location = new System.Drawing.Point(395, 0);
            this.MessagePagePanel.Name = "MessagePagePanel";
            this.MessagePagePanel.Size = new System.Drawing.Size(539, 611);
            this.MessagePagePanel.TabIndex = 8;
            // 
            // ChatPanel
            // 
            this.ChatPanel.Controls.Add(this.chatContactPanel);
            this.ChatPanel.Controls.Add(this.SearchPanel);
            this.ChatPanel.Controls.Add(this.ChatHeaderPanel);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChatPanel.Location = new System.Drawing.Point(45, 0);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(350, 611);
            this.ChatPanel.TabIndex = 7;
            // 
            // chatContactPanel
            // 
            this.chatContactPanel.BackColor = System.Drawing.Color.White;
            this.chatContactPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatContactPanel.Location = new System.Drawing.Point(0, 117);
            this.chatContactPanel.Name = "chatContactPanel";
            this.chatContactPanel.Size = new System.Drawing.Size(350, 494);
            this.chatContactPanel.TabIndex = 4;
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.White;
            this.SearchPanel.Controls.Add(this.SearchBox);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchPanel.Location = new System.Drawing.Point(0, 63);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Padding = new System.Windows.Forms.Padding(20, 4, 20, 8);
            this.SearchPanel.Size = new System.Drawing.Size(350, 54);
            this.SearchPanel.TabIndex = 3;
            // 
            // ChatHeaderPanel
            // 
            this.ChatHeaderPanel.BackColor = System.Drawing.Color.White;
            this.ChatHeaderPanel.Controls.Add(this.ChatContainer);
            this.ChatHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChatHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.ChatHeaderPanel.Name = "ChatHeaderPanel";
            this.ChatHeaderPanel.Padding = new System.Windows.Forms.Padding(15);
            this.ChatHeaderPanel.Size = new System.Drawing.Size(350, 63);
            this.ChatHeaderPanel.TabIndex = 1;
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(253)))));
            this.SearchBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(107)))), ((int)(((byte)(169)))));
            this.SearchBox.BorderSize = 4;
            this.SearchBox.IsSearchIconVisible = true;
            this.SearchBox.IsUnderLine = true;
            this.SearchBox.Location = new System.Drawing.Point(5, 5);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Padding = new System.Windows.Forms.Padding(7);
            this.SearchBox.PlaceholderText = "Search or start new chat";
            this.SearchBox.Size = new System.Drawing.Size(339, 43);
            this.SearchBox.TabIndex = 0;
            // 
            // ChatContainer
            // 
            this.ChatContainer.AllBorderRadius = 30;
            this.ChatContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(253)))));
            this.ChatContainer.BorderColor = System.Drawing.Color.Black;
            this.ChatContainer.BorderMarginSize = 0;
            this.ChatContainer.BottomLeftRadius = 30;
            this.ChatContainer.BottomRight = 30;
            this.ChatContainer.Controls.Add(this.ContactButton);
            this.ChatContainer.Controls.Add(this.OptionButton);
            this.ChatContainer.Controls.Add(this.ChatLabel);
            this.ChatContainer.Location = new System.Drawing.Point(4, 2);
            this.ChatContainer.Name = "ChatContainer";
            this.ChatContainer.Size = new System.Drawing.Size(339, 60);
            this.ChatContainer.TabIndex = 0;
            this.ChatContainer.TopLeftRadius = 30;
            this.ChatContainer.TopRightRadius = 30;
            // 
            // ContactButton
            // 
            this.ContactButton.BackColor = System.Drawing.Color.Transparent;
            this.ContactButton.BackgroudColor = System.Drawing.Color.Transparent;
            this.ContactButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ContactButton.BorderRadius1 = 30;
            this.ContactButton.BorderSize1 = 0;
            this.ContactButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ContactButton.FlatAppearance.BorderSize = 0;
            this.ContactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContactButton.ForeColor = System.Drawing.Color.White;
            this.ContactButton.Image = global::ChatApplication.Properties.Resources.icons8_create_20;
            this.ContactButton.Location = new System.Drawing.Point(259, 0);
            this.ContactButton.Name = "ContactButton";
            this.ContactButton.Size = new System.Drawing.Size(80, 60);
            this.ContactButton.TabIndex = 3;
            this.ContactButton.TextColor = System.Drawing.Color.White;
            this.ContactButton.UseVisualStyleBackColor = false;
            // 
            // OptionButton
            // 
            this.OptionButton.BackColor = System.Drawing.Color.Transparent;
            this.OptionButton.BackgroudColor = System.Drawing.Color.Transparent;
            this.OptionButton.BorderColor = System.Drawing.Color.Transparent;
            this.OptionButton.BorderRadius1 = 30;
            this.OptionButton.BorderSize1 = 0;
            this.OptionButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.OptionButton.FlatAppearance.BorderSize = 0;
            this.OptionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionButton.ForeColor = System.Drawing.Color.White;
            this.OptionButton.Image = global::ChatApplication.Properties.Resources.icons8_align_left_19;
            this.OptionButton.Location = new System.Drawing.Point(0, 0);
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.Size = new System.Drawing.Size(80, 60);
            this.OptionButton.TabIndex = 2;
            this.OptionButton.TextColor = System.Drawing.Color.White;
            this.OptionButton.UseVisualStyleBackColor = false;
            this.OptionButton.Click += new System.EventHandler(this.OptionButtonClick);
            // 
            // ChatLabel
            // 
            this.ChatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatLabel.Location = new System.Drawing.Point(0, 0);
            this.ChatLabel.Name = "ChatLabel";
            this.ChatLabel.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.ChatLabel.Size = new System.Drawing.Size(339, 60);
            this.ChatLabel.TabIndex = 1;
            this.ChatLabel.Text = "Chats";
            this.ChatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SideMenuBar
            // 
            this.SideMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(253)))));
            this.SideMenuBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideMenuBar.Location = new System.Drawing.Point(0, 0);
            this.SideMenuBar.Margin = new System.Windows.Forms.Padding(2);
            this.SideMenuBar.Name = "SideMenuBar";
            this.SideMenuBar.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SideMenuBar.ProfileImage = ((System.Drawing.Image)(resources.GetObject("SideMenuBar.ProfileImage")));
            this.SideMenuBar.ProfileShow = true;
            this.SideMenuBar.Size = new System.Drawing.Size(45, 611);
            this.SideMenuBar.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.MainPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.MainPanel.ResumeLayout(false);
            this.ChatPanel.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.ChatHeaderPanel.ResumeLayout(false);
            this.ChatContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel MessagePagePanel;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Panel ChatHeaderPanel;
        private System.Windows.Forms.Panel chatContactPanel;
        private CustomSearchBox SearchBox;
        private CustomPanel ChatContainer;
        private EllipseButton ContactButton;
        private EllipseButton OptionButton;
        private System.Windows.Forms.Label ChatLabel;
        private MenuControl SideMenuBar;
    }
}