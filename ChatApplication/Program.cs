using ChatApplication.Forms;
using ChatApplication.Managers;
using ChatApplication.Models;
using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication
{
    [SupportedOSPlatform("windows")]

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

            BooleanMsg DbConfig = ChatApplicationNetworkManager.DataBaseConfiguration();

            if (DbConfig) StartApp();
            else if (DbConfig.Message == "Fetching Messages Failed") Application.Run(new DataBaseDetailsForm());
            else if (DbConfig.Message == "Fetching Clients Failed") Application.Run(new ServerDetailsForm());
        }

        private static void StartApp()
        {
            string IpAddress = ChatApplicationNetworkManager.LocalIpAddress;
            BooleanMsg UserExist = ChatApplicationNetworkManager.ReadClient(IpAddress);
            if (UserExist) Application.Run(new MainForm());
            else Application.Run(new LoginForm(IpAddress));
        }

    }
}
