using ChatApplication.Managers;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatApplication.Models;
using ChatApplication.UserControls;
using System.Xml.Serialization;

namespace ChatApplication.Managers
{
    public static class ChatApplicationNetworkManager
    {
        public static List<ChatU> SelectedMessages = new List<ChatU>();

        public delegate void NewUserEnter(ContactU label);
        public static event NewUserEnter Inform;

        public delegate void ProfileUpdation(Client c);
        public static event ProfileUpdation ProfileUpdateInformer;

        public static string LocalIpAddress { get; set; }
        private static TcpListener Listener;
        public static MessagePage MessagePage = null;
        public static LocalData MyData = new LocalData();
        private static Dictionary<string, Client> Clients = new Dictionary<string, Client>();
        private static Dictionary<string, MessageModel> Messages = new Dictionary<string, MessageModel>();

       

        public static bool DataBaseConfiguration()
        {
            using (LocalDb local = new LocalDb())
            {
                local.Database.EnsureCreated();
                var messages = local.Messages.ToList();
                foreach (var msg in messages)
                {
                    MessageModel m = new MessageModel(msg);
                    Messages.Add(m.Id, m);
                }
            }

            using (ServerDb server = new ServerDb())
            {
                server.Database.EnsureCreated();
                var clients = server.Clients.ToList();
                foreach (var client in clients)
                {
                    Client clt = new Client(client.IP, client.Name, client.Port, client.LastSeen, client.ProfilePath, client.About);
                    Clients.Add(clt.IP, clt);
                }
            }
            return true;
        }

        public static bool StartListener()
        {
            Listener = new TcpListener(IPAddress.Parse(LocalIpAddress), 12346);
            Listener.Start();
            AcceptClient();
            return true;
        }

        #region Receiving Datas From Client
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
                    MessageModel msg = JsonConvert.DeserializeObject<MessageModel>(Encoding.UTF8.GetString(buffer));

                    if (msg.type == MessageType.Response)
                    {
                        HandleResponses(msg);
                    }
                    else if (msg.type == MessageType.File)
                    {
                        HandleFile(msg);
                    }
                    else if (msg.type == MessageType.Message)
                    {
                        HandleMessages(msg);
                    }
                    else
                    {
                        HandleUpdation(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host."))
                {
                    IPAddress ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                    ReadClient(ip.ToString()).StatusChanger(false);
                    ReadClient(ip.ToString()).IsConnected = false;
                }
            }

            AcceptClient();
        }

        private static void HandleUpdation(MessageModel msg)
        {
            Client current = ReadClient(msg.FromIP);
            Client Updated = GetClientAtInstance(msg.FromIP);
            current.About = Updated.About;
            current.ProfilePath = Updated.ProfilePath;
            current.ProfilePicture = Image.FromFile(current.ProfilePath);
            ProfileUpdateInformer?.Invoke(current);
        }

        private async static void HandleFile(MessageModel msg)
        {
            Client clt = ReadClient(msg.Id);
            clt.MessagePage.AddMessage(msg);
            CreateMessage(msg);
            clt.UnSeenMessagesList.Add(msg);
            if (MessagePage != clt.MessagePage)
            {
                clt.UnseenMessages += 1;
                clt.UnSeenMessagesList.Add(msg);
            }
            else
            {
                MessageModel m = new MessageModel(msg)
                {
                    Msg = "Readed",
                    type = MessageType.Response
                };

                await SendMessage(m, ReadClient(m.FromIP));

            }
        }

            private static void HandleResponses(MessageModel msg)
            {
                if (!ReadAllMessages().ContainsKey(msg.FromIP) && !msg.FromIP.Equals(LocalIpAddress))
                {

                    Client client = GetClientAtInstance(msg.FromIP);
                    CreateClient(client);
                    client.MessagePage = new MessagePage(client);
                    ContactU label = new ContactU(client)
                    {
                        Dock = System.Windows.Forms.DockStyle.Top,
                    };
                    Inform?.Invoke(label);
                }


                if (msg.Msg.Equals("Close"))
                {
                    Client clt = ReadClient(msg.FromIP);
                    clt.StatusChanger(false);
                }
                else if (msg.Msg.Equals("Open"))
                {
                    Client clt = ReadClient(msg.FromIP);
                    clt.StatusChanger(true);
                }
                else
                {
                    ReadMessage(msg.Id).IsReadedInvoker();
                }
            }

            private async static void HandleMessages(MessageModel msg)
            {
                Client clt = ReadClient(msg.FromIP);
                clt.MessagePage.AddMessage(msg);
                //clt.UnSeenMessagesList.Add(msg);
                if (MessagePage != clt.MessagePage)
                {
                    clt.UnseenMessages += 1;
                    clt.UnSeenMessagesList.Add(msg);
                }
                else
                {
                    MessageModel m = new MessageModel(msg)
                    {
                        Msg = "Readed",
                        type = MessageType.Response
                    };
                    await SendMessage(m, ReadClient(m.FromIP));
                    msg.Seen = true;
                UpdateMessage(msg);
                }
                Client c = ReadClient(msg.FromIP);
                c.MessageReceiveInvoker();
            CreateMessage(msg);
            }
            #endregion

