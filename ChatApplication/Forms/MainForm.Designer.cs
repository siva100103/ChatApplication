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
            this.MessagePageBackPanel = new System.Windows.Forms.Panel();
            this.MessagePagePanel = new System.Windows.Forms.Panel();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.chatContactPanel = new System.Windows.Forms.Panel();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.ChatHeaderPanel = new System.Windows.Forms.Panel();
            this.StarMainPanel = new System.Windows.Forms.Panel();
            this.StarPanel = new System.Windows.Forms.Panel();
            this.StarMessageTopPanel = new System.Windows.Forms.Panel();
            this.StarLabel = new System.Windows.Forms.Label();
            this.MessagePageTopPanel = new ChatApplication.CustomPanel();
            this.MinMaxButton = new System.Windows.Forms.PictureBox();
            this.SearchBox = new ChatApplication.CustomSearchBox();
            this.ChatContainer = new ChatApplication.CustomPanel();
            this.StarMessageButton = new ChatApplication.EllipseButton();
            this.OptionButton = new ChatApplication.EllipseButton();
            this.ChatLabel = new System.Windows.Forms.Label();
            this.StarBackButton = new ChatApplication.EllipseButton();
            this.SideMenuBar = new ChatApplication.MenuControl();
            this.BorderPanel = new ChatApplication.CustomPanel();
            this.MainPanel.SuspendLayout();
            this.MessagePageBackPanel.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.ChatHeaderPanel.SuspendLayout();
            this.StarMainPanel.SuspendLayout();
            this.StarMessageTopPanel.SuspendLayout();
            this.MessagePageTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinMaxButton)).BeginInit();
            this.ChatContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MessagePageBackPanel);
            this.MainPanel.Controls.Add(this.MessagePageTopPanel);
            this.MainPanel.Controls.Add(this.ChatPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(77, 1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.MainPanel.Size = new System.Drawing.Size(856, 609);
            this.MainPanel.TabIndex = 3;
            // 
            // MessagePageBackPanel
            // 
            this.MessagePageBackPanel.Controls.Add(this.MessagePagePanel);
            this.MessagePageBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagePageBackPanel.Location = new System.Drawing.Point(350, 17);
            this.MessagePageBackPanel.Name = "MessagePageBackPanel";
            this.MessagePageBackPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.MessagePageBackPanel.Size = new System.Drawing.Size(506, 592);
            this.MessagePageBackPanel.TabIndex = 17;
            // 
            // MessagePagePanel
            // 
            this.MessagePagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(227)))));
            this.MessagePagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagePagePanel.Location = new System.Drawing.Point(0, 5);
            this.MessagePagePanel.Name = "MessagePagePanel";
            this.MessagePagePanel.Size = new System.Drawing.Size(506, 587);
            this.MessagePagePanel.TabIndex = 18;
            // 
            // ChatPanel
            // 
            this.ChatPanel.Controls.Add(this.chatContactPanel);
            this.ChatPanel.Controls.Add(this.SearchPanel);
            this.ChatPanel.Controls.Add(this.ChatHeaderPanel);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChatPanel.Location = new System.Drawing.Point(0, 5);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(350, 604);
            this.ChatPanel.TabIndex = 7;
            // 
            // chatContactPanel
            // 
            this.chatContactPanel.BackColor = System.Drawing.Color.White;
            this.chatContactPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatContactPanel.Location = new System.Drawing.Point(0, 117);
            this.chatContactPanel.Name = "chatContactPanel";
            this.chatContactPanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.chatContactPanel.Size = new System.Drawing.Size(350, 487);
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
            // StarMainPanel
            // 
            this.StarMainPanel.AutoScroll = true;
            this.StarMainPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.StarMainPanel.Controls.Add(this.StarPanel);
            this.StarMainPanel.Controls.Add(this.StarMessageTopPanel);
            this.StarMainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.StarMainPanel.Location = new System.Drawing.Point(67, 1);
            this.StarMainPanel.Name = "StarMainPanel";
            this.StarMainPanel.Size = new System.Drawing.Size(10, 609);
            this.StarMainPanel.TabIndex = 16;
            this.StarMainPanel.Visible = false;
            // 
            // StarPanel
            // 
            this.StarPanel.AutoScroll = true;
            this.StarPanel.BackColor = System.Drawing.Color.White;
            this.StarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StarPanel.Location = new System.Drawing.Point(0, 99);
            this.StarPanel.Name = "StarPanel";
            this.StarPanel.Padding = new System.Windows.Forms.Padding(7, 5, 8, 5);
            this.StarPanel.Size = new System.Drawing.Size(10, 510);
            this.StarPanel.TabIndex = 1;
            // 
            // StarMessageTopPanel
            // 
            this.StarMessageTopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(211)))), ((int)(((byte)(95)))));
            this.StarMessageTopPanel.Controls.Add(this.StarLabel);
            this.StarMessageTopPanel.Controls.Add(this.StarBackButton);
            this.StarMessageTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StarMessageTopPanel.Location = new System.Drawing.Point(0, 0);
            this.StarMessageTopPanel.Name = "StarMessageTopPanel";
            this.StarMessageTopPanel.Padding = new System.Windows.Forms.Padding(5, 30, 5, 15);
            this.StarMessageTopPanel.Size = new System.Drawing.Size(10, 99);
            this.StarMessageTopPanel.TabIndex = 0;
            // 
            // StarLabel
            // 
            this.StarLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StarLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StarLabel.ForeColor = System.Drawing.Color.White;
            this.StarLabel.Location = new System.Drawing.Point(58, 30);
            this.StarLabel.Name = "StarLabel";
            this.StarLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.StarLabel.Size = new System.Drawing.Size(0, 54);
            this.StarLabel.TabIndex = 2;
            this.StarLabel.Text = "Starred Messages";
            this.StarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MessagePageTopPanel
            // 
            this.MessagePageTopPanel.AllBorderRadius = 10;
            this.MessagePageTopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.MessagePageTopPanel.BorderColor = System.Drawing.Color.Transparent;
            this.MessagePageTopPanel.BorderMarginSize = 0;
            this.MessagePageTopPanel.BottomLeftRadius = 10;
            this.MessagePageTopPanel.BottomRight = 10;
            this.MessagePageTopPanel.Controls.Add(this.MinMaxButton);
            this.MessagePageTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessagePageTopPanel.Location = new System.Drawing.Point(350, 5);
            this.MessagePageTopPanel.Name = "MessagePageTopPanel";
            this.MessagePageTopPanel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MessagePageTopPanel.Size = new System.Drawing.Size(506, 12);
            this.MessagePageTopPanel.TabIndex = 18;
            this.MessagePageTopPanel.TopLeftRadius = 10;
            this.MessagePageTopPanel.TopRightRadius = 10;
            // 
            // MinMaxButton
            // 
            this.MinMaxButton.BackColor = System.Drawing.Color.Transparent;
            this.MinMaxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinMaxButton.Image = global::ChatApplication.Properties.Resources.icons8_ellipsis_48__1_;
            this.MinMaxButton.Location = new System.Drawing.Point(448, 0);
            this.MinMaxButton.Name = "MinMaxButton";
            this.MinMaxButton.Size = new System.Drawing.Size(48, 12);
            this.MinMaxButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MinMaxButton.TabIndex = 0;
            this.MinMaxButton.TabStop = false;
            this.MinMaxButton.Click += new System.EventHandler(this.MinMaxButtonClick);
            this.MinMaxButton.MouseLeave += new System.EventHandler(this.MinMaxButtonMouseLeave);
            this.MinMaxButton.MouseHover += new System.EventHandler(this.MinMaxButtonMouseHover);
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.SearchBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(211)))), ((int)(((byte)(57)))));
            this.SearchBox.BorderSize = 4;
            this.SearchBox.IsSearchIconVisible = true;
            this.SearchBox.IsUnderLine = true;
            this.SearchBox.Location = new System.Drawing.Point(5, 5);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Padding = new System.Windows.Forms.Padding(7);
            this.SearchBox.PlaceholderText = "Search or start new chat";
            this.SearchBox.SearchBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.SearchBox.Size = new System.Drawing.Size(339, 43);
            this.SearchBox.TabIndex = 0;
            // 
            // ChatContainer
            // 
            this.ChatContainer.AllBorderRadius = 30;
            this.ChatContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.ChatContainer.BorderColor = System.Drawing.Color.Black;
            this.ChatContainer.BorderMarginSize = 0;
            this.ChatContainer.BottomLeftRadius = 30;
            this.ChatContainer.BottomRight = 30;
            this.ChatContainer.Controls.Add(this.StarMessageButton);
            this.ChatContainer.Controls.Add(this.OptionButton);
            this.ChatContainer.Controls.Add(this.ChatLabel);
            this.ChatContainer.Location = new System.Drawing.Point(4, 2);
            this.ChatContainer.Name = "ChatContainer";
            this.ChatContainer.Size = new System.Drawing.Size(339, 60);
            this.ChatContainer.TabIndex = 0;
            this.ChatContainer.TopLeftRadius = 30;
            this.ChatContainer.TopRightRadius = 30;
            // 
            // StarMessageButton
            // 
            this.StarMessageButton.BackColor = System.Drawing.Color.Transparent;
            this.StarMessageButton.BackgroudColor = System.Drawing.Color.Transparent;
            this.StarMessageButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.StarMessageButton.BorderRadius1 = 30;
            this.StarMessageButton.BorderSize1 = 0;
            this.StarMessageButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.StarMessageButton.FlatAppearance.BorderSize = 0;
            this.StarMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StarMessageButton.ForeColor = System.Drawing.Color.White;
            this.StarMessageButton.Image = global::ChatApplication.Properties.Resources.icons8_star_22;
            this.StarMessageButton.Location = new System.Drawing.Point(259, 0);
            this.StarMessageButton.Name = "StarMessageButton";
            this.StarMessageButton.Size = new System.Drawing.Size(80, 60);
            this.StarMessageButton.TabIndex = 3;
            this.StarMessageButton.TextColor = System.Drawing.Color.White;
            this.StarMessageButton.UseVisualStyleBackColor = false;
            this.StarMessageButton.Click += new System.EventHandler(this.StarMessageButtonClick);
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
            this.OptionButton.Size = new System.Drawing.Size(74, 60);
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
            // StarBackButton
            // 
            this.StarBackButton.BackColor = System.Drawing.Color.Transparent;
            this.StarBackButton.BackgroudColor = System.Drawing.Color.Transparent;
            this.StarBackButton.BackgroundImage = global::ChatApplication.Properties.Resources.icons8_left_50;
            this.StarBackButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.StarBackButton.BorderRadius1 = 10;
            this.StarBackButton.BorderSize1 = 0;
            this.StarBackButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.StarBackButton.FlatAppearance.BorderSize = 0;
            this.StarBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StarBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StarBackButton.ForeColor = System.Drawing.Color.White;
            this.StarBackButton.Location = new System.Drawing.Point(5, 30);
            this.StarBackButton.Name = "StarBackButton";
            this.StarBackButton.Size = new System.Drawing.Size(53, 54);
            this.StarBackButton.TabIndex = 1;
            this.StarBackButton.Text = "\r\n\r\n⬅";
            this.StarBackButton.TextColor = System.Drawing.Color.White;
            this.StarBackButton.UseVisualStyleBackColor = false;
            this.StarBackButton.Click += new System.EventHandler(this.StarBackButtonClick);
            // 
            // SideMenuBar
            // 
            this.SideMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.SideMenuBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideMenuBar.Location = new System.Drawing.Point(11, 1);
            this.SideMenuBar.Margin = new System.Windows.Forms.Padding(2);
            this.SideMenuBar.Name = "SideMenuBar";
            this.SideMenuBar.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SideMenuBar.ProfileImage = ((System.Drawing.Image)(resources.GetObject("SideMenuBar.ProfileImage")));
            this.SideMenuBar.ProfileShow = true;
            this.SideMenuBar.Size = new System.Drawing.Size(56, 609);
            this.SideMenuBar.TabIndex = 14;
            // 
            // BorderPanel
            // 
            this.BorderPanel.AllBorderRadius = 10;
            this.BorderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(211)))), ((int)(((byte)(57)))));
            this.BorderPanel.BorderColor = System.Drawing.Color.Transparent;
            this.BorderPanel.BorderMarginSize = 0;
            this.BorderPanel.BottomLeftRadius = 10;
            this.BorderPanel.BottomRight = 10;
            this.BorderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BorderPanel.Location = new System.Drawing.Point(1, 1);
            this.BorderPanel.Name = "BorderPanel";
            this.BorderPanel.Size = new System.Drawing.Size(10, 609);
            this.BorderPanel.TabIndex = 15;
            this.BorderPanel.TopLeftRadius = 10;
            this.BorderPanel.TopRightRadius = 10;
            this.BorderPanel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.StarMainPanel);
            this.Controls.Add(this.SideMenuBar);
            this.Controls.Add(this.BorderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.MainPanel.ResumeLayout(false);
            this.MessagePageBackPanel.ResumeLayout(false);
            this.ChatPanel.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.ChatHeaderPanel.ResumeLayout(false);
            this.StarMainPanel.ResumeLayout(false);
            this.StarMessageTopPanel.ResumeLayout(false);
            this.MessagePageTopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MinMaxButton)).EndInit();
            this.ChatContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Panel ChatHeaderPanel;
        private System.Windows.Forms.Panel chatContactPanel;
        private CustomSearchBox SearchBox;
        private CustomPanel ChatContainer;
        private EllipseButton StarMessageButton;
        private EllipseButton OptionButton;
        private System.Windows.Forms.Label ChatLabel;
        private MenuControl SideMenuBar;
        private CustomPanel BorderPanel;
        private System.Windows.Forms.Panel MessagePageBackPanel;
        private System.Windows.Forms.Panel MessagePagePanel;
        private CustomPanel MessagePageTopPanel;
        private System.Windows.Forms.PictureBox MinMaxButton;
        private System.Windows.Forms.Panel StarMainPanel;
        private System.Windows.Forms.Panel StarMessageTopPanel;
        private System.Windows.Forms.Label StarLabel;
        private EllipseButton StarBackButton;
        private System.Windows.Forms.Panel StarPanel;
    }
}