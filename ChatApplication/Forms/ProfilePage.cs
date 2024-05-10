using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using ChatApplication.Managers;
using ChatApplication.Models;
using ChatApplication;
using ChatApplication.UserControls;
namespace ChatApplication.Forms
{
    public partial class ProfilePage : Form
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

        public event EventHandler<Dictionary<string, Image>> ProfileChoosen;
        private Dictionary<string, Image> PathPic = new Dictionary<string, Image>();
        private string ProfilePath = "";
        private bool pfClicked = false;

        public string UserName
        {
            get { return NameLabel.Text; }
            set { NameLabel.Text = value; }
        }
        public Image ProfilePhoto
        {
            get { return ProfilePicture.Image; }
            set
            {
                ProfilePicture.Image = value;
                ProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        public string About
        {
            get { return AboutBox.Text; }
            set { AboutBox.Text = value; }
        }

        public ProfilePage()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Opacity = 0.85;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!pfClicked)
            {
                Visible = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
            base.OnResize(e);
        }

        private void ProfilePictureClick(object sender, EventArgs e)
        {
            pfClicked = true;
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
                file.Title = "Choose a Photo";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    pfClicked = false;
                    ProfilePicture.Image = Image.FromFile(file.FileName);

                    string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
                    string newfilePath = $@"{Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName))}";
                    //File.Copy(file.FileName, newfilePath, true);
                    ProfilePicture.Image.Save(newfilePath);
                    ProfilePath = newfilePath;
                    PathPic.Add(newfilePath, ProfilePicture.Image);
                    ProfileChoosen?.Invoke(this, PathPic);
                    PathPic.Clear();
                    UpdateInfo();
                    SendIndicationForProfileUpdate();
                }
            }
        }

        private void ProfilePageLoad(object sender, EventArgs e)
        {
            ActiveControl = NameLabel;
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Hide();
            Visible = false;
            UpdateInfo();
            SendIndicationForProfileUpdate();
        }

        private void UpdateInfo()
        {
            Client me = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress];
            me.About = AboutBox.Text;
            if(!ProfilePath.Equals("") && !ProfilePath.Equals(me.ProfilePath)) me.ProfilePath = ProfilePath;
            DbManager.UpdateClient(me);
        }

        private void SendIndicationForProfileUpdate()
        {
            foreach (var a in DbManager.Clients)
            {
                if (!a.Value.IP.Equals(ChatApplicationNetworkManager.LocalIpAddress) && a.Value.IsConnected)
                {
                    Models.Message m = new Models.Message(ChatApplicationNetworkManager.LocalIpAddress, a.Value.IP, "", DateTime.Now, MessageType.ProfileUpdated);
                    Task t=ChatApplicationNetworkManager.SendMessage(m, a.Value);
                }
            }
        }
    }
}
