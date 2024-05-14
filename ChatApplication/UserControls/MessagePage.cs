using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using ChatApplication;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection;
using ChatApplication.Managers;
using ChatApplication.Models;
using System.Windows.Forms;
using ChatApplication.Forms;

namespace ChatApplication.UserControls
{
    public partial class MessagePage : UserControl
    {
        public Client Client { get; set; }
        public event EventHandler<List<ChatU>> StarredMessages;
        private List<ChatU> Messages = new List<ChatU>();

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
                NameLabel.ForeColor = ChatTheme.TextColor;
                LastSeeLabel.ForeColor = ChatTheme.TextColor;
                MenuTip.ForeColor = ChatTheme.TextColor;
                if(ChatTheme.Current)
                {
                    MenuButton.Image = Properties.Resources.icons8_menu_vertical_50;
                }
                else
                {
                    MenuButton.Image = Properties.Resources.icons8_menu_vertical_50__1_;
                }
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

        private FileSenderPage FileSharePage;
        public ContentForm ContactInfo;
        private MenuForm MenuF;

        public MessagePage(Client contact)
        {
            InitializeComponent();
            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, ChatPanel, new object[] { true });
            Dock = DockStyle.Fill;
            ChatTheme.SetTheme(false);

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

            List<MessageModel> Messages = ChatApplicationNetworkManager.GetMessages(ChatApplicationNetworkManager.LocalIpAddress, contact.IP);
            Messages.Sort((m1, m2) => m1.Time.CompareTo(m2.Time));

            FileSharePage = new FileSenderPage
            {
                Dock = DockStyle.Fill
            };
            FileSharePage.FileMsgReady += FileSendMessage;
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

            foreach (var a in Messages)
            {
                if (!a.Msg.Contains(@"\\SPARE-B11\Chat Application Profile\"))
                    AddMessage(a);
            }
        }

        private void StarredMessage(object sender, List<ChatU> e)
        {
            StarredMessages?.Invoke(this, e);
            foreach (ChatU msg in ChatApplicationNetworkManager.SelectedMessages)
            {
                msg.Message.Starred = true;
                DbManager.StarMessages(msg.Message);
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
            FileSharePage.BringToFront();
            chatSenter.Hide();
            FileSharePage.FileName = filePath;
        }

        public void MessageThemeSet()
        {
            foreach(ChatU chat in Messages)
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

        public void AddMessage(MessageModel msg)
        {
            HeaderPanel.SuspendLayout();
            ChatPanel.SuspendLayout();
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
            Panel space = new Panel()
            {
                Dock = DockStyle.Top,
                BackColor = Color.Transparent,
                Height = 15
            };
            Messages.Add(chatMsg);
            ChatPanel.Controls.Add(chatPanel);
            ChatPanel.Controls.Add(space);
            chatPanel.BringToFront();
            space.BringToFront();
            if (msg.type == MessageType.File)
            {
                chatMsg.FilePath = msg.Msg;
                chatMsg.MouseClick += ChatMsgMouseClick;
            }
            chatMsg.ChatUClicked += ChatMsgClicked;
            ChatPanel.ResumeLayout();
            ChatPanel.ScrollControlIntoView(space);
            HeaderPanel.ResumeLayout();
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

        private void ChatMsgMouseClick(object sender, MouseEventArgs e)
        {
            string path = (sender as ChatU).FilePath;
            string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
            string filePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(path) + Path.GetExtension(path));
            //File.Open(filePath, FileMode.Open);
            try
            {
                if (File.Exists(filePath))
                {
                    Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch
            {
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
                ContactInfo.About = DbManager.Clients[Client.IP].About;
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
