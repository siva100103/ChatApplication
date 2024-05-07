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
        private MessagePage CurrentlySelected;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //ChatApplicationNetworkManager.ManagerInitializer();
            StarMainPanel.Width = ChatPanel.Width;
            LabelsAdder();
            SideMenuBar.OnClickProfilePicture += OnProfileInfoClick;
            SearchBox.OnTextChange += SearchBoxOnTextChange;
            SideMenuBar.OnClickExitBtn += ExitButtonClick;
            SideMenuBar.ControlClicked += SideMenuBarControlClicked;

            MyProfile = new ProfilePage
            {
                Size = new Size((Width * 74) / 100, (Height * 62) / 100),
                StartPosition = FormStartPosition.Manual,
                UserName = MyDetails.Clients.ToList().Find(c => c.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))?.Name,
            };
            MyProfile.ProfileChoosen += MyProfileProfileChoosen;
            ChatApplicationNetworkManager.Inform += AddNewLabelForNewUser;

            foreach(var a in LocalDatabase.Messages.Values)
            {
                if(a.Starred)
                {
                    AddToStarredMessages(a);
                }
            }

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

        private void SideMenuBarControlClicked(object sender, EventArgs e)
        {
            MyProfile.Hide();
            click = false;
            using (var DbContext = new ServerDatabase())
            {
                foreach (var c in DbContext.Clients.ToList())
                {
                    if (c.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))
                    {
                        c.About = MyProfile.About;
                        DbContext.SaveChanges();
                    }
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
            if (!MyProfile.Visible && !click)
            {
                Point location = PointToScreen(SideMenuBar.Location);
                location.Offset(SideMenuBar.Width + 10, SideMenuBar.Height - MyProfile.Height - 20);
                MyProfile.Location = location;
                MyProfile.Visible = true;
                click = true;
            }
            else if (click)
            {
                MyProfile.Visible = false;
                click = false;
            }
        }

        private void MessagePageSwitcher(object sender, EventArgs e)
        {
            Current = (sender as Client);
            SelectedColorChange();

            MessagePageBackPanel.SuspendLayout();
            MessagePagePanel.SuspendLayout();
            if (Current != null)
            {
                MessagePagePanel.Controls.Clear();
                MessagePage page = Current.MessagePage;
                CurrentlySelected = page;
                page.ProfileImage = Current.ProfilePicture;
                if (page != null)
                {
                    page.Dock = DockStyle.Fill;
                    MessagePagePanel.Controls.Add(page);
                }
            }
            MessagePagePanel.ResumeLayout();
            MessagePageBackPanel.ResumeLayout();
        }

        private void SelectedColorChange()
        {
            foreach (ContactU contact in Contacts)
            {
                if (contact.Client.IP != Current.IP)
                {
                    contact.MPBackColor = Color.FromArgb(243, 243, 243);
                    contact.Selected = false;
                }
                else
                {
                    contact.MPBackColor = Color.FromArgb(229, 227, 222);
                    contact.Selected = true;
                }
            }
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
                a.Value.MessagePage.StarredMessages += StarredMessagesList;
                Contacts.Add(con);
            }

        }

        private void StarredMessagesList(object sender, List<ChatU> selected)
        {
            foreach(ChatU message in selected)
            {
                if (!message.Starred)
                {
                    AddToStarredMessages(message.Message);
                }
            }
        }

        private void AddToStarredMessages(Message message)
        {
            SuspendLayout();
            StarredMessages chat = new StarredMessages(message)
            {
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(247, 247, 247)
            };
            StarPanel.Controls.Add(chat);
            chat.BringToFront();
            Panel space = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 8
            };
            StarPanel.Controls.Add(space);
            space.BringToFront();
            ResumeLayout();
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

        private async void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
            foreach (var a in ChatApplicationNetworkManager.Clients)
            {
                Message msg = new Message(ChatApplicationNetworkManager.FromIPAddress, a.Value.IP, "Close", DateTime.Now, Type.Response);
                if (a.Value.IsConnected)
                {
                    await ChatApplicationNetworkManager.SendMessage(msg, a.Value);
                }
            }
        }

        private void StarMessageButtonClick(object sender, EventArgs e)
        {
            MessagePagePanel.SuspendLayout();
            StarMainPanel.Visible = true;
            StarMainPanel.BringToFront();
            ChatPanel.Visible = false;
            MessagePagePanel.ResumeLayout();
        }

        private void MinMaxButtonClick(object sender, EventArgs e)
        {
            SuspendLayout();
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
            ResumeLayout();
        }

        private void MinMaxButtonMouseHover(object sender, EventArgs e)
        {
            MinMaxButton.BackColor = Color.FromArgb(209, 209, 209);
        }

        private void MinMaxButtonMouseLeave(object sender, EventArgs e)
        {
            MinMaxButton.BackColor = Color.Transparent;
        }

        private void StarBackButtonClick(object sender, EventArgs e)
        {
            MessagePagePanel.SuspendLayout();
            StarMainPanel.Visible = false;
            ChatPanel.Visible = true;
            MessagePagePanel.ResumeLayout();
        }
    }
}
