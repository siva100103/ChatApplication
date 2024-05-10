using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GoLibrary;
using DatabaseLibrary;
using MySql.Data.MySqlClient;

namespace ChatApplication.Managers
{
    public static class DbManager
    {
        public static Dictionary<string, Message> Messages { get; set; } = new Dictionary<string, Message>();
        public static Dictionary<string, Client> Clients { get; set; } = new Dictionary<string, Client>();

        private static DatabaseManager LocalDbManager = new MySqlHandler();
        private static DatabaseManager ServerDbManager = new MySqlHandler();

        #region ServerDatabase Operations
        public static bool ServerDbConfig()
        {
            ServerDbManager.Database = "chatApplicationServer";
            ServerDbManager.HostName = "192.168.3.155";
            ServerDbManager.UserName = "root";
            ServerDbManager.Password = "";

            var ConnectionStatus = ServerDbManager.Connect();
            FetchServerDb();
            return true;
        }

        private static void FetchServerDb()
        {
            var data = ServerDbManager.FetchData("Clients", "");

            if (data.Value.Count > 0)
            {
                for (int i = 0; i < data.Value["IP"].Count; i++)
                {
                    string path = data.Value["ProfilePath"][i].ToString().Replace('~', '\\');
                    Client clt = new Client(data.Value["IP"][i].ToString(), data.Value["Name"][i].ToString(), (int)data.Value["Port"][i], DateTime.Parse(data.Value["LastSeen"][i].ToString()), path, data.Value["About"][i].ToString());
                    Clients.Add(clt.IP, clt);
                }
            }
        }

        public static void AddClient(Client c)
        {
            string path = $@"{c.ProfilePath}";
            path = path.Replace('\\', '~');
            ParameterData[] pd = new ParameterData[]
            {
               new ParameterData("IP",c.IP),
               new ParameterData("Name",c.Name),
               new ParameterData("Port",c.Port),
               new ParameterData("LastSeen",c.LastSeen),
               new ParameterData("ProfilePath",@path),
               new ParameterData("Password",c.Password),
               new ParameterData("About",c.About),
               new ParameterData("UnseenMessages",c.UnseenMessages)
            };
            ServerDbManager.InsertData("Clients", pd);
            Clients.Add(c.IP, c);

        }

        public static void UpdateClient(Client c)
        {
            string path = $@"{c.ProfilePath}";
            path = path.Replace('\\', '~');
            ParameterData[] pd = new ParameterData[]
            {
               new ParameterData("Name",c.Name),
               new ParameterData("Port",c.Port),
               new ParameterData("LastSeen",c.LastSeen),
               new ParameterData("ProfilePath",path),
               new ParameterData("Password",c.Password),
               new ParameterData("About",c.About),
               new ParameterData("UnseenMessages",c.UnseenMessages)
            };
            ServerDbManager.UpdateData("Clients", $"IP='{c.IP}'", pd);
        }

        public static Client GetClientAtInstance(string Ip)
        {
            var data = ServerDbManager.FetchData("Clients", $"IP='{Ip}'");
            int i = 0;
            if (data.Value != null)
            {
                string path = data.Value["ProfilePath"][i].ToString().Replace('~', '\\');
                Client clt = new Client(data.Value["IP"][i].ToString(), data.Value["Name"][i].ToString(), (int)data.Value["Port"][i], DateTime.Parse(data.Value["LastSeen"][i].ToString()), path, data.Value["About"][i].ToString());
                return clt;
            }
            return null;
        }
        #endregion

        #region LocalDatabase Operations
        public static bool LocalDbConfig()
        {
            #region LocalDb
            string xmlFilePath = @".\data.xml";
            LocalData data;
            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextReader reader = new StreamReader(xmlFilePath))
            {
                data = (LocalData)serializer.Deserialize(reader);
            }
            LocalDbManager.Database = $"{data.Database}";
            LocalDbManager.HostName = $"{data.Server}";
            LocalDbManager.UserName = $"{data.Uid}";
            LocalDbManager.Password = $"{data.Password}";


