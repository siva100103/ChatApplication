using ChatApplication.Models;
using ChatApplication.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ChatApplication.Managers
{
    [SupportedOSPlatform("windows")]

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


        #region DataBases
        public static BooleanMsg DataBaseConfiguration()
        {
            LocalIpAddress = GetLocalIPAddress();
            SerializeLocalDataToXml();
            SerializeServerDataToXml();
            BooleanMsg FetchingMessages = FetchMessages();
            if (!FetchingMessages) return FetchingMessages;
            BooleanMsg FetchingClients = FetchClients();
            if (!FetchingClients) return FetchingClients;
            return true;
        }
        private static BooleanMsg FetchMessages()
        {
            using (LocalDb local = new LocalDb())
            {
                try
                {
                    local.Database.EnsureCreated();
                }
                catch
                {
                    return "Fetching Messages Failed";
                }
                var messages = local.Messages.ToList();
                foreach (var msg in messages)
                {
                    MessageModel m = new MessageModel(msg);
                    Messages.Add(m.Id, m);
                }
                return true;
            }
        }
        public static BooleanMsg FetchClients(bool NeedCreate = false)
        {
            using (ServerDb server = new ServerDb())
            {
                if (NeedCreate)
                {
                    try
                    {
                        server.Database.EnsureCreated();
                    }
                    catch (Exception e)
                    {
                        return "Fetching Clients Failed";
                    }
                }
                if (!server.Database.CanConnect()) return "Fetching Clients Failed";
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
        public static string GetLocalIPAddress()
        {
            string ipAddress = string.Empty;
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation addressInfo in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (addressInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // Check for IPv4 addresses
                        {
                            ipAddress = addressInfo.Address.ToString();
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(ipAddress))
                    {
                        break;
                    }
                }
            }
            return ipAddress;
        }
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
        public static int GetTheme()
        {
            string xmlFilePath = @".\data.xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LocalData));
            using (TextReader textReader = new StreamReader(xmlFilePath))
            {
                LocalData data = (LocalData)xmlSerializer.Deserialize(textReader);
                return data.Theme;
            }
        }
        public static BooleanMsg UpdateTheme(int theme)
        {
            string xmlFilePath = @".\data.xml";
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            document.GetElementsByTagName("Theme").Item(0).InnerText = theme.ToString();
            document.Save(xmlFilePath);
            return true;
        }
        public static BooleanMsg UpdateLocalData(string Port, string UId, string Password)
        {
            string xmlFilePath = @".\data.xml";
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            document.GetElementsByTagName("Port").Item(0).InnerText = Port;
            document.GetElementsByTagName("Uid").Item(0).InnerText = UId;
            document.GetElementsByTagName("Password").Item(0).InnerText = Password;
            document.Save(xmlFilePath);
            return true;
        }
        public static BooleanMsg SerializeLocalDataToXml()
        {
            string xmlFilePath = @".\data.xml";

            if (!File.Exists(@".\data.xml"))
            {
                LocalData data = new LocalData();

                XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
                using (TextWriter writer = new StreamWriter(xmlFilePath))
                {
                    serializer.Serialize(writer, data);
                }
            }
            return true;
        }
        public static BooleanMsg SerializeServerDataToXml()
        {
            string xmlFilePath = @".\ServerDetails.xml";
            if (!File.Exists(xmlFilePath))
            {
                XmlDocument document = new XmlDocument();
                XmlElement root = document.CreateElement("document");
                document.AppendChild(root);

                // Create child elements
                XmlElement IpAddress = document.CreateElement("IpAddress");
                IpAddress.InnerText = "3306";
                root.AppendChild(IpAddress);

                XmlElement port = document.CreateElement("Port");
                port.InnerText = "3306";
                root.AppendChild(port);

                XmlElement UId = document.CreateElement("UId");
                UId.InnerText = "root";
                root.AppendChild(UId);

                XmlElement pwd = document.CreateElement("Password");
                pwd.InnerText = "";
                root.AppendChild(pwd);

                document.Save(xmlFilePath);
            }
            return true;
        }
        public static string ReadServerConnectionString()
        {
            string xmlFilePath = @".\ServerDetails.xml";
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            string IpAddress = document.GetElementsByTagName("IpAddress").Item(0).InnerText;
            string Port = document.GetElementsByTagName("Port").Item(0).InnerText;
            string UId = document.GetElementsByTagName("UId").Item(0).InnerText;
            string Password = document.GetElementsByTagName("Password").Item(0).InnerText;

            string connectionString = $"server={IpAddress};port={Port};uid={UId};pwd={Password};database=IpMessagingServer;charset=utf8mb4";

            return connectionString;
        }
        public static void UpdateServerData(string IpAddress, string Port, string UId, string Password)
        {
            string xmlFilePath = @".\ServerDetails.xml";
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            document.GetElementsByTagName("IpAddress").Item(0).InnerText = IpAddress;
            document.GetElementsByTagName("Port").Item(0).InnerText = Port;
            document.GetElementsByTagName("UId").Item(0).InnerText = UId;
            document.GetElementsByTagName("Password").Item(0).InnerText = Password;
            document.Save(xmlFilePath);
        }

        public static string GetImagePath()
        {
            string NetworkPath = @"~\";
            NetworkPath = Path.Combine(NetworkPath, "Images");
            return NetworkPath;
        }
        public static void UploadImage(Image image)
        {

        }

        public static BooleanMsg CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    // Create the folder
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch (Exception ex)
                {
                    return $"Error creating folder: {ex.Message}";
                }
            }
            return "Folder Already Exists";
        }

        #endregion

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
                    ReadClient(ip.ToString()).Value.StatusChanger(false);
                    ReadClient(ip.ToString()).Value.IsConnected = false;
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
                ReadMessage(msg.Id).Value.IsReadedInvoker();
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

        public static BooleanMsg<Client> ReadClient(string Ip)
        {

            if (!Clients.ContainsKey(Ip)) return "Invalid Client Address";
            Client clt = Clients[Ip];
            return clt;
        }

        public static BooleanMsg UpdateClient(Client client)
        {
            using (ServerDb server = new ServerDb())
            {
                Client client1 = server.Clients.FirstOrDefault(clt => clt.IP == client.IP);
                if (client1 == null) return "Invalid Client";
                server.Remove(client1);
                server.SaveChanges();
                server.Add(client);
                server.SaveChanges();
                Clients[client.IP] = client1;
                return true;
            }
        }

        public static BooleanMsg<Client> GetClientAtInstance(string Ip)
        {
            using (ServerDb server = new ServerDb())
            {
                Client clt = server.Clients.FirstOrDefault(clt => clt.IP == Ip);
                if (clt == null) return "Invalid Client";
                return clt;
            }
        }
        #endregion

        #region Messages
        public static Dictionary<string, MessageModel> ReadAllMessages()
        {
            return Messages;
        }

        public static List<MessageModel> ReadMessages(string FromIp, string ToIP)
        {
            return ReadAllMessages().Values.ToList().Where((msg) =>
            {
                return (msg.FromIP.Equals(FromIp) && msg.ReceiverIP.Equals(ToIP)) || (msg.FromIP.Equals(ToIP) && msg.ReceiverIP.Equals(FromIp));
            }).ToList();
        }
        public static BooleanMsg<MessageModel> ReadMessage(string messageId)
        {
            using (LocalDb local = new LocalDb())
            {
                MessageModel msg = Messages[messageId];
                if (msg == null) return "Invalid Message";
                return msg;
            }
        }
        public static BooleanMsg CreateMessage(MessageModel msg)
        {
            if (Messages.ContainsKey(msg.Id)) return "Message already Exists";
            using (LocalDb local = new LocalDb())
            {
                local.Messages.Add(msg);
                local.SaveChanges();
                Messages.Add(msg.Id, msg);
                return true;
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
                local.Messages.Remove(msg);
                local.SaveChanges();
                local.Messages.Add(message);
                local.SaveChanges();
                Messages[message.Id] = message;
            }
        }
        #endregion


    }
}




