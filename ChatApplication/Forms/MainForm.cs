﻿using ChatApplication.Managers;
using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApplication.UserControls;
using System.Xml.Serialization;
using System.IO;

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
        private List<ContactU> Contacts = new List<ContactU>();
        private Client Current;
        private int StarMessageCount = 1;
        private int theme = 0;
        private bool profileClicked = false;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Functions Perform While Opening
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Setting Color Scheme
            theme = DbManager.MyData.Theme;
            ChatTheme.SetTheme(theme);


            StarMainPanel.Dock = DockStyle.Fill;
            MainPanel.Visible = false;
            SideMenuBar.Visible = false;

            //Sending OpenMessages To All the Users...
            SendOpenMessage();

            //Adding Contact Labels...
            LabelsAdder();

            //Subscribing Events..
            EventSubscriber();

            //star message added to list
            foreach (var a in DbManager.Messages.Values)
            {
                if (a.Starred)
                {
                    AddToStarredMessages(a);
                }
            }

            //Loading initialize
            LoadingScreenLoad();

            ControlsOnThemeChange();
            MyThemeChanged(this, theme);
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
            SideMenuBar.MouseDown += DragMouseDown;
            SideMenuBar.MouseUp += DragMouseUp;
            SideMenuBar.MouseMove += DragMouseMove;
            SideMenuBar.OnClickProfilePicture += OnProfileInfoClick;
            SearchBox.OnTextChange += SearchBoxOnTextChange;

            SideMenuBar.OnClickExitBtn += (sender, ev) => Close();

            ChatApplicationNetworkManager.Inform += AddNewLabelForNewUser;
            ChatApplicationNetworkManager.ProfileUpdateInformer += ProfileUpdater;
        }

        private void SendOpenMessage()
        {
            foreach (var clt in DbManager.Clients.Values)
            {
                MessageModel message = new MessageModel(ChatApplicationNetworkManager.LocalIpAddress, clt.IP, "Open", DateTime.Now, MessageType.Response);
                Task t = ChatApplicationNetworkManager.SendMessage(message, clt);
            }
        }
        #endregion

        #region Drag and Drop
        private void DragMouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = Location;
        }

        private void DragMouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Point newLocation = Point.Add(dragFormPoint, new Size(dif));

                Rectangle workingArea = Screen.GetWorkingArea(this);

                if (newLocation.X < workingArea.Left)
                {
                    newLocation.X = workingArea.Left;
                }
                if (newLocation.Y < workingArea.Top)
                {
                    newLocation.Y = workingArea.Top;
                }
                if (newLocation.X + Width > workingArea.Right)
                {
                    newLocation.X = workingArea.Right - Width;
                }
                if (newLocation.Y + Height > workingArea.Bottom)
                {
                    newLocation.Y = workingArea.Bottom - Height;
                }

                Location = newLocation;
            }
        }

        private void DragMouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion

        private void ProfileUpdater(Client c)
        {
            ContactU cu = Contacts.Find((cu1) => cu1.Client == c);
            cu.UpdateDetais();
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
            MyProfilePage MyProfile = new MyProfilePage(DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress])
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            ChatPanel.Controls.Add(MyProfile);
            MyProfile.ThemeChanged += MyThemeChanged;
            MyProfile.ProfileChoosen += MyProfileProfileChoosen;

            MyProfile.Disposed += (sndr, evnt) =>
            {
                chatContactPanel.Visible = true;
                SearchPanel.Visible = true;
                ChatHeaderPanel.Visible = true;
                profileClicked = false;
            };

            if (!profileClicked)
            {
                MyProfile.Refresh();
                MyProfile.Visible = true;
                chatContactPanel.Visible = false;
                SearchPanel.Visible = false;
                ChatHeaderPanel.Visible = false;
                profileClicked = true;
            }
            else
            {
                chatContactPanel.Visible = true;
                SearchPanel.Visible = true;
                ChatHeaderPanel.Visible = true;
                profileClicked = false;
            }
        }

        private void MyThemeChanged(object sender, int e)
        {
            ChatTheme.SetTheme(e);
            ControlsOnThemeChange();

            theme = (theme == 0) ? 1 : 0;

            SuspendLayout();
            //OuterLayer
            SideMenuBar.BackColor = ChatTheme.OuterLayerColor;
            MessagePageTopPanel.BackColor = ChatTheme.OuterLayerColor;

            //InnerLayer
            ChatContainer.BackColor = ChatTheme.InnerLayerColor;
            SearchBox.SearchBackColor = ChatTheme.InnerLayerColor;
            ChatLabel.ForeColor = ChatTheme.TextColor;
            SearchBox.PlaceHolderColor = ChatTheme.TextColor;
            SearchBox.DefaultBorderColor = theme == 1 ? Color.FromArgb(30, 30, 30) : Color.Gray;
            SearchBox.BorderColor = ChatTheme.BorderColor;
            ChatPanel.BackColor = ChatTheme.ContactBackgroundColor;
            BackColor = ChatTheme.ContactBackgroundColor;
            MessagePagePanel.BackColor = ChatTheme.MessagePageColor;

            //Hover Buttons
            ControlsOnThemeChange();

            //BorderColor
            BorderPanel.BackColor = ChatTheme.BorderColor;
            StarMessageTopPanel.BackColor = Color.FromArgb(128, ChatTheme.BorderColor);
            StarPanel.BackColor = ChatTheme.ContactBackgroundColor;

            //Contact List
            foreach (ContactU contact in Contacts)
            {
                contact.TextColor = ChatTheme.TextColor;
                contact.Client.MessagePage.OuterColor = ChatTheme.ContactsColor;
                contact.Client.MessagePage.InnerColor = ChatTheme.MessagePageColor;
                contact.Client.MessagePage.MessageThemeSet();
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

        private void LeftAlignButtonClick(object sender, EventArgs e)
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
            MainPanel.SuspendLayout();
            MessagePagePanel.Visible = false;
            StarMainPanel.Visible = true;
            StarMainPanel.BringToFront();
            ChatPanel.Visible = false;
            MainPanel.ResumeLayout();
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

        protected override void OnClosed(EventArgs e)
        {
            string xmlFilePath = @".\data.xml";

            DbManager.MyData.Theme = ChatTheme.Current;
            LocalData data = DbManager.MyData;

            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(writer, data);
            }

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
                    Task t = ChatApplicationNetworkManager.SendMessage(msg, a.Value);
                }
            }

        }

        private void ControlsOnThemeChange()
        {
            MainPanel.SuspendLayout();
            LeftAlignButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, ChatTheme.ContactsColor);
            LeftAlignButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, ChatTheme.ContactsColor);
            StarMessageButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, ChatTheme.ContactsColor);
            StarMessageButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, ChatTheme.ContactsColor);
            StarBackButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, ChatTheme.BorderColor);
            StarBackButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, ChatTheme.BorderColor);
            SideMenuBar.HoverSideColor = ChatTheme.BorderColor;

            LeftAlignButton.Image = ChatTheme.LeftAlign;
            StarMessageButton.Image = ChatTheme.StarMessage;
            SideMenuBar.ChatSymbol = ChatTheme.ChatIcon;
            SideMenuBar.ExitSymbol = ChatTheme.ExitIcon;
            SideMenuBar.ArchiveSymbol = ChatTheme.ArchieveIcon;
            SearchBox.SearchSymbol = ChatTheme.SearchIcon;

            MainPanel.ResumeLayout();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

    }
}
