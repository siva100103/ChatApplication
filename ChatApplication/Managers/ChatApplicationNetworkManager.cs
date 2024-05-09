﻿using ChatApplication.Managers;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatApplication.Models;
using ChatApplication.UserControls;

namespace ChatApplication.Managers
{
    public static class ChatApplicationNetworkManager
    {
        public static List<ChatU> SelectedMessages = new List<ChatU>();

        public delegate void NewUserEnter(ContactU label);
        public static event NewUserEnter Inform;

        public static string LocalIpAddress { get; set; }
        private static TcpListener Listener;
        public static MessagePage MessagePage = null;


        public static bool ManagerInitializer()
        {
            return DbManager.LocalDbConfig() && StartServer() && UpdatePreviousMessageFromDb() && TryConnectingWithMembers();
        }

        private static bool TryConnectingWithMembers()
        {
            DbManager.Clients.Values.ToList().ForEach( (c) => c.ConnectAsync());
            return true;
        }

        private static bool UpdatePreviousMessageFromDb()
        {
           foreach(var a in DbManager.Clients)
            {
                a.Value.MessagePage = new MessagePage(a.Value);
            }
            return true;
        }

        
        private static bool StartServer()
        {
            Listener = new TcpListener(IPAddress.Parse(LocalIpAddress), 12346);
            Listener.Start();
            AcceptClient();
            return true;
        }


        private async static void AcceptClient()
        {
            TcpClient client = await Listener.AcceptTcpClientAsync();
            HandleClient(client);
        }

        private async static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[5024];
            int bytesRead;

            try
            {
                if ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    Message msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(buffer));

                    if (msg.type == MessageType.Response)
                    {
                        HandleResponses(msg);
                    }
                    else if (msg.type == MessageType.File)
                    {
                        HandleFile(msg);
                    }
                    else
                    {
                        HandleMessages(msg);
                    }
                }
            }
            catch(Exception ex)
            {
                if(ex.Message.Equals("Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host."))
                {
                  IPAddress ip=  ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                  DbManager.Clients[ip.ToString()].StatusChanger(false);
                }
            }

            AcceptClient();
        }

        private async static void HandleFile(Message msg)
        {
            Client clt = DbManager.Clients[msg.FromIP];
            clt.MessagePage.AddMessage(msg);
            clt.UnSeenMessagesList.Add(msg);
            string path = msg.Msg;
            string savePath = @"C:\Users\Public\Downloads\";
            string newfilePath = Path.Combine(savePath, Path.GetFileNameWithoutExtension(path) + Path.GetExtension(path));
            if (MessagePage != clt.MessagePage)
            {
                clt.UnseenMessages += 1;
                clt.UnSeenMessagesList.Add(msg);
            }
            else
            {
                Message m = new Message(msg)
                {
                    Msg = "Readed",
                    type = MessageType.Response
                };

                await SendMessage(m, DbManager.Clients[m.FromIP]);

            }
        }

        private static void HandleResponses(Message msg)
        {
            if (!DbManager.Clients.ContainsKey(msg.FromIP) && !msg.FromIP.Equals(LocalIpAddress))
            {
                
                Client client = DbManager.GetClientAtInstance(msg.FromIP);
                DbManager.Clients.Add(client.IP,client);
                client.MessagePage = new MessagePage(client);
                ContactU label = new ContactU(client)
                {
                    Dock = System.Windows.Forms.DockStyle.Top,
                };
                Inform?.Invoke(label);
            }


            if (msg.Msg.Equals("Close"))
            {
                Client clt = DbManager.Clients[msg.FromIP];
                clt.StatusChanger(false);
            }
            else if (msg.Msg.Equals("Open"))
            {
                Client clt = DbManager.Clients[msg.FromIP];
                clt.StatusChanger(true);
            }
            else
            {
                DbManager.Messages[msg.Id].IsReadedInvoker();
            }
        }

        private async static void HandleMessages(Message msg)
        {
            Client clt = DbManager.Clients[msg.FromIP];
            clt.MessagePage.AddMessage(msg);
            clt.UnSeenMessagesList.Add(msg);
            if (MessagePage != clt.MessagePage)
            {
                clt.UnseenMessages += 1;
                clt.UnSeenMessagesList.Add(msg);
            }
            else
            {
                Message m = new Message(msg)
                {
                    Msg = "Readed",
                    type = MessageType.Response
                };
                await SendMessage(m, DbManager.Clients[m.FromIP]);
                msg.Seen = true;
                DbManager.UpdateMessage(msg);
            }
            Client c = DbManager.Clients[msg.FromIP];
            c.MessageReceiveInvoker();
            DbManager.CreateMessage(msg);
        }

        public async static Task SendMessage(Message message, Client c)
        {
            TcpClient Sender = new TcpClient();
            await Sender.ConnectAsync(IPAddress.Parse(c.IP), c.Port);
            NetworkStream Stream = Sender.GetStream();
            string msg = JsonConvert.SerializeObject(message);
            byte[] data = Encoding.UTF8.GetBytes(msg);
            await Stream.WriteAsync(data, 0, data.Length);
            message.IsSendedInvoker();
            c.MessageSendInvoker();
            if (message.type != MessageType.Response)
            {
                DbManager.CreateMessage(message);
            }
        }

        public static async void SendResponseForReadedMessage(List<Message> Readedmessages, Client c)
        {
            foreach (var msg in Readedmessages)
            {
                Message m = new Message(msg)
                {
                    type = MessageType.Response,
                    Msg = "Readed"
                };
                if (c.IsConnected) await SendMessage(m, c);

                m = DbManager.Messages.Values.ToList().Find(m1 => msg.Id.Equals(m1.Id));
                m.Seen = true;
                DbManager.UpdateMessage(m);
            }
            c.UnSeenMessagesList.Clear();
        }

        public static List<Message> GetMessages(string FromIp, string ToIP)
        {
            return DbManager.Messages.Values.ToList().Where((msg) =>
           {
               return (msg.FromIP.Equals(FromIp) && msg.ReceiverIP.Equals(ToIP)) || (msg.FromIP.Equals(ToIP) && msg.ReceiverIP.Equals(FromIp));
           }).ToList();
        }
    }
}



