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
namespace ChatApplication
{
    public partial class MessagePage : UserControl
    {
        public Client Client { get; set; }
        FileSenderPage FileSharePage;
        ContentForm Info;

        public MessagePage(Client contact)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            Client = contact;
            ProfilePicture.Image = contact.Dp;
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
                DP = contact.Dp
            };

            foreach (var a in Messages)
            {
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
            Message msg = new Message(ChatApplicationNetworkManager.FromIPAddress, Client.IP, message, DateTime.Now, Type.File);
            //AddMessage(msg);
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
                Info.Visible = true;
                Point location = PointToScreen(HeaderPanel.Location);
                location.Offset(ProfilePicture.Width / 3, HeaderPanel.Height + 10);
                Info.Location = location;
                Message.ClickedInfo = true;
            }
            Info.Focus();
        }
    }
}
