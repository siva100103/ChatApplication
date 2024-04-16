using ChatApplication.Models;
using DatabaseLibrary;
using GoLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChatApplication.Controller
{
    class LocalStorage
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        private static DatabaseManager Manager = new MySqlHandler();
        public LocalStorage()
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

            var bol=Manager.CheckAndCreateDatabase();
            if (!bol.Result)
            {

            }
            Manager.Connect();
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
                };
                var c=Manager.CreateTable("Messages",Column);
            }
            FetchDb();
        }

        public void FetchDb()
        {
            var a = Manager.FetchData("Messages", "");

            try
            {
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
                            Seen = a.Value["Seen"][i].ToBoolean()
                        };
                        Messages.Add(m);
                    }
                }
            }
            catch
            { 
            }
        }

        public void InsertMessage(Message m)
        {
            ParameterData[] data = new ParameterData[] {
                new ParameterData("Id", m.Id),
                new ParameterData("FromIP",m.FromIP),
                new ParameterData("ReceiverIP",m.ReceiverIP),
                new ParameterData("Msg",m.Msg),
                new ParameterData("Time",m.Time),
                new ParameterData("Seen",m.Seen.ToInt32())
            };
            Manager.InsertData("Messages",data);
            
        }
        
        public void UpdateMessage(Message m)
        {
            string condition = $"Id='{m.Id}'";
            ParameterData[] data = new ParameterData[] {
                new ParameterData("Id", m.Id),
                new ParameterData("FromIP",m.FromIP),
                new ParameterData("ReceiverIP",m.ReceiverIP),
                new ParameterData("Msg",m.Msg),
                new ParameterData("Time",m.Time),
                new ParameterData("Seen",m.Seen.ToInt32())
            };

            var a=Manager.UpdateData("Messages",condition,data);
        }
    }
}
