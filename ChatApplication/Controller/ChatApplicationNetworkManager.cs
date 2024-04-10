using ChatApplication.Controller;
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
using WindowsFormsApp3;

namespace ChatApplication
{
    public static class ChatApplicationNetworkManager
    {
        public delegate void NewUserEnter();
        public static event NewUserEnter Inform;

        public static MessagePage MessagePage = null;
        public static string FromIPAddress { get; set; }

        public static List<ContactU> ContactLabels { get; set; } = new List<ContactU>();

        public static Dictionary<string, Client> Clients { get; set; } = new Dictionary<string, Client>();
        public static TcpListener Listener;

        public static Dictionary<String, Message> Messages { get; set; } = new Dictionary<String, Message>();

        public static void Initialize()
        {
            FromIPAddress = GetLocalIPAddress();
            using (var DbContext = new RemoteDatabase())
            {
                foreach (var c in DbContext.Clients.ToList())
                {
                    if (!c.IP.Equals(FromIPAddress))
                    {
                        Clients.Add(c.IP, new Client(c.IP, c.Name, c.Port));
                        Clients[c.IP].ProfilePath = c.ProfilePath;
                        if (c.ProfilePath != "")
                        {
                            Clients[c.IP].ProfilePicture = Image.FromFile(c.ProfilePath); 
                        }
                    }
                }
            }
            Listener = new TcpListener(IPAddress.Parse(FromIPAddress), 12345);
            Listener.Start();
            AcceptClient();
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

        public async static Task SendMessage(Message message, Client c)
        {
            TcpClient Sender = new TcpClient();
            await Sender.ConnectAsync(IPAddress.Parse(c.IP), c.Port);
            NetworkStream Stream = Sender.GetStream();
            if (message.type == Type.File)
            {
                using (FileStream fileStream = File.OpenRead(message.Msg))
                {
                    byte[] fileNameBytes = Encoding.UTF8.GetBytes(Path.GetFileName(message.Msg));
                    byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);

                    Stream.Write(fileNameLengthBytes, 0, 4);
                    Stream.Write(fileNameBytes, 0, fileNameBytes.Length);

                    // Read file content and write to the stream
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Stream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            else
            {
                string msg = JsonConvert.SerializeObject(message);
                byte[] data = Encoding.UTF8.GetBytes(msg);
                await Stream.WriteAsync(data, 0, data.Length);
                message.IsSendedInvoker();
            }
            if (message.type != Type.Response)
            {
                Messages.Add(message.Id, message);
                using (var a = new LocalDatabase())
                {
                    a.Messages.Add(message);
                    a.SaveChanges();
                }
            }
        }

        private async static void AcceptClient()
        {
            TcpClient client = await Listener.AcceptTcpClientAsync();
            HandleClient(client);
        }

        private async static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            if ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                try
                {
                    Message msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(buffer));

                    if (msg.type == Type.Response)
                    {
                        HandleResponses(msg);
                    }
                    else
                    {
                        HandleMessages(msg);
                    }
                }
                catch
                {
                   // HandleFile(client);
                }
            }

            AcceptClient();
        }

        private async static void HandleFile(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] fileNameLengthBytes = new byte[4];
            await stream.ReadAsync(fileNameLengthBytes, 0, 4);
            int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);
            byte[] fileNameBytes = new byte[14];
            await stream.ReadAsync(fileNameBytes, 0, fileNameLength);
            string fileName = Encoding.UTF8.GetString(fileNameBytes);

            string filePath = Path.Combine(@"C:\Users\Public\Downloads", fileName);

            using (FileStream fileStream = File.Create(filePath))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
        }

        private static void HandleResponses(Message msg)
        {
            if (!Clients.ContainsKey(msg.FromIP))
            {
                Client c = new RemoteDatabase().Clients.ToDictionary(c1 => c1.IP)[msg.FromIP];
                Client client = new Client(c.IP, c.Name, c.Port);
                Clients.Add(client.IP, client);
                ContactU label = new ContactU(client)
                {
                    Dock = System.Windows.Forms.DockStyle.Top,
                };
                ContactLabels.Add(label);
                Inform?.Invoke();
            }

            Client clt = Clients[msg.FromIP];

            if (msg.Msg.Equals("Close"))
            {
                clt.StatusChanger(false);
            }
            else if (msg.Msg.Equals("Open"))
            {
                clt.StatusChanger(true);
            }
            else
            {
                Messages[msg.Id].IsReaderInvoker();
            }
        }

        private async static void HandleMessages(Message msg)
        {
            Client clt = Clients[msg.FromIP];
            clt.MessagePage.AddMessage(msg);
            clt.UnSeenMessages.Add(msg);
            if (MessagePage != clt.MessagePage)
            {
                clt.UnseenMessages += 1;
                clt.UnSeenMessages.Add(msg);
            }
            else
            {
                Message m = new Message(msg)
                {
                    Msg = "Readed",
                    type = Type.Response
                };
                await SendMessage(m, Clients[m.FromIP]);
            }
            Messages.Add(msg.Id, msg);
            using (var c = new LocalDatabase())
            {
                c.Messages.Add(msg);
                c.SaveChanges();
            }
        }

        public static async void SendResponseForReadedMessage(List<Message> Readedmessages, Client c)
        {
            foreach (var msg in Readedmessages)
            {
                Message m = new Message(msg)
                {
                    type = Type.Response,
                    Msg = "Readed"
                };
                await SendMessage(m, c);
            }
            c.UnSeenMessages.Clear();
        }

        public static List<Message> GetMessages(string FromIp, string ToIP)
        {
            return new LocalDatabase().Messages.ToList().Where((msg) =>
            {
                return (msg.FromIP.Equals(FromIp) && msg.ReceiverIP.Equals(ToIP)) || (msg.FromIP.Equals(ToIP) && msg.ReceiverIP.Equals(FromIp));
            }).ToList();
        }
    }
}




