using ChatApplication.Managers;
using ChatApplication.Models;
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
using ChatApplication;
using ChatApplication.UserControls;
namespace ChatApplication.Forms
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
        private bool click = false;
        private List<ContactU> Contacts = new List<ContactU>();
        private Client Current;
        private MessagePage CurrentlySelected;
        private int StarMessageCount = 1;
        private bool theme = false;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Functions Perform While Opening
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Setting Color Scheme
            ChatTheme.SetTheme(theme);
            HoverColorControl();

            StarMainPanel.Width = ChatPanel.Width;
            MainPanel.Visible = false;
            SideMenuBar.Visible = false;
            //
            LoadingScreenLoad();

            //Adding Contact Labels...
            LabelsAdder();

            //Subscribing Events..
            EventSubscriber();

            //Setting UsersProfile Details..
            ProfileSetter();

            //Sending OpenMessages To All the Users...
            SendOpenMessage();

            //star message added to list
            foreach (var a in DbManager.Messages.Values)
            {
                if (a.Starred)
                {
                    AddToStarredMessages(a);
                }
            }
        }

        private void LoadingScreenLoad()
        {
            LoadingScreen Loading = new LoadingScreen
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(Loading);
            Loading.Disposed += (sender, e) =>
            {
                MainPanel.Visible = true;
                SideMenuBar.Visible = true;
            };
        }

        private void LabelsAdder()
        {

            foreach (var a in DbManager.Clients)
            {
                if (a.Value.IP.Equals(ChatApplicationNetworkManager.LocalIpAddress)) continue;
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

        private void AddToStarredMessages(MessageModel message)
        {
            SuspendLayout();
            StarredMessages chat = new StarredMessages(message)
            {
                Dock = DockStyle.Top,
                Name = StarMessageCount.ToString(),
                BackColor = Color.FromArgb(247, 247, 247)
            };
            StarPanel.Controls.Add(chat);
            chat.BringToFront();
            chat.Disposed += ChatDisposed;

            Panel space = new Panel()
            {
                Dock = DockStyle.Top,
                Name = (int.Parse(chat.Name) + 1).ToString(),
                Height = 8
            };
            StarPanel.Controls.Add(space);
            space.BringToFront();
            StarMessageCount += 2;
            ResumeLayout();
        }

        private void ChatDisposed(object sender, EventArgs e)
        {
            int id = int.Parse((sender as StarredMessages).Name);

            StarPanel.Controls.RemoveByKey((id + 1).ToString());
        }

        private void EventSubscriber()
        {
            SideMenuBar.OnClickProfilePicture += OnProfileInfoClick;
            SearchBox.OnTextChange += SearchBoxOnTextChange;

            SideMenuBar.OnClickExitBtn += (sender, ev) => Close();

            SideMenuBar.ControlClicked += SideMenuBarControlClicked;
            ChatApplicationNetworkManager.Inform += AddNewLabelForNewUser;
            ChatApplicationNetworkManager.ProfileUpdateInformer += ProfileUpdater;
        }

        private void ProfileSetter()
        {
            MyProfile = new ProfilePage
            {
                Size = new Size((Width * 74) / 100, (Height * 64) / 100),
                StartPosition = FormStartPosition.Manual,
                UserName = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress].Name,
            };

            MyProfile.Deactivate += (sender, e) => MyProfile.Hide();
            MyProfile.ProfileChoosen += MyProfileProfileChoosen;

            Client me = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress];
            if (me.ProfilePath != "")
            {
                SideMenuBar.ProfileImage = me.ProfilePicture;
                MyProfile.ProfilePhoto = SideMenuBar.ProfileImage;
            }
            MyProfile.About = me.About;
        }

        private async void SendOpenMessage()
        {
            foreach (var clt in DbManager.Clients.Values)
            {
                MessageModel message = new MessageModel(ChatApplicationNetworkManager.LocalIpAddress, clt.IP, "Open", DateTime.Now, MessageType.Response);
                await ChatApplicationNetworkManager.SendMessage(message, clt);
                if (clt.IsConnected)
                    clt.StatusChanger(true);
                else clt.StatusChanger(false);
            }
        }
        #endregion

        private void ProfileUpdater(Client c)
        {
            ContactU cu = Contacts.Find((cu1) => cu1.Client == c);
            cu.UpdateDetais();
        }

        private void SideMenuBarControlClicked(object sender, EventArgs e)
        {
            MyProfile.Hide();
            click = false;
            Client me = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress];
            me.About = MyProfile.About;
            DbManager.UpdateClient(me);
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

            Client client = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress];
            client.ProfilePath = $@"{path}";
            DbManager.UpdateClient(client);
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
                    contact.MPBackColor = ChatTheme.ContactsColor;
                    contact.Selected = false;
                }
                else
                {
                    contact.MPBackColor = ChatTheme.CurrentlySelectedColor;
                    contact.Selected = true;
                }
            }
        }

        private void StarredMessagesList(object sender, List<ChatU> selected)
        {
            foreach (ChatU message in selected)
            {
                if (!message.Message.Starred)
                {
                    AddToStarredMessages(message.Message);
                }
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

        private void StarMessageButtonClick(object sender, EventArgs e)
        {
            StarMainPanel.Dock = DockStyle.Fill;
            MessagePagePanel.SuspendLayout();
            MessagePagePanel.Visible = false;
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
            MessagePagePanel.Visible = true;
            StarMainPanel.Visible = false;
            ChatPanel.Visible = true;
            MessagePagePanel.ResumeLayout();
        }

        protected async override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            //Updating Last Seen...
            Client clt = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress];
            clt.LastSeen = DateTime.Now;
            DbManager.UpdateClient(clt);

            //Sending Close Message...
            foreach (var a in DbManager.Clients)
            {
                MessageModel msg = new MessageModel(ChatApplicationNetworkManager.LocalIpAddress, a.Value.IP, "Close", DateTime.Now, MessageType.Response);
                if (a.Value.IsConnected)
                {
                    await ChatApplicationNetworkManager.SendMessage(msg, a.Value);
                }
            }

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void HoverColorControl()
        {
            SuspendLayout();
            OptionButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, ChatTheme.ContactsColor);
            OptionButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, ChatTheme.ContactsColor);
            StarMessageButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, ChatTheme.ContactsColor);
            StarMessageButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, ChatTheme.ContactsColor);
            StarBackButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, ChatTheme.BorderColor);
            StarBackButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, ChatTheme.BorderColor);

            SideMenuBar.HoverSideColor = ChatTheme.BorderColor;
            ResumeLayout();
        }

        private void ChatLabelClick(object sender, EventArgs e)
        {
            ChatTheme.SetTheme(!theme);
            theme = !theme;

            SuspendLayout();
            //OuterLayer
            SideMenuBar.BackColor = ChatTheme.OuterLayerColor;
            MessagePageTopPanel.BackColor = ChatTheme.OuterLayerColor;

            //InnerLayer
            ChatContainer.BackColor = ChatTheme.InnerLayerColor;
            SearchBox.SearchBackColor = ChatTheme.InnerLayerColor;
            ChatLabel.ForeColor = ChatTheme.TextColor;
            SearchBox.PlaceHolderColor = ChatTheme.TextColor;
            SearchBox.DefaultBorderColor = theme ? Color.FromArgb(30, 30, 30) : Color.Gray;
            SearchBox.BorderColor = ChatTheme.BorderColor;
            ChatPanel.BackColor = ChatTheme.ContactBackgroundColor;
            BackColor = ChatTheme.ContactBackgroundColor;
            MessagePagePanel.BackColor = ChatTheme.MessagePageColor;

            //Hover Buttons
            HoverColorControl();

            //BorderColor
            BorderPanel.BackColor = ChatTheme.BorderColor;
            StarMessageTopPanel.BackColor = Color.FromArgb(128, ChatTheme.BorderColor);

            //Contact List
            foreach (ContactU contact in Contacts)
            {
                contact.TextColor = ChatTheme.TextColor;
                contact.Client.MessagePage.OuterColor = ChatTheme.ContactsColor;
                contact.Client.MessagePage.InnerColor = ChatTheme.MessagePageColor;
                if (Current != null && contact.Client.IP == Current.IP)
                {
                    contact.MPBackColor = ChatTheme.CurrentlySelectedColor;
                }
                else
                {
                    contact.MPBackColor = ChatTheme.ContactsColor;

                }
            }
            ResumeLayout();
        }
    }
}
