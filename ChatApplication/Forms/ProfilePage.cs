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

        public event EventHandler<Image> ProfileChoosen;

        public string UserName
        {
            get { return NameLabel.Text; }
            set { NameLabel.Text = value; }
        }
        public Image profilePicture
        {
            get { return ProfilePicture.Image; }
            set
            {
                ProfilePicture.Image = value;
                ProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public ProfilePage()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Opacity = 0.9;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));

            LostFocus += ProfilePageLostFocus;
        }

        private void ProfilePageLostFocus(object sender, EventArgs e)
        {
            if (!pfClicked)
            {
                Visible = false;
                Hide();
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
                    ProfileChoosen?.Invoke(this, ProfilePicture.Image);

                    string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
                    string newfilePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName));
                    //File.Copy(file.FileName, newfilePath, true);
                    ProfilePicture.Image.Save(newfilePath);
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
        }
    }
}
