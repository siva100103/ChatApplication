using ChatApplication.Managers;
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
using ChatApplication.Forms;
using System.Runtime.Versioning;

namespace ChatApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        [SupportedOSPlatform("windows")]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(@".\data.xml"))
                SerializeLocalDataToXml();

            string IpAddress = GetLocalIPAddress();

            ChatApplicationNetworkManager.LocalIpAddress = IpAddress;
            ChatApplicationNetworkManager.DataBaseConfiguration();


            if (!ChatApplicationNetworkManager.ReadAllClients().ContainsKey(IpAddress))
            {
                Application.Run(new LoginForm(IpAddress));
            }
            else
            {
                if (ChatApplicationNetworkManager.StartListener())
                    Application.Run(new MainForm());
                else
                {
                    DialogResult dialog = MessageBox.Show("Invalid Credentials \nPlease Check data.xml", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
