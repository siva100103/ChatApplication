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
using Newtonsoft.Json;

namespace WindowsFormsApp3
{
    public class Client
    {
        
        public string IP { get; set; }
        public string Name { get; set; } = "";
        //public string About { get; set; } = "";
        public Image Dp { get; set; } = ChatApplication.Properties.Resources.user__2_;
        public DateTime LastSeen { get; set; }
        public int Port { get; set; } = 12345;


        public bool IsConnected { get; set; }
        public MessagePage MessagePage { get; set; }
        private int unSeenMessages=0;

        public List<ChatApplication.Message> UnSeenMessages { get; set; } = new List<ChatApplication.Message>();

        public int UnseenMessages
        {
            get
            {
                return unSeenMessages;
            }
            set
            {
                UnseenMessageChanged?.Invoke(this,value);
                unSeenMessages = value;
            }
        }

        public event EventHandler<bool> StatusChanged;
        public event EventHandler<int> UnseenMessageChanged;

        public Client(string ip,string Name,int Port)
        {
            IP = ip;
            this.Name = Name;
            this.Port = Port;
            MessagePage = new MessagePage(this);
            ConnectAsync();
        }

        public Client()
        {

        }


        public async void ConnectAsync()
        {
            try
            {
                ChatApplication.Message message = new ChatApplication.Message(ChatApplicationNetworkManager.FromIPAddress, IP, "Open", DateTime.Now, ChatApplication.Type.Response);
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
    }
}
