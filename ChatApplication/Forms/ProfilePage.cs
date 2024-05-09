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
using ChatApplication.Controller;
using WindowsFormsApp3;

namespace ChatApplication
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

        private bool pfClicked = false;
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

                    PathPic.Add(newfilePath, ProfilePicture.Image);
                    ProfileChoosen?.Invoke(this, PathPic);
                    PathPic.Clear();
                    
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
            //using (var DbContext = new ServerDatabase())
            //{
            //    foreach (var c in DbContext.Clients.ToList())
            //    {
            //        if (c.IP.Equals(ChatApplicationNetworkManager.LocalIpAddress.ToString()))
            //        {
            //            c.About = AboutBox.Text;
            //            DbContext.SaveChanges();
            //        }
            //    }
            //}
            Client me = DbManager.Clients.Values.ToList().Find((c) => c.IP.Equals(ChatApplicationNetworkManager.LocalIpAddress));
            me.About = AboutBox.Text;
            DbManager.UpdateClient(me);
        }
    }
}
