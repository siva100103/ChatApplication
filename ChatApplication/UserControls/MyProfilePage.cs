using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ChatApplication.Models;
using ChatApplication.Managers;
using System.Drawing.Drawing2D;

namespace ChatApplication.UserControls
{
    public partial class MyProfilePage : UserControl
    {
        public event EventHandler<int> ThemeChanged;
        public event EventHandler<Dictionary<string, Image>> ProfileChoosen;

        private string CurrentEditClick = "";
        private PictureBox CurrentTheme;
        private Dictionary<string, Image> PathPic = new Dictionary<string, Image>();
        private string ProfilePath = "";

        public MyProfilePage(Client My)
        {
            InitializeComponent();

            ThemePanel.Visible = false;
            CurrentTheme = LightTheme;
            ProfilePicture.Image = My.ProfilePicture;
            NameBox.Text = My.Name;
            AboutBox.Text = My.About;
        }

        private void MyProfilePageLoad(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            //Theme Set
            OnThemeChange();

            //Event Subscribe
            NameEdit.MouseHover += EditMouseHover;
            AboutEdit.MouseHover += EditMouseHover;
            ProfileEdit.MouseHover += EditMouseHover;
            ThemeInfoLabel.MouseHover += EditMouseHover;
            SaveLabel.MouseHover += EditMouseHover;
            CancelLabel.MouseHover += EditMouseHover;

            NameEdit.MouseLeave += EditMouseLeave;
            AboutEdit.MouseLeave += EditMouseLeave;
            ProfileEdit.MouseLeave += EditMouseLeave;
            ThemeInfoLabel.MouseLeave += EditMouseLeave;
            SaveLabel.MouseLeave += EditMouseLeave;
            CancelLabel.MouseLeave += EditMouseLeave;

            NameEdit.MouseDown += EditMouseDown;
            AboutEdit.MouseDown += EditMouseDown;
            ProfileEdit.MouseDown += EditMouseDown;

            NameEdit.MouseUp += EditMouseUp;
            AboutEdit.MouseUp += EditMouseUp;
            ProfileEdit.MouseUp += EditMouseUp;
        }

        private void EditMouseUp(object sender, MouseEventArgs e)
        {
            (sender as Label).BackColor = ChatTheme.ContactsColor;
        }

        private void EditMouseDown(object sender, MouseEventArgs e)
        {
            (sender as Label).BackColor = ChatTheme.OuterLayerColor;
        }

        private void EditMouseLeave(object sender, EventArgs e)
        {
            Label Current = sender as Label;
            if (Current.Name == "ThemeInfoLabel" || Current.Name == "SaveLabel" || Current.Name == "CancelLabel")
            {
                Current.BackColor = Color.Transparent;
            }
            else
            {
                Current.BackColor = ChatTheme.ContactsColor;
            }
        }

        private void EditMouseHover(object sender, EventArgs e)
        {
            Label Current = sender as Label;
            if (Current.Name == "ThemeInfoLabel" || Current.Name == "SaveLabel" || Current.Name == "CancelLabel")
            {
                Current.BackColor = Color.FromArgb(BackColor.R - 10, BackColor.G - 10, BackColor.B - 10);
            }
            else
            {
                Color backColor = ChatTheme.ContactsColor;
                Current.BackColor = ChatTheme.ThemeColor;
            }
        }

        public void OnThemeChange()
        {
            SuspendLayout();
            CurrentTheme = ChatTheme.Current == 1 ? DarkTheme : LightTheme;

            //Background Colors
            MainPanel.BackColor = ChatTheme.ContactBackgroundColor;
            ThemePanel.BackColor = ChatTheme.ThemeColor;
            BackColor = MainPanel.BackColor;
            NameBox.BackColor = MainPanel.BackColor;
            AboutBox.BackColor = MainPanel.BackColor;
            GuideToChangeProfile.BackColor = MainPanel.BackColor;
            NameEdit.BackColor = AboutEdit.BackColor = ProfileEdit.BackColor = ChatTheme.ContactsColor;
            NamePanel.BackColor = AboutPanel.BackColor = ProfilePanel.BackColor = ChatTheme.OuterLayerColor;
            ProfilePicture.BackColor = MainPanel.BackColor;
            ProfilePanel.BackColor = ChatTheme.OuterLayerColor;
            TopPanel.BackColor = ChatTheme.OuterLayerColor;
            EditPanel.BackColor = ChatTheme.ThemeColor;
            BackButton.FlatAppearance.MouseOverBackColor = BackColor;
            BackButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //Text Colors
            GuideToChangeProfile.ForeColor = ChatTheme.TextColor;
            NameBox.ForeColor = ChatTheme.TextColor;
            AboutBox.ForeColor = ChatTheme.TextColor;
            NameInfoLabel.ForeColor = ChatTheme.TextColor;
            ProfileInfoLabel.ForeColor = ChatTheme.TextColor;
            AboutInfoLabel.ForeColor = ChatTheme.TextColor;
            ThemeInfoLabel.ForeColor = ChatTheme.TextColor;
            NameEdit.ForeColor = ProfileEdit.ForeColor = AboutEdit.ForeColor = ChatTheme.BorderColor;
            BackButton.ForeColor = ChatTheme.TextColor;
            ResumeLayout();
        }

