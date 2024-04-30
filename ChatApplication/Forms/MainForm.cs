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
        private ServerDatabase MyDetails = new ServerDatabase();
        private bool click = false;
        private List<ContactU> Contacts = new List<ContactU>();
        private Client Current;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //ChatApplicationNetworkManager.ManagerInitializer();
            LabelsAdder();
            SideMenuBar.OnClickProfilePicture += OnProfileInfoClick;
            SearchBox.OnTextChange += SearchBoxOnTextChange;

            MyProfile = new ProfilePage
            {
                Size = new Size((Width * 74) / 100, (Height * 62) / 100),
                StartPosition = FormStartPosition.Manual,
                UserName = MyDetails.Clients.ToList().Find(c => c.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))?.Name,
            };
            MyProfile.ProfileChoosen += MyProfileProfileChoosen;
            ChatApplicationNetworkManager.Inform += AddNewLabelForNewUser;

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

        public void DpSetFirstTime()
        {
            SuspendLayout();
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
            ResumeLayout();
        }

        private void SearchBoxOnTextChange(object sender, EventArgs e)
        {
            if (Contacts.Count > 0 && SearchBox.PlaceholderText != "Search or start new chat")
            {
                foreach (ContactU contact in Contacts)
                {
                    if (contact.UserName.IndexOf(SearchBox.PlaceholderText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        contact.Visible = true;
                    }
                    else
                    {
                        contact.Visible = false;
                    }
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

        private void AddNewLabelForNewUser(ContactU label)
        {
            SuspendLayout();
            chatContactPanel.Controls.Add(label);
            label.Clicked += MessagePageSwitcher;
            Contacts.Add(label);
            ResumeLayout();
        }

        private void OnProfileInfoClick(object sender, EventArgs e)
        {
            MyProfile.SuspendLayout();
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
            MyProfile.ResumeLayout();
        }

        private void MessagePageSwitcher(object sender, EventArgs e)
        {
            MessagePagePanel.SuspendLayout();
            Current = (sender as Client);
            if (Current != null)
            {
                MessagePagePanel.Controls.Clear();
                MessagePage page = Current.MessagePage;
                page.ProfileImage = Current.ProfilePicture;
                if (page != null)
                {
                    page.Dock = DockStyle.Fill;
                    MessagePagePanel.Controls.Add(page);
                }
            }
            MessagePagePanel.ResumeLayout();
        }

        private void LabelsAdder()
        {
            foreach (var a in ChatApplicationNetworkManager.Clients)
            {
                ContactU con = new ContactU(a.Value)
                {
                    Dock = DockStyle.Top,
                };
                chatContactPanel.Controls.Add(con);
                Panel space = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = 10
                };
                chatContactPanel.Controls.Add(space);
                con.Clicked += MessagePageSwitcher;
                Contacts.Add(con);
            }

        }

        private void OptionButtonClick(object sender, EventArgs e)
        {
            MessagePagePanel.SuspendLayout();
            ChatPanel.SuspendLayout();
            SideMenuBar.Visible = !SideMenuBar.Visible;
            BorderPanel.Visible = !SideMenuBar.Visible;
            ChatPanel.ResumeLayout();
            MessagePagePanel.ResumeLayout();
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
