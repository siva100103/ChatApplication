using ChatApplication.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string IpAddress = ChatApplicationNetworkManager.GetLocalIPAddress().ToString();
            using (var db =new RemoteDatabase())
            {
                if (!db.Clients.ToDictionary(c => c.IP).ContainsKey(IpAddress))
                {
                    using (var LocalDatabase = new LocalDatabase())
                    {
                        LocalDatabase.Database.EnsureCreated();
                        LocalDatabase.Database.Migrate();
                    }
                    Application.Run(new LoginForm(IpAddress));
                }
                else
                {
                    Application.Run(new MainForm());
                }
            }

        }

    }
}
