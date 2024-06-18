using ChatApplication.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ChatApplication.Forms
{
    public partial class ServerDetailsForm : Form
    {
        public ServerDetailsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MessageBox.Show("It Seems Like Your Server Was Not Set Properly.Please Fill The Form To fill The Server Details."
                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            string IpAddress=IpTextBox.Text;
            string Port=PortNumericUpDown.Value.ToString();
            string UId=UidTextBox.Text;
            string Password=PasswordTextBox.Text;
            if (IpAddress == "" || Port == "" || UId == "")
            {
                MessageBox.Show("Please Fill the Required Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            ChatApplicationNetworkManager.UpdateServerData(IpAddress, Port, UId, Password);

            if (IpAddress == ChatApplicationNetworkManager.GetLocalIPAddress())
            {
                if (!ChatApplicationNetworkManager.FetchClients(true))
                {
                    MessageBox.Show("No Server Found Please Enter Correct Server Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("It seems like you choose your own pc as server.So choose the folder to store the resource",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult result=folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string ResourceFolder = folderBrowserDialog.SelectedPath;
                    string ResourcePath = Path.Combine(ResourceFolder, "IpMessagingResources");               
                    ChatApplicationNetworkManager.CreateFolder(ResourcePath);
                    AddResourceDetails(ResourcePath);

                }
                else
                {
                   
                    return;
                }
            }
            else
            {
                if(!ChatApplicationNetworkManager.FetchClients()){
                    MessageBox.Show("No Server Found Please Enter Correct Server Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Close();
        }

        private void AddResourceDetails(string path)
        {
            string xmlFilePath = @".\ServerDetails.xml";
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);

            XmlElement RootElement=document.DocumentElement;

            XmlElement ResourcePath = document.CreateElement("ResourcePath");
            ResourcePath.InnerText = path;
            RootElement.AppendChild(ResourcePath);

            document.Save(xmlFilePath);
        }
    }
}
