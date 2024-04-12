using ChatApplication.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;
using System.Xml.Serialization;
using System.IO;

namespace ChatApplication
{
    public partial class MainForm : Form
    {
        #region Curve Dll
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion
        private ProfilePage MyProfile;
        private RemoteDatabase MyDetails = new RemoteDatabase();
        private bool click = false;
        public MainForm()
        {
            InitializeComponent();
            //SerializeLocalDataToXml();
            Initial();
            SideMenuBar.OnClickProfilePicture += OnProfileInfoClick;
            //SideMenuBar.ProfileImage = Image.FromFile(MyDetails.Clients.ToList().Find(c => c.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))?.ProfilePath);

            MyProfile = new ProfilePage
            {
                Size = new Size((Width * 74) / 100, (Height * 62) / 100),
                StartPosition = FormStartPosition.Manual,
                UserName = MyDetails.Clients.ToList().Find(c => c.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))?.Name,
            };
            MyProfile.ProfileChoosen += MyProfileProfileChoosen;
            ChatApplicationNetworkManager.Inform += ChatApplicationNetworkManagerInform;
        }

        private void SerializeLocalDataToXml()
        {
            string xmlFilePath =@".\data.xml";

            LocalData data = new LocalData();

            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var client in MyDetails.Clients.ToList())
            {
                if (client.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))
                {
                    if (client.ProfilePath != "")
                    {
                        SideMenuBar.ProfileImage = Image.FromFile(client.ProfilePath);
                        MyProfile.ProfilePhoto = SideMenuBar.ProfileImage; 
                    }
                    MyProfile.About = client.About;
                    break;
                }
            }
        }

        private void MyProfileProfileChoosen(object sender, Dictionary<string, Image> e)
        {
            string path = "";
            Image pic = null;
            foreach(var dict in e)
            {
                path = dict.Key;
                pic = dict.Value;
            }
            SideMenuBar.ProfileImage = pic;
            foreach(var client in MyDetails.Clients.ToList())
            {
                if(client.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))
                {
                    client.ProfilePath = path;
                    MyDetails.SaveChanges();
                }
            }
        }

        private void ChatApplicationNetworkManagerInform()
        {
            chatContactPanel.Controls.Clear();
            foreach(var a in ChatApplicationNetworkManager.ContactLabels)
            {
                chatContactPanel.Controls.Add(a);
                a.Clicked += PageAdd;
            }
        }

        private void OnProfileInfoClick(object sender, EventArgs e)
        {
            Point location = PointToScreen(SideMenuBar.Location);
            location.Offset(SideMenuBar.Width + 10, SideMenuBar.Height - MyProfile.Height - 20);
            MyProfile.Location = location;
            if (!click)
            {
                MyProfile.Visible = true;
            }
            else
            {
                MyProfile.Visible = false;
            }
            click = !click;
        }

        private void PageAdd(object sender, EventArgs e)
        {
            MessagePagePanel.Controls.Clear();
            MessagePage page = (sender as Client).MessagePage;
            page.ProfileImage = (sender as Client).ProfilePicture;
            if (page != null)
            {
                page.Dock = DockStyle.Fill;
                MessagePagePanel.Controls.Add(page);
            }
        }

        public void Initial()
        {
            ChatApplicationNetworkManager.StartServer();
            foreach (var a in ChatApplicationNetworkManager.Clients)
            {
                ContactU con = new ContactU(a.Value)
                {
                    Dock = DockStyle.Top
                };
                //ct.Add(con);
                chatContactPanel.Controls.Add(con);
                con.Clicked += PageAdd;
            }

        }

        protected async override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
  
            foreach (var a in ChatApplicationNetworkManager.Clients)
            {
                Message msg = new Message(ChatApplicationNetworkManager.FromIPAddress,a.Value.IP, "Close", DateTime.Now, Type.Response);
                if (a.Value.IsConnected)
                {
                    await ChatApplicationNetworkManager.SendMessage(msg, a.Value);
                }
            }
        }
    }
}
