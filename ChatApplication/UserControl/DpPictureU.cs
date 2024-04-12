using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
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

        private void DpPBClick(object sender, EventArgs e)
        {

        }

        private void AddDpBtnClick(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "PNG|*.png|JPEG|*.jpeg";
            DialogResult result = OpenFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                DpPicturPath = OpenFileDialog.FileName;
                OnClickDpPicturePathGet?.Invoke(this, DpPicturPath);
            }
        }

        private void DpPictureUResize(object sender, EventArgs e)
        {
            addDpBtn.Location = new Point(Width - addDpBtn.Width, Height - addDpBtn.Height);
        }
    }
}
