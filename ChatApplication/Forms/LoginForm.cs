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
        private string DpPicturePath = "";
        public event EventHandler Dp;

        public LoginForm(string IPAddress)
        {
            InitializeComponent();
            label1.Text = IPAddress;
            dpPictureU.OnClickDpPicturePathGet += DpPicturePathGet;
        }

        private void DpPicturePathGet(object sender, string path)
        {
            Image dp = Image.FromFile(path);
            string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
            string newfilePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(path) + Path.GetExtension(path));
            DpPicturePath = newfilePath;
            using (var bmp = new Bitmap(dp))
            {
                bmp.Save(newfilePath);
            }
            //dp.Save(newfilePath);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            Resize += LoginFormResize;
            nextBtn.Click += NextBtnClick;
        }
        private void NextBtnClick(object sender, EventArgs e)
        {
            if (firstNameTB.TextBoxtext.Trim() != "" && lastNameTB.TextBoxtext.Trim() != "")
            {
                Client c = new Client()
                {
                    IP = label1.Text,
                    ProfilePath = DpPicturePath,
                    Name = firstNameTB.TextBoxtext.Trim() + " " + lastNameTB.TextBoxtext.Trim(),
                    LastSeen = DateTime.Now,
                    Port = 12346,
                };

                               
                Hide();

                if (!ChatApplicationNetworkManager.ManagerInitializer())
                {
                    DialogResult dialog = MessageBox.Show("Invalid Credentials \nPlease Check data.xml", "WARNING",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialog == DialogResult.OK)
                    {
                        Close();
                        return;
                    }
                }

                MainForm mainForm = new MainForm();
                mainForm.Show();
                mainForm.FormClosed += (obj, ev) => Close();
                using (var clients = new ServerDatabase())
                {
                    clients.Clients.Add(c);
                    clients.SaveChanges();
                }
                mainForm.DpSetFirstTime();
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
    }
}