        private void OnEditClick(object sender, EventArgs e)
        {
            CurrentEditClick = (sender as Label).Name;
            NamePanel.Visible = AboutPanel.Visible = ThemePanel.Visible = false;
            NameInfoLabel.Visible = ThemeInfoLabel.Visible = AboutInfoLabel.Visible = false;
            EditPanel.Dock = DockStyle.Fill;
            EditPanel.Visible = true;
            if (CurrentEditClick == "NameEdit")
            {
                EditBox.Text = NameBox.Text;
            }
            else
            {
                EditBox.Text = AboutBox.Text;
            }
        }

        private void OnClickFromEditPanel(object sender, EventArgs e)
        {
            NamePanel.Visible = AboutPanel.Visible = ThemePanel.Visible = true;
            NameInfoLabel.Visible = ThemeInfoLabel.Visible = AboutInfoLabel.Visible = true;
            EditPanel.Visible = false;
            EditPanel.Dock = DockStyle.Bottom;
            if ((sender as Label).Name == "SaveLabel")
            {
                if (CurrentEditClick == "NameEdit" && EditBox.Text != "")
                {
                    NameBox.Text = EditBox.Text;
                }
                else
                {
                    AboutBox.Text = EditBox.Text;
                }
                UpdateInfo();
            }
            EditBox.Text = "";
        }

        private void ProfilePictureClick(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
                file.Title = "Choose a Photo";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    ProfilePicture.Image = Image.FromFile(file.FileName);
                    ProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
                    string newfilePath = $@"{Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName))}";
                    if (!File.Exists(newfilePath))
                    {
                        ProfilePicture.Image.Save(newfilePath);
                    }
                    ProfilePath = newfilePath;
                    PathPic.Add(newfilePath, ProfilePicture.Image);
                    ProfileChoosen?.Invoke(this, PathPic);
                    PathPic.Clear();
                    UpdateInfo();
                    SendIndicationForProfileUpdate();
                }
            }
        }

        private void SendIndicationForProfileUpdate()
        {
            foreach (var a in DbManager.Clients)
            {
                if (!a.Value.IP.Equals(ChatApplicationNetworkManager.LocalIpAddress) && a.Value.IsConnected)
                {
                    MessageModel m = new MessageModel(ChatApplicationNetworkManager.LocalIpAddress, a.Value.IP, "", DateTime.Now, MessageType.ProfileUpdated);
                    Task t = ChatApplicationNetworkManager.SendMessage(m, a.Value);
                }
            }
        }

        private void ThemeClick(object sender, EventArgs e)
        {
            CurrentTheme = sender as PictureBox;
            if ((sender as PictureBox).Name == "LightTheme")
            {
                ThemeChanged?.Invoke(this, 0);
                LightTheme.BackColor = SystemColors.Highlight;
                DarkTheme.BackColor = Color.Transparent;
            }
            else
            {
                ThemeChanged?.Invoke(this, 1);
                DarkTheme.BackColor = SystemColors.Highlight;
                LightTheme.BackColor = Color.Transparent;
            }
            OnThemeChange();
        }

        private void ThemeInfoLabelClick(object sender, EventArgs e)
        {
            ThemePanel.Visible = !ThemePanel.Visible;
            CurrentTheme.BackColor = SystemColors.Highlight;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Visible = false;
            Dispose();
        }

        //Update DB
        private void UpdateInfo()
        {
            Client me = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress];
            me.Name = NameBox.Text;
            me.About = AboutBox.Text;
            if (!ProfilePath.Equals("") && !ProfilePath.Equals(me.ProfilePath))
                me.ProfilePath = ProfilePath;
            DbManager.UpdateClient(me);
        }
    }
}
