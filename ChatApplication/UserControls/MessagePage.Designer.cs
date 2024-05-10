

namespace ChatApplication.UserControls
{
    partial class MessagePage
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatSenter = new ChatApplication.UserControls.ChatSenter();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.MenuTip = new ChatApplication.UserControls.HoverMessageU();
            this.LastSeeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ProfilePicture = new ChatApplication.UserControls.CustomPictureBox();
            this.MenuButton = new ChatApplication.UserControls.HoverButton();
            this.MainPanel.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.MainPanel.Controls.Add(this.ChatPanel);
            this.MainPanel.Controls.Add(this.chatSenter);
            this.MainPanel.Controls.Add(this.HeaderPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(537, 558);
            this.MainPanel.TabIndex = 0;
            // 
            // ChatPanel
            // 
            this.ChatPanel.AutoScroll = true;
            this.ChatPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(227)))));
            this.ChatPanel.Controls.Add(this.panel1);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatPanel.Location = new System.Drawing.Point(0, 61);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(537, 458);
            this.ChatPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 458);
            this.panel1.TabIndex = 0;
            // 
            // chatSenter
            // 
            this.chatSenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.chatSenter.ChatSenterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.chatSenter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chatSenter.FileShareIconVisibility = false;
            this.chatSenter.Location = new System.Drawing.Point(0, 519);
            this.chatSenter.Name = "chatSenter";
            this.chatSenter.SendButtonVisibility = true;
            this.chatSenter.Size = new System.Drawing.Size(537, 39);
            this.chatSenter.TabIndex = 5;
            this.chatSenter.TextMessage = " ";
            this.chatSenter.Visible = false;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.HeaderPanel.Controls.Add(this.MenuTip);
            this.HeaderPanel.Controls.Add(this.LastSeeLabel);
            this.HeaderPanel.Controls.Add(this.NameLabel);
            this.HeaderPanel.Controls.Add(this.ProfilePicture);
            this.HeaderPanel.Controls.Add(this.MenuButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(537, 61);
            this.HeaderPanel.TabIndex = 0;
            // 
            // MenuTip
            // 
            this.MenuTip.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuTip.Location = new System.Drawing.Point(430, 0);
            this.MenuTip.Margin = new System.Windows.Forms.Padding(2);
            this.MenuTip.MessageText = "Menu";
            this.MenuTip.Name = "MenuTip";
            this.MenuTip.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.MenuTip.Size = new System.Drawing.Size(52, 42);
            this.MenuTip.TabIndex = 0;
            this.MenuTip.Visible = false;
            // 
            // LastSeeLabel
            // 
            this.LastSeeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LastSeeLabel.Location = new System.Drawing.Point(69, 42);
            this.LastSeeLabel.Name = "LastSeeLabel";
            this.LastSeeLabel.Size = new System.Drawing.Size(413, 19);
            this.LastSeeLabel.TabIndex = 3;
            this.LastSeeLabel.Text = "label2";
            // 
            // NameLabel
            // 
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(69, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(413, 61);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "label1";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProfilePicture.Image = global::ChatApplication.Properties.Resources.user__2_;
            this.ProfilePicture.Location = new System.Drawing.Point(0, 0);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(69, 61);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePicture.TabIndex = 0;
            this.ProfilePicture.TabStop = false;
            this.ProfilePicture.Click += new System.EventHandler(this.ProfilePictureClick);
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.Color.Transparent;
            this.MenuButton.BackgroudColor = System.Drawing.Color.Transparent;
            this.MenuButton.BorderColor = System.Drawing.Color.Transparent;
            this.MenuButton.BorderRadius1 = 0;
            this.MenuButton.BorderSize1 = 0;
            this.MenuButton.ButtonSideHoverlineColor = System.Drawing.Color.Transparent;
            this.MenuButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuButton.EndPoint = 39;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.ForeColor = System.Drawing.Color.White;
            this.MenuButton.Image = global::ChatApplication.Properties.Resources.icons8_menu_48;
            this.MenuButton.IsFormUp = false;
            this.MenuButton.IsSelected = false;
            this.MenuButton.Location = new System.Drawing.Point(482, 0);
            this.MenuButton.Margin = new System.Windows.Forms.Padding(5);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(55, 61);
            this.MenuButton.TabIndex = 9;
            this.MenuButton.TextColor = System.Drawing.Color.White;
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButtonClick);
            this.MenuButton.MouseLeave += new System.EventHandler(this.MenuButtonMouseLeave);
            this.MenuButton.MouseHover += new System.EventHandler(this.MenuButtonMouseHover);
            // 
            // MessagePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MainPanel);
            this.Name = "MessagePage";
            this.Size = new System.Drawing.Size(537, 558);
            this.MainPanel.ResumeLayout(false);
            this.ChatPanel.ResumeLayout(false);
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel HeaderPanel;
        private CustomPictureBox ProfilePicture;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.Label LastSeeLabel;
        private HoverButton MenuButton;
        private HoverMessageU MenuTip;
        private ChatSenter chatSenter;
        private System.Windows.Forms.Panel panel1;
    }
}
