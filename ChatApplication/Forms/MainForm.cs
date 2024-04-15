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
        private List<ContactU> Contacts = new List<ContactU>();

        public MainForm()
        {
            InitializeComponent();
            Initial();

            SideMenuBar.OnClickProfilePicture += OnProfileInfoClick;

            MyProfile = new ProfilePage
            {
                Size = new Size((Width * 74) / 100, (Height * 62) / 100),
                StartPosition = FormStartPosition.Manual,
                BackColor = Color.FromArgb(207, 227, 251),
                UserName = MyDetails.Clients.ToList().Find(c => c.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))?.Name,
            };
            MyProfile.ProfileChoosen += MyProfileProfileChoosen;
            ChatApplicationNetworkManager.Inform += ChatApplicationNetworkManagerInform;

            SearchBox.OnTextChange += SearchBoxOnTextChanged;
        }

        private void SearchBoxOnTextChanged(object sender, EventArgs e)
        {
            if (Contacts.Count > 0 && SearchBox.PlaceholderText != "Search or start new chat")
            {
                foreach (ContactU contact in Contacts)
                {
                    if (SearchBox.PlaceholderText != "")
                    {
                        if (contact.UserName.IndexOf
                            (SearchBox.PlaceholderText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            contact.Visible = true;
                        }
                        else
                        {
                            contact.Visible = false;
                        } 
                    }
                    else
                    {
                        contact.Visible = true;
                    }
                }
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
            foreach (var dict in e)
            {
                path = dict.Key;
                pic = dict.Value;
            }
            SideMenuBar.ProfileImage = pic;
            foreach (var client in MyDetails.Clients.ToList())
            {
                if (client.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))
                {
                    client.ProfilePath = path;
                    MyDetails.SaveChanges();
                }
            }
        }

        private void ChatApplicationNetworkManagerInform(ContactU label)
        {
            chatContactPanel.Controls.Add(label);
            label.Clicked += PageAdd;
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
                ContactU contact = new ContactU(a.Value)
                {
                    Dock = DockStyle.Top,
                    BackColor = Color.FromArgb(240, 243, 253)
                };
                //ct.Add(con);
                chatContactPanel.Controls.Add(contact);
                contact.Clicked += PageAdd;
                Contacts.Add(contact);
            }
            LocalStorage ls = new LocalStorage();
            ChatApplicationNetworkManager.Messages = ls.Messages.ToDictionary((msg) => msg.Id);
        }

        private void OptionButtonClick(object sender, EventArgs e)
        {
            SideMenuBar.Visible = !SideMenuBar.Visible;
            MyProfile.Visible = false;
        }

        protected async override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            foreach (var a in ChatApplicationNetworkManager.Clients)
            {
                Message msg = new Message(ChatApplicationNetworkManager.FromIPAddress, a.Value.IP, "Close", DateTime.Now, Type.Response);
                if (a.Value.IsConnected)
                {
                    await ChatApplicationNetworkManager.SendMessage(msg, a.Value);
                }
            }
        }
    }
}
