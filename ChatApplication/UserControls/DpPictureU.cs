using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
    [SupportedOSPlatform("windows")]

    public partial class DpPictureU : UserControl
    {
        private string dpPicturePath = "";
        private OpenFileDialog OpenFileDialog = new OpenFileDialog();
        public event EventHandler<string> OnClickDpPicturePathGet;

        public string DpPicturPath
        {
            get
            {
                return dpPicturePath;
            }
            set
            {
                if (value != "")
                {
                    dpPicturePath = value;
                    dpPB.Image = Image.FromFile(dpPicturePath);
                }

            }
        }
        public DpPictureU()
        {
            InitializeComponent();
            Resize += DpPictureUResize;
            addDpBtn.Click += AddDpBtnClick;
            dpPB.Click += DpPBClick;
        }

        private void AddDpBtnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
                file.Title = "Choose Profile Picture";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    DpPicturPath = file.FileName;
                    OnClickDpPicturePathGet?.Invoke(this, DpPicturPath);
                }
            }
        }

        private void DpPBClick(object sender, EventArgs e)
        {

        }

        private void DpPictureUResize(object sender, EventArgs e)
        {
            addDpBtn.Location = new Point(Width - addDpBtn.Width, Height - addDpBtn.Height);
        }
    }
}