            Client me = Clients[ChatApplicationNetworkManager.LocalIpAddress];
            if (me != null)
            {
                if (!me.Password.Equals(LocalDbManager.Password) || me.Password == null)
                {
                    me.Password = LocalDbManager.Password;
                    string condition = $"IP='{me.IP}'";
                    ParameterData[] pd = new ParameterData[]
                     {
                            new ParameterData("Password",LocalDbManager.Password)
                     };
                    ServerDbManager.UpdateData("Clients", condition, pd);
                }
            }

            var DBcreation = LocalDbManager.CheckAndCreateDatabase();

            var ConnectionStatus = LocalDbManager.Connect();

            if (!ConnectionStatus.Result)
            {
                return false;
            }

            if (!LocalDbManager.TableExists("Messages"))
            {
                ColumnDetails[] Column = new ColumnDetails[]
                {
                    new ColumnDetails("Id",BaseDatatypes.VARCHAR,length:100,notNull:true),
                    new ColumnDetails("FromIP",BaseDatatypes.VARCHAR,length:100,notNull:true),
                    new ColumnDetails("ReceiverIP",BaseDatatypes.VARCHAR,length:100,notNull:true),
                    new ColumnDetails("Msg",BaseDatatypes.VARCHAR,length:1000),
                    new ColumnDetails("Time",BaseDatatypes.DATETIME,notNull:true),
                    new ColumnDetails("Seen",BaseDatatypes.TINYINT),
                    new ColumnDetails("Starred",BaseDatatypes.TINYINT),
                };
                var c = LocalDbManager.CreateTable("Messages", Column);
            }
            FetchLocalDb();
            return true;
            #endregion
        }

        public static void FetchLocalDb()
        {
            var a = LocalDbManager.FetchData("Messages", "");

            if (a.Value.Count > 0)
            {
                for (int i = 0; i < a.Value["Id"].Count; i++)
                {
                    Message m = new Message()
                    {
                        Id = a.Value["Id"][i].ToString(),
                        FromIP = a.Value["FromIP"][i].ToString(),
                        ReceiverIP = a.Value["ReceiverIP"][i].ToString(),
                        Msg = a.Value["Msg"][i].ToString(),
                        Time = (DateTime)a.Value["Time"][i],
                        Seen = a.Value["Seen"][i].ToBoolean(),
                        Starred = a.Value["Starred"][i].ToBoolean()
                    };
                    if (!Messages.ContainsKey(m.Id))
                    {
                        Messages.Add(m.Id, m); 
                    }
                }
            }
        }

        public static void CreateMessage(Message m)
        {
            ParameterData[] data = new ParameterData[] {
                new ParameterData("Id", m.Id),
                new ParameterData("FromIP",m.FromIP),
                new ParameterData("ReceiverIP",m.ReceiverIP),
                new ParameterData("Msg",m.Msg),
                new ParameterData("Time",m.Time),
                new ParameterData("Seen",m.Seen.ToInt32()),
                new ParameterData("Starred",m.Starred.ToInt32())
            };
            LocalDbManager.InsertData("Messages", data);
            Messages.Add(m.Id, m);
        }

        public static void UpdateMessage(Message m)
        {
            string condition = $"Id='{m.Id}'";
            ParameterData[] data = new ParameterData[] {
                new ParameterData("FromIP",m.FromIP),
                new ParameterData("ReceiverIP",m.ReceiverIP),
                new ParameterData("Msg",m.Msg),
                new ParameterData("Time",m.Time),
                new ParameterData("Seen",m.Seen.ToInt32()),
                new ParameterData("Starred",m.Starred.ToInt32())
            };
            LocalDbManager.UpdateData("Messages", condition, data);
        }

        public static void DeleteMessage(string id)
        {
            LocalDbManager.DeleteData("Messages", $"Id='{id}'");
            if (Messages.ContainsKey(id)) Messages.Remove(id);
        }

        public static void DeleteMessages(IEnumerable<string> Messageid)
        {
            foreach (var id in Messageid)
            {
                if (Messages.ContainsKey(id)) Messages.Remove(id);
            }
        }

        public static void StarMessages(Message message)
        {
            string condition = $"Id = '{message.Id}'";
            ParameterData[] data = new ParameterData[]
            {
                new ParameterData("Starred" , message.Starred.ToInt32())
            };
            LocalDbManager.UpdateData("Messages", condition, data);
        } 
        #endregion


    }
}
