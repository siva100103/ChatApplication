using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApplication;
using ChatApplication.Controller;
using Newtonsoft.Json;

namespace WindowsFormsApp3
{
    public class Client
    {

        public string IP { get; set; }
        public string Name { get; set; } = "";
        public string About { get; set; } = "";
        public Image ProfilePicture { get; set; } = ChatApplication.Properties.Resources.user__2_;
        public DateTime LastSeen { get; set; }
        public int Port { get; set; } = 12346;
        public string ProfilePath { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsConnected { get; set; }
        public MessagePage MessagePage { get; set; }
        private int unSeenMessages = 0;

        public List<ChatApplication.Message> UnSeenMessagesList { get; set; } = new List<ChatApplication.Message>();

        public int UnseenMessages
        {
            get
            {
                return unSeenMessages;
            }
            set
            {
                UnseenMessageChanged?.Invoke(this, value);
                unSeenMessages = value;
            }
        }

        public event EventHandler<bool> StatusChanged;
        public event EventHandler<int> UnseenMessageChanged;
        public event EventHandler MessageSend;
        public event EventHandler MessageReceive;

        public Client(string ip, string Name, int Port,DateTime LastSeen,string ProfilePath,string About)
        {
            IP = ip;
            this.Name = Name;
            this.Port = Port;
            this.ProfilePath = ProfilePath;
            this.About = About;
            this.LastSeen = LastSeen;
            MessagePage = new MessagePage(this);
            IdentifyUnSeenMsgs();
            ConnectAsync();
        }

        private void IdentifyUnSeenMsgs()
        {
            UnSeenMessagesList = LocalDatabase.Messages.Values.Where(m =>
              {
                  return m.FromIP.Equals(this.IP) && m.ReceiverIP.Equals(ChatApplicationNetworkManager.LocalIpAddress) && !m.Seen; 
              }).ToList();
            unSeenMessages = UnSeenMessagesList.Count;
        }

        public Client()
        {

        }

        public async void ConnectAsync()
        {
            try
            {
                ChatApplication.Message message = new ChatApplication.Message(ChatApplicationNetworkManager.LocalIpAddress, IP, "Open", DateTime.Now, ChatApplication.Type.Response);
               await ChatApplicationNetworkManager.SendMessage(message, this);
                IsConnected = true;
                StatusChanged.Invoke(this, true);
            }
            catch (SocketException ex)
            {
                IsConnected = false;
                StatusChanged?.Invoke(this, false);
                Console.WriteLine(ex.Message);
            }
        }

        public void StatusChanger(bool status)
        {
            IsConnected = status;
            if (!status)
            {
                LastSeen = DateTime.Now;
            }
            StatusChanged?.Invoke(this, status);
        }

        public void MessageSendInvoker()
        {
            MessageSend?.Invoke(this,EventArgs.Empty);
        }

        public void MessageReceiveInvoker()
        {
            MessageReceive?.Invoke(this, EventArgs.Empty);
        }
    }
}
