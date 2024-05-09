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

namespace ChatApplication
{
    public partial class ContentForm : Form
    {
        public string NameInfo
        {
            get { return NameLabel.Text; }
            set { NameLabel.Text = value; }
        }

        public string ContactInfo
        {
            get { return ContactLabel.Text; }
            set { ContactLabel.Text = value; }
        }
        public Image DP
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
        private Color ContactColor;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public ContentForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Opacity = 0.85;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ContactColor = ContactLabel.BackColor;

            LostFocus += ContentFormLostFocus;
            DoubleBuffered = true;
        }

        private void ContentFormLostFocus(object sender, EventArgs e)
        {
            if (Visible)
            {
                MessageModel.ClickedInfo = true;
                Focus();
            }
            Visible = false;
            MessageModel.ClickedInfo = false;
        }

        private void ContactMouseEnter(object sender, EventArgs e)
        {
            Control current = sender as Control;
            current.BackColor = Color.FromArgb(159, 192, 218);
        }

        private void ContactMouseLeave(object sender, EventArgs e)
        {
            Control current = sender as Control;
            current.BackColor = Color.Transparent;
        }

        private void ContactLabelClick(object sender, EventArgs e)
        {
            Clipboard.SetText(ContactLabel.Text);
        }

        private void ContactMouseDown(object sender, MouseEventArgs e)
        {
            ContactLabel.BackColor = Color.FromArgb(214, 219, 233);
        }

        private void ContactMouseUp(object sender, MouseEventArgs e)
        {
            ContactLabel.BackColor = Color.FromArgb(159, 192, 218);
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
