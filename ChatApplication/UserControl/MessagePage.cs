using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;
using System.IO;
using System.Net;
using ChatApplication;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace ChatApplication
{
    public partial class MessagePage : UserControl
    {
        public Client Client { get; set; }
        public Image ProfileImage
        {
            get { return ProfilePicture.Image; }
            set
            {
                ProfilePicture.Image = value;
                ProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private FileSenderPage FileSharePage;
        private ContentForm Info;

        public MessagePage(Client contact)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            Client = contact;
            ProfilePicture.Image = contact.ProfilePicture;
            NameLabel.Text = contact.Name;

            chatSenter.MsgReady += SendMessage;
            chatSenter.FileChoosen += FileShare;
            contact.StatusChanged += StatusChange;
            chatSenter.Visible = contact.IsConnected;
            //NameLabel.Click += ProfilePictureClick;
            DoubleBuffered = true;

            if (!Client.IsConnected)
                LastSeeLabel.Text = $"Last Seen On {(Client.LastSeen.Date.Equals(DateTime.Today) ? "Today at " + Client.LastSeen.ToLocalTime().ToString("HH:mm") : Client.LastSeen.Date.ToString("yyyy-MM-dd") + " at " + Client.LastSeen.ToLocalTime().ToString("HH:mm"))}";
            else LastSeeLabel.Text = "Online";
            ChatPanel.AutoScroll = true;
            ChatPanel.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            List<Message> Messages = ChatApplicationNetworkManager.GetMessages(ChatApplicationNetworkManager.FromIPAddress, contact.IP);
            Messages.Sort((m1, m2) => m1.Time.CompareTo(m2.Time));

            FileSharePage = new FileSenderPage
            {
                Dock = DockStyle.Fill
            };
            FileSharePage.FileMsgReady += FileSendMessage;
            MainPanel.Controls.Add(FileSharePage);

            Info = new ContentForm()
            {
                Size = new Size(400, 400),
                Visible = false,
                NameInfo = contact.Name,
                ContactInfo = contact.IP.ToString(),
            };

            foreach (var a in Messages)
            {
                if(!a.Msg.Contains(@"\\SPARE-B11\Chat Application Profile\"))
                AddMessage(a);
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
            Message msg = new Message(ChatApplicationNetworkManager.FromIPAddress, Client.IP, message, DateTime.Now, Type.Message);
            AddMessage(msg);
            await ChatApplicationNetworkManager.SendMessage(msg, Client);
        }

        private async void FileSendMessage(object sender, string message)
        {
            string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
            string filePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(message) + Path.GetExtension(message));
            Message msg = new
                Message(ChatApplicationNetworkManager.FromIPAddress, Client.IP, filePath,
                DateTime.Now, Type.File);
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

        public void AddMessage(Message msg)
        {
            ChatU chatMsg = new ChatU(msg);
            chatMsg.MessageCreate();
            Panel chatPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = chatMsg.Height
            };

            chatPanel.Controls.Add(chatMsg);
            if (msg.FromIP.Equals(ChatApplicationNetworkManager.FromIPAddress))
            {
                chatMsg.Dock = DockStyle.Right;
            }
            else
            {
                chatMsg.Dock = DockStyle.Left;
            }
            Panel space = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 15
            };
            
            ChatPanel.SuspendLayout();
            ChatPanel.Controls.Add(chatPanel);
            ChatPanel.Controls.Add(space);
            chatPanel.BringToFront();
            space.BringToFront();
            ChatPanel.ResumeLayout();
            ChatPanel.ScrollControlIntoView(space);
            if (msg.type == Type.File)
            {
                chatMsg.path = msg.Msg;
                chatMsg.MouseClick += ChatMsgMouseClick;
            }
        }
        private void ChatMsgMouseClick(object sender, MouseEventArgs e)
        {
            string path = (sender as ChatU).path;
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
        }

        private void MenuButtonClick(object sender, EventArgs e)
        {
            MenuTip.Visible = false;
        }

        private void ProfilePictureClick(object sender, EventArgs e)
        {
            if (!Message.ClickedInfo && !Info.Visible)
            {
                Info.DP = ProfilePicture.Image;
                Info.About = About();
                Info.Visible = true;
                Point location = PointToScreen(HeaderPanel.Location);
                location.Offset(ProfilePicture.Width / 3, HeaderPanel.Height + 10);
                Info.Location = location;
                Message.ClickedInfo = true;
            }
            Info.Focus();
        }

        private string About()
        {
            foreach (var client in ChatApplicationNetworkManager.Clients)
            {
                if (client.Key.Equals(Client.IP))
                {
                    return client.Value.About;
                }
            }
            return "";
        }

      
    }
}
