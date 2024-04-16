using DatabaseLibrary;
using GoLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3;

namespace ChatApplication.Controller
{
    class RemoteDatabase
    {
        private static DatabaseManager Manager = new MySqlHandler();
        public RemoteDatabase(string IpAddress)
        {
            Client c = ChatApplicationNetworkManager.Clients[IpAddress];
            Manager.HostName = c.IP;
            Manager.Database = "ChatApplication";
            Manager.UserName = "root";
            Manager.Password = c.Password;
            Manager.Connect();
        }

        public void UpdateMessage(Message m)
        {
            string condition = $"Id={m.Id}";

            ParameterData[] data = new ParameterData[] {
                new ParameterData("Id", m.Id),
                new ParameterData("FromIP",m.FromIP),
                new ParameterData("ReceiverIP",m.ReceiverIP),
                new ParameterData("Msg",m.Msg),
                new ParameterData("Time",m.Time),
                new ParameterData("Seen",m.Seen.ToInt32())
            };

            Manager.UpdateData("Messages", condition, data);
        }
    }
}
