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

        public static void StartServer()
        {
            using (var DbContext = new RemoteDatabase())
            {
                foreach (var c in DbContext.Clients.ToList())
                {
                    if (!c.IP.Equals(FromIPAddress))
                    {
                        Clients.Add(c.IP, new Client(c.IP, c.Name, c.Port));
                        Clients[c.IP].ProfilePath = c.ProfilePath;
                        Clients[c.IP].About = c.About;
                        if (c.ProfilePath != "")
                        {
                            Clients[c.IP].ProfilePicture = Image.FromFile(c.ProfilePath);
                        }
                    }
                }
                string.Join(",", Clients);
            }
            Listener = new TcpListener(IPAddress.Parse(FromIPAddress), 12346);
            Listener.Start();
            AcceptClient();
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

                if (msg.type == Type.Response)
                {
                    HandleResponses(msg);
                }
                else if(msg.type == Type.File)
                {
                    HandleFile(msg);
                }
                else
                {
                    HandleMessages(msg);
                }
            }

            AcceptClient();
        }

        private async static void HandleFile(Message msg)
        {
            Client clt = Clients[msg.FromIP];
            clt.MessagePage.AddMessage(msg);
            clt.UnSeenMessages.Add(msg);
            //string path = msg.Msg;
            //string savePath = @"C:\Users\Public\Downloads\";
            //string newfilePath = Path.Combine(savePath, Path.GetFileNameWithoutExtension(path) + Path.GetExtension(path));
            ////File.Copy(msg.Msg, newfilePath);
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

        private static void HandleResponses(Message msg)
        {
            if (!Clients.ContainsKey(msg.FromIP) && !msg.FromIP.Equals(FromIPAddress))
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




