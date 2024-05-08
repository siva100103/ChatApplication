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
using WindowsFormsApp3;

namespace ChatApplication.Controller
{
    public static class LocalDatabase
    {
        public static Dictionary<string, Message> Messages { get; set; } = new Dictionary<string, Message>();
        private static DatabaseManager Manager = new MySqlHandler();

        public static bool LocalDatabaseInitializer()
        {
            string xmlFilePath = @".\data.xml";
            LocalData data;
            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextReader reader = new StreamReader(xmlFilePath))
            {
                data = (LocalData)serializer.Deserialize(reader);
            }
            Manager.Database = $"{data.Database}";
            Manager.HostName = $"{data.Server}";
            Manager.UserName = $"{data.Uid}";
            Manager.Password = $"{data.Password}";

            using (var rem = new ServerDatabase())
            {
                Client me = rem.Clients.ToList().Find((c) => c.IP.Equals(ChatApplicationNetworkManager.LocalIpAddress));
                if (me != null)
                {
                    if (!me.Password.Equals(Manager.Password) || me.Password == null)
                    {
                        me.Password = Manager.Password;
                        rem.SaveChanges();
                    }
                }
            }
            var DBcreation = Manager.CheckAndCreateDatabase();

            var ConnectionStatus = Manager.Connect();

            if (!ConnectionStatus.Result)
            {
                return false;
            }

            if (!Manager.TableExists("Messages"))
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
                var c = Manager.CreateTable("Messages", Column);
            }
            FetchDb();
            return true;
        }

        public static void FetchDb()
        {
            var a = Manager.FetchData("Messages", "");

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
                    Messages.Add(m.Id, m);
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
            Manager.InsertData("Messages", data);
            Messages.Add(m.Id, m);
        }

        public static void UpdateMessage(Message m)
        {
            string condition = $"Id='{m.Id}'";
            ParameterData[] data = new ParameterData[] {
                new ParameterData("Seen",m.Seen.ToInt32())
            };
            Manager.UpdateData("Messages", condition, data);
        }

        public static void DeleteMessage(string id)
        {
            Manager.DeleteData("Messages", $"Id='{id}'");
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
            Manager.UpdateData("Messages", condition, data);
        }
    }
}
