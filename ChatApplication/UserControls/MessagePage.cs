﻿using ChatApplication.Forms;
using ChatApplication.Managers;
using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
    [SupportedOSPlatform("windows")]
    public partial class MessagePage : UserControl
    {
        public Client Client { get; set; }
        public event EventHandler<List<ChatU>> StarredMessages;
        private List<ChatU> Messages = new List<ChatU>();
        private FileSenderPage FileSharePage;
        public ContentForm ContactInfo;
        private MenuForm MenuF;

        public Image ProfileImage
        {
            get { return ProfilePicture.Image; }
            set
            {
                ProfilePicture.Image = value;
                ProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public Color OuterColor
        {
            get { return BackColor; }
            set
            {
                HeaderPanel.BackColor = value;
                chatSenter.SenderColor = value;
                chatSenter.OnThemeChange();

                NameLabel.ForeColor = ChatTheme.TextColor;
                LastSeeLabel.ForeColor = ChatTheme.TextColor;
                MenuTip.ForeColor = ChatTheme.TextColor;
                MenuButton.FlatAppearance.MouseOverBackColor = ChatTheme.OuterLayerColor;
                MenuButton.FlatAppearance.MouseDownBackColor = ChatTheme.ContactBackgroundColor;
                chatSenter.FileShareSymbol = ChatTheme.FileShareIcon;
                chatSenter.SendButtonSymbol = ChatTheme.SendButtonIcon;
                MenuButton.Image = ChatTheme.MenuButtonIcon;
                FileSharePage.OnThemeChanged();
            }
        }

        public Color InnerColor
        {
            get { return ChatPanel.BackColor; }
            set
            {
                ChatPanel.BackColor = value;
            }
        }

        public MessagePage(Client contact)
        {
            InitializeComponent();
            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, ChatPanel, new object[] { true });
            Dock = DockStyle.Fill;
            ChatTheme.SetTheme(0);

            Client = contact;
            ProfilePicture.Image = contact.ProfilePicture;
            NameLabel.Text = contact.Name;

            chatSenter.MsgReady += SendMessage;
            chatSenter.FileChoosen += FileShare;
            contact.StatusChanged += StatusChange;
            chatSenter.TextMessage = "Type a message";
            DoubleBuffered = true;

            LastSeeLabel.Text = $"Last Seen On {(Client.LastSeen.Date.Equals(DateTime.Now.Date) ? "Today at " + Client.LastSeen.ToShortTimeString() : Client.LastSeen.Date.ToString("yyyy-MM-dd") + " at " + Client.LastSeen.ToShortTimeString())}";

            ChatPanel.AutoScroll = true;
            ChatPanel.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            List<MessageModel> messages = ChatApplicationNetworkManager.ReadMessages(ChatApplicationNetworkManager.LocalIpAddress, contact.IP);
            messages.Sort((m1, m2) => m1.Time.CompareTo(m2.Time));

            FileSharePage = new FileSenderPage
            {
                Dock = DockStyle.Fill
            };
            FileSharePage.FileMsgReady += FileSendMessage;
            FileSharePage.CloseButtonClicked += (sender, e) => { chatSenter.Show(); };
            MainPanel.Controls.Add(FileSharePage);

            ContactInfo = new ContentForm()
            {
                Size = new Size(400, 400),
                Visible = false,
                NameInfo = contact.Name,
                BackColor = Color.FromArgb(207, 227, 251),
                ContactInfo = contact.IP.ToString(),
            };

            MenuF = new MenuForm()
            {
                Visible = false
            };
            MenuF.Delete += Unselected;
            MenuF.Copy += Unselected;
            MenuF.Star += StarredMessage;
            if (messages.Count > 0)
            {
                Label dateLabel = new Label
                {
                    AutoSize = true,
                    BackColor = Color.AliceBlue,
                    Font = NameLabel.Font,

                };
                dateLabel.Text = messages[0].Time.ToShortDateString();
                Panel datePanel = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = dateLabel.Height,
                };
                dateLabel.Location = new Point((datePanel.Width / 2) + 100, 0);
                datePanel.Controls.Add(dateLabel);
                AddMessage(messages[0], datePanel);
            }

            for (int i = 1; i < messages.Count; i++)
            {

                if (messages[i].Time.Date != messages[i - 1].Time.Date)
                {
                    Label dateLabel = new Label
                    {
                        AutoSize = true,
                        BackColor = Color.AliceBlue,
                        Font = new Font("Microsoft YaHei", 10, FontStyle.Regular),
                    };
                    dateLabel.Text = (messages[i].Time.Date == DateTime.Now.Date) ? "Today" : messages[i].Time.ToShortDateString();

                    Panel datePanel = new Panel()
                    {
                        Dock = DockStyle.Top,
                        Height = dateLabel.Height,
                    };
                    dateLabel.Location = new Point((datePanel.Width / 2) + 100, 0);
                    datePanel.Controls.Add(dateLabel);
                    AddMessage(messages[i], datePanel);
                }
                else AddMessage(messages[i]);
            }
        }

        private void StarredMessage(object sender, List<ChatU> e)
        {
            StarredMessages?.Invoke(this, e);
            foreach (ChatU msg in ChatApplicationNetworkManager.SelectedMessages)
            {
                msg.Message.Starred = true;
                ChatApplicationNetworkManager.UpdateMessage(msg.Message);
                CustomPanel parent = (CustomPanel)msg.Parent;
                parent.BackColor = Color.Transparent;
            }
        }

        private void Unselected(object sender, EventArgs e)
        {
            foreach (ChatU msg in ChatApplicationNetworkManager.SelectedMessages)
            {
                CustomPanel parent = (CustomPanel)msg.Parent;
                parent.BackColor = Color.Transparent;
            }
        }

        public MessagePage()
        {

        }

        private void StatusChange(object sender, bool status)
        {
            chatSenter.Visible = status;
            if (!status) LastSeeLabel.Text = $"Last Seen On {(Client.LastSeen.Date.Equals(DateTime.Today) ? "Today at " + Client.LastSeen.ToLocalTime().ToString("HH:mm") : Client.LastSeen.Date.ToString("yyyy-MM-dd") + " at " + Client.LastSeen.ToLocalTime().ToString("HH:mm"))}";
            else LastSeeLabel.Text = "Online";
        }

        private async void SendMessage(object sender, string message)
        {
            MessageModel msg = new MessageModel(ChatApplicationNetworkManager.LocalIpAddress, Client.IP, message, DateTime.Now, MessageType.Message);
            AddMessage(msg);
            await ChatApplicationNetworkManager.SendMessage(msg, Client);
        }

        private async void FileSendMessage(object sender, string message)
        {
            string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
            string filePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(message) + Path.GetExtension(message));
            MessageModel msg = new
                MessageModel(ChatApplicationNetworkManager.LocalIpAddress, Client.IP, filePath,
                DateTime.Now, MessageType.File);
            AddMessage(msg);
            await ChatApplicationNetworkManager.SendMessage(msg, Client);
            chatSenter.Show();
        }

        private void FileShare(object sender, string filePath)
        {
            FileSharePage.Show();
            FileSharePage.OnThemeChanged();
            FileSharePage.BringToFront();
            chatSenter.Hide();
            FileSharePage.FileName = filePath;
        }

        public void MessageThemeSet()
        {
            foreach (ChatU chat in Messages)
            {
                if (chat.Message.Msg != "This Message is Deleted")
                {
                    if (chat.Message.FromIP.Equals(ChatApplicationNetworkManager.LocalIpAddress))
                    {
                        chat.BackColor = ChatTheme.SentColor;
                    }
                    else
                    {
                        chat.BackColor = ChatTheme.ReceivedColor;
                    }
                }
            }
        }

        public void AddMessage(MessageModel msg, Panel DatePanel = null)
        {
            HeaderPanel.SuspendLayout();
            ChatPanel.SuspendLayout();
            Panel space = new Panel()
            {
                Dock = DockStyle.Top,
                BackColor = Color.Transparent,
                Height = 15
            };

            if (msg.type == MessageType.File)
            {
                FileMessage file = new FileMessage(msg.Msg);
                file.ThemeChange();
                CustomPanel chatPanel = new CustomPanel()
                {
                    Dock = DockStyle.Top,
                    BackColor = Color.Transparent,
                    BorderColor = Color.Transparent,
                    BorderStyle = BorderStyle.None,
                    AllBorderRadius = 18,
                    Height = file.Height
                };
                chatPanel.Controls.Add(file);
                ChatPanel.Controls.Add(chatPanel);
                chatPanel.BringToFront();
                ChatPanel.Controls.Add(space);

                if (msg.FromIP.Equals(ChatApplicationNetworkManager.LocalIpAddress))
                {
                    file.Dock = DockStyle.Right;
                    Timer SendTimer = new Timer
                    {
                        Interval = 5000
                    };
                    SendTimer.Tick += (sender, e) =>
                    {
                        file.Dispose();
                    };
                    SendTimer.Start();
                }
                else
                {
                    file.Dock = DockStyle.Left;
                }

                file.Disposed += (sender, e) =>
                {
                    chatPanel.Dispose();
                    space.Dispose();
                };
            }
            else
            {
                ChatU chatMsg = new ChatU(msg);
                chatMsg.MessageCreate();
                CustomPanel chatPanel = new CustomPanel()
                {
                    Dock = DockStyle.Top,
                    BackColor = Color.Transparent,
                    BorderColor = Color.Transparent,
                    BorderStyle = BorderStyle.None,
                    AllBorderRadius = 18,
                    Height = chatMsg.Height
                };
                chatPanel.Controls.Add(chatMsg);
                chatMsg.ChatUClicked += ChatMsgClicked;
                if (msg.FromIP.Equals(ChatApplicationNetworkManager.LocalIpAddress))
                {
                    chatMsg.Dock = DockStyle.Right;
                    chatMsg.BackColor = ChatTheme.SentColor;
                }
                else
                {
                    chatMsg.Dock = DockStyle.Left;
                    chatMsg.BackColor = ChatTheme.ReceivedColor;
                }
                Messages.Add(chatMsg);
                ChatPanel.Controls.Add(chatPanel);
                ChatPanel.Controls.Add(space);
                if (DatePanel != null)
                {
                    ChatPanel.Controls.Add(DatePanel);
                    DatePanel.BringToFront();
                }
                chatPanel.BringToFront();
            }
            space.BringToFront();

            ChatPanel.ResumeLayout();
            HeaderPanel.ResumeLayout();
            ChatPanel.ScrollControlIntoView(space);
        }

        private void ChatMsgClicked(object sender, EventArgs e)
        {
            CustomPanel parent = (CustomPanel)(sender as ChatU).Parent;
            if ((sender as ChatU).Message.Msg != "This Message is Deleted")
            {
                if (parent.BackColor == Color.Transparent)
                {
                    parent.BackColor = Color.FromArgb(207, 227, 251);
                    ChatApplicationNetworkManager.SelectedMessages.Add((sender as ChatU));
                }
                else
                {
                    parent.BackColor = Color.Transparent;
                    ChatApplicationNetworkManager.SelectedMessages.Remove((sender as ChatU));
                }
            }
        }

        private void MenuButtonMouseHover(object sender, EventArgs e)
        {
            MenuTip.Visible = true;
        }

        private void MenuButtonMouseLeave(object sender, EventArgs e)
        {
            MenuTip.Visible = false;
            MenuButton.BackColor = Color.Transparent;
        }

        private void MenuButtonClick(object sender, EventArgs e)
        {
            if (!MenuF.Visible)
            {
                MenuF.Visible = true;
                Point location = PointToScreen(HeaderPanel.Location);
                location.Offset(NameLabel.Width - MenuButton.Width / 2, HeaderPanel.Height + 10);
                MenuF.Location = location;
            }
            else
            {
                MenuF.Visible = false;
            }
        }

        private void ProfilePictureClick(object sender, EventArgs e)
        {
            if (!MessageModel.ClickedInfo && !ContactInfo.Visible)
            {
                ContactInfo.DP = ProfilePicture.Image;
                ContactInfo.About = (ChatApplicationNetworkManager.ReadClient(Client.IP)).Value.About;
                ContactInfo.Visible = true;
                Point location = PointToScreen(HeaderPanel.Location);
                location.Offset(ProfilePicture.Width / 3, HeaderPanel.Height + 10);
                ContactInfo.Location = location;
                MessageModel.ClickedInfo = true;
            }
            ContactInfo.Focus();
        }
    }
}
