using ChatApplication.Controller;
using Newtonsoft.Json;
using System;
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
        public static MessagePage MessagePage = null;
        public static string FromIPAddress { get; set; }



        public static Dictionary<string, Client> Clients { get; set; } = new Dictionary<string, Client>();
        public static TcpListener Listener;

        public static Dictionary<String, Message> Messages { get; set; } = new Dictionary<String, Message>();

        public static void Initialize()
        {
            FromIPAddress = GetLocalIPAddress();
            using (var DbContext=new RemoteDatabase())
            {
                foreach(var c in DbContext.Clients.ToList())
                {
                    if(!c.IP.Equals(FromIPAddress)) Clients.Add(c.IP,new Client(c.IP,c.Name,c.Port));
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
            string msg = JsonConvert.SerializeObject(message);
            byte[] data = Encoding.UTF8.GetBytes(msg);
            await Stream.WriteAsync(data, 0, data.Length);
            message.IsSendedInvoker();
            if (message.type == Type.File)
            {
                FileStream fileStream = File.OpenRead(message.Msg);
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    await Stream.WriteAsync(buffer, 0, bytesRead);
                }

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
                Message msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(buffer));

                if(msg.type==Type.Response) HandleResponses(msg);
                #region File Share
                //else if (msg.type == Type.File)
                //{
                //    // Receive file name
                //    byte[] fileNameLengthBytes = new byte[4];
                //    await stream.ReadAsync(fileNameLengthBytes, 0, 4);
                //    int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);
                //    byte[] fileNameBytes = new byte[fileNameLength];
                //    await stream.ReadAsync(fileNameBytes, 0, fileNameLength);
                //    string fileName = Encoding.UTF8.GetString(fileNameBytes);

                //    // Create the directory if it doesn't exist
                //    string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                //    string chatApplicationPath = Path.Combine(downloadsPath, "Chat Application");
                //    Directory.CreateDirectory(chatApplicationPath);

                //    // Construct the full file path
                //    string filePath = Path.Combine(chatApplicationPath, fileName);

                //    // Receive file content and write it to the file
                //    using (FileStream fileStream = File.Create(filePath))
                //    {
                //        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                //        {
                //            await fileStream.WriteAsync(buffer, 0, bytesRead);
                //        }
                //    }
                //}
                #endregion
                else HandleMessages(msg);
            }
            AcceptClient();
        }

        private static void HandleResponses(Message msg)
        {
            if (msg.Msg.Equals("Close"))
            {
                Client clt = Clients[msg.FromIP];
                clt.StatusChanger(false);
            }
            else if (msg.Msg.Equals("Open"))
            {
                Client clt = Clients[msg.FromIP];
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
