using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;
using ChatApplication.Controller;
using System.IO;
using System.Xml.Serialization;
using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication
{
    public partial class LoginForm : Form
    {

        public LoginForm(string IPAddress)
        {
            InitializeComponent();
            label1.Text = IPAddress;
            Resize += LoginFormResize;
            LoginFormResize(this, EventArgs.Empty);
            nextBtn.Click += NextBtnClick;
            Load += LoginFormLoad;
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
            // ipAddressLB.Text += ChatApplicationNetworkManager.GetPcIPAddress();
            LoginFormResize(this, EventArgs.Empty);
        }

        private void NextBtnClick(object sender, EventArgs e)
        {
            if (firstNameTB.TextBoxtext.Trim() != "" && lastNameTB.TextBoxtext.Trim() != "")
            {
                Client c = new Client()
                {
                    IP = label1.Text,
                    Name = firstNameTB.TextBoxtext.Trim() + " " + lastNameTB.TextBoxtext.Trim(),
                    LastSeen = DateTime.Now,
                    Port = 12346,
                };

                if(!File.Exists(@".\data.xml"))
                SerializeLocalDataToXml();

                using (var clients = new ServerDatabase())
                {
                    clients.Clients.Add(c);
                    clients.SaveChanges();
                }
                this.Hide();
                MainForm mf = new MainForm();
                mf.Show();
                mf.FormClosed += (obj, ev) => Close();       
            }
        }

        private void SerializeLocalDataToXml()
        {
            string xmlFilePath = @".\data.xml";

            LocalData data = new LocalData();

            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        private void LoginFormResize(object sender, EventArgs e)
        {
            centerP.Location = new Point(Width / 2 - centerP.Width / 2, Height / 2 - centerP.Height / 2);
            firstNameTB.Location = new Point(centerP.Width / 2 - firstNameTB.Width / 2, firstNameTB.Location.Y);
            lastNameTB.Location = new Point(centerP.Width / 2 - lastNameTB.Width / 2, lastNameTB.Location.Y);
            //ipAddressLB.Location = new Point(centerP.Width / 2 - ipAddressLB.Width / 2, ipAddressLB.Location.Y);
            dpPictureU.Location = new Point(centerP.Width / 2 - dpPictureU.Width / 2, dpPictureU.Location.Y);
            nextBtn.Location = new Point(centerP.Width / 2 - nextBtn.Width / 2, nextBtn.Location.Y);
            centerP.BringToFront();
        }


        private void CreateNew()
        {

        }

    }
}