        #region SendData to another Ip
            public async static Task SendMessage(MessageModel message, Client c)
            {
                try
                {
                    TcpClient Sender = new TcpClient();
                    await Sender.ConnectAsync(IPAddress.Parse(c.IP), c.Port);
                    NetworkStream Stream = Sender.GetStream();
                    string msg = JsonConvert.SerializeObject(message);
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    await Stream.WriteAsync(data, 0, data.Length);
                    message.IsSendedInvoker();
                    c.MessageSendInvoker();
                    if (message.type == MessageType.Message)
                    {
                        CreateMessage(message);
                    }
                    c.StatusChanger(true);
                }
                catch
                {
                    c.StatusChanger(false);
                }
            }

            public static async void SendResponseForReadedMessage(List<MessageModel> Readedmessages, Client c)
            {
                foreach (var msg in Readedmessages)
                {
                    MessageModel m = new MessageModel(msg)
                    {
                        type = MessageType.Response,
                        Msg = "Readed"
                    };
                    if (c.IsConnected) await SendMessage(m, c);

                m = ReadMessage(msg.Id);
                    m.Seen = true;
                    UpdateMessage(m);
                }
                c.UnSeenMessagesList.Clear();
            }
            #endregion

        #region Clients

        public static void CreateClient(Client clt)
        {
            using (ServerDb server = new ServerDb())
            {
                server.Clients.Add(clt);
                server.SaveChanges();
                Clients.Add(clt.IP, clt);
            }
        }
        public static Dictionary<string, Client> ReadAllClients()
        {
            return Clients;
        }

        public static Client ReadClient(string Ip)
        {
            return Clients[Ip];
        }

        public static void UpdateClient(Client client)
        {
            using (ServerDb server = new ServerDb())
            {
                Client client1 = server.Clients.FirstOrDefault(clt => clt.IP == client.IP);
                client1 = client;
                server.SaveChanges();
                Clients[client.IP] = client1;
            }
        }

        public static Client GetClientAtInstance(string Ip)
        {
            using (ServerDb server = new ServerDb())
            {
                return server.Clients.FirstOrDefault(clt => clt.IP == Ip);
            }
        }
        #endregion

        #region Messages
        public static Dictionary<string, MessageModel> ReadAllMessages()
        {
            //using (LocalDb local = new LocalDb())
            //{
            //    return local.Messages.ToDictionary(msg => msg.Id);
            //}
            return Messages;
        }

        public static List<MessageModel> ReadMessages(string FromIp, string ToIP)
        {
            return ReadAllMessages().Values.ToList().Where((msg) =>
            {
                return (msg.FromIP.Equals(FromIp) && msg.ReceiverIP.Equals(ToIP)) || (msg.FromIP.Equals(ToIP) && msg.ReceiverIP.Equals(FromIp));
            }).ToList();
        }
        public static MessageModel ReadMessage(string messageId)
        {
            using (LocalDb local = new LocalDb())
            {
                //return local.Messages.FirstOrDefault(msg => msg.Id == messageId);
                return Messages[messageId];
            }
        }
        public static void CreateMessage(MessageModel msg)
        {
            if (Messages.ContainsKey(msg.Id)) return;
            using (LocalDb local = new LocalDb())
            {
                local.Messages.Add(msg);
                local.SaveChanges();
                Messages.Add(msg.Id, msg);
            }
        }

        public static void DeleteMessage(string messageId)
        {
            using (LocalDb local = new LocalDb())
            {
                local.Messages.Remove(ReadMessage(messageId));
                local.SaveChanges();
                Messages.Remove(messageId);
            }
        }

        public static void DeleteMessages(IEnumerable<string> Messageid)
        {
            using (LocalDb local = new LocalDb())
            {
                foreach (var item in Messageid)
                {
                    local.Messages.Remove(ReadMessage(item));
                    local.SaveChanges();
                    Messages.Remove(item);
                }
            }
        }

        public static void UpdateMessage(MessageModel message)
        {
            using (LocalDb local = new LocalDb())
            {
                MessageModel msg = ReadMessage(message.Id);
                msg = message;
                local.SaveChanges();
                Messages[message.Id] = message;
            }
        }
        #endregion

        public static string ReadLocalConnectionString()
        {
            string s = @".\data.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextReader reader = new StreamReader(s))
            {
                LocalData Data = (LocalData)serializer.Deserialize(reader);
                string connecctionString = $"server={Data.Server};port={Data.Port};uid={Data.Uid};pwd={Data.Password};database={Data.Database};charset=utf8mb4";
                 return connecctionString;
            }
        }
    }
}




