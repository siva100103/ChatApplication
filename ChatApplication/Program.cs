using ChatApplication.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

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

            string IpAddress = GetLocalIPAddress();
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
                    ChatApplicationNetworkManager.FromIPAddress = IpAddress;
                    //ChatApplicationNetworkManager.Initialize();
                    Application.Run(new MainForm());
                }
            }

        }

        private static string GetLocalIPAddress()
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


    }
}
