using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApplication.Managers;
using System.IO;
using System.Xml.Serialization;
using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;
using ChatApplication;
using ChatApplication.UserControls;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ChatApplication.Forms
{
    public partial class LoginForm : Form
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
        private string DpPicturePath = "";
        public event EventHandler Dp;
        private Timer TimerOne;
        private int TopPanelWidth = 0;
        private int TopPanelX = 0;

        public LoginForm(string IPAddress)
        {
            InitializeComponent();
            IPLabel.Text = IPAddress;
            dpPictureU.OnClickDpPicturePathGet += DpPicturePathGet;
        }

        private void DpPicturePathGet(object sender, string path)
        {
            Image dp = Image.FromFile(path);
            string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
            string newfilePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(path) + Path.GetExtension(path));
            DpPicturePath = newfilePath;
            try
            {
                using (var bmp = new Bitmap(dp))
                {
                    bmp.Save(newfilePath);
                }
            }
            catch
            {
            }
            //dp.Save(newfilePath);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, TopPanel, new object[] { true });
            typeof(TextBoxU).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, firstNameTB, new object[] { true });
            typeof(TextBoxU).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, lastNameTB, new object[] { true });

            Resize += LoginFormResize;
            SignUpButton.Click += SignUpButtonClick;
            TimerOne = new Timer
            {
                Interval = 30
            };
            TimerOne.Tick += PaintTick;
            TimerOne.Start();
        }

        private void PaintTick(object sender, EventArgs e)
        {
            if (TopPanelWidth >= Width + Width/2)
            {
                TopPanelWidth = TopPanelX = 0;
            }
            if (TopPanelWidth >= ((Width * 85) / 100))
            {
                TopPanelX += ((TopPanelWidth * 2) / 100);
            }
            TopPanelWidth += 10;
            TopPanel.Invalidate();
        }

        private void SignUpButtonClick(object sender, EventArgs e)
        {
            if (firstNameTB.TextBoxtext.Trim() != "" && lastNameTB.TextBoxtext.Trim() != "")
            {
                TimerOne.Stop();

                #region Client Creation
                Client c = new Client(IPLabel.Text, firstNameTB.TextBoxtext.Trim() + " " + lastNameTB.TextBoxtext.Trim(), 12346, DateTime.Now, DpPicturePath, "");
                DbManager.AddClient(c);
                Hide();
                if (!ChatApplicationNetworkManager.ManagerInitializer())
                {
                    DialogResult dialog = MessageBox.Show("Invalid Credentials \nPlease Check data.xml", "WARNING",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialog == DialogResult.OK)
                    {
                        Close();
                        return;
                    }
                }

                MainForm mf = new MainForm();
                mf?.Show();
                mf.FormClosed += (obj, ev) => Close();
                #endregion

            }
        }

        private void LoginFormResize(object sender, EventArgs e)
        {
            centerP.Location = new Point(Width / 2 - centerP.Width / 2, Height / 2 - centerP.Height / 2);
            firstNameTB.Location = new Point(centerP.Width / 2 - firstNameTB.Width / 2, firstNameTB.Location.Y);
            lastNameTB.Location = new Point(centerP.Width / 2 - lastNameTB.Width / 2, lastNameTB.Location.Y);
            //ipAddressLB.Location = new Point(centerP.Width / 2 - ipAddressLB.Width / 2, ipAddressLB.Location.Y);
            dpPictureU.Location = new Point(centerP.Width / 2 - dpPictureU.Width / 2, dpPictureU.Location.Y);
            SignUpButton.Location = new Point(centerP.Width / 2 - SignUpButton.Width / 2, SignUpButton.Location.Y);
            centerP.BringToFront();
        }

        private void TopPanelPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.FromArgb(150, 31, 177, 65));
            g.FillRectangle(brush, new Rectangle(TopPanelX, 0, TopPanelWidth, TopPanel.Height));
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
