using ChatApplication.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;
using ChatApplication.Models;
using System.Xml.Serialization;

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
            ChatApplicationNetworkManager.FromIPAddress = IpAddress;

            if (!File.Exists(@".\data.xml"))
                SerializeLocalDataToXml();
            using (var db = new ServerDatabase())
            {
                //if (!db.Clients.ToDictionary(c => c.IP).ContainsKey(IpAddress))
                //{
                //    Application.Run(new LoginForm(IpAddress));
                //}
                if(!db.ServerInitialize())
                {
                    Application.Run(new LoginForm(IpAddress));
                }
                else
                {
                    if (ChatApplicationNetworkManager.ManagerInitializer())
                        Application.Run(new MainForm());
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Invalid Credentials \nPlease Check data.xml", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
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

        private static void SerializeLocalDataToXml()
        {
            string xmlFilePath = @".\data.xml";

            LocalData data = new LocalData();

            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer, data);
            }
        }
    }
}
