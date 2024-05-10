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
        private Timer TimerTwo;
        private int TopPanelWidth = 0;
        private int TopPanelX = 0;
        private int LoadingPercent = 0;
        private MainForm mf;

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
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, LoadingPanel, new object[] { true });
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

                mf = new MainForm();
                mf.FormClosed += (obj, ev) => Close();
                #endregion

                LoadingScreenInitialize();
            }
        }

        private void LoadingScreenInitialize()
        {
            MainPanel.Hide();
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(770, 380);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
            BackColor = Color.FromArgb(42, 40, 60);
            Opacity = 0.92;
            CenterToScreen();

            PictureBox icon = new PictureBox
            {
                Image = Properties.Resources.icons8_wechat_481,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(1,5)
            };
            Controls.Add(icon);

            LoadingPanel.Visible = true;
            LoadingPanel.Paint += LoadingPanelPaint;
            TimerTwo = new Timer
            {
                Interval = 3,
            };
            TimerTwo.Tick += TimerTwoTick;
            TimerTwo.Start();
        }

        private void TimerTwoTick(object sender, EventArgs e)
        {
            if(LoadingPercent >= Width)
            {
                TimerTwo.Stop();
                Hide();
                mf?.Show();
            }
            LoadingPercent += 5;
            LoadingPanel.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            Font font = new Font("Microsoft Tai Le", 20, FontStyle.Regular);
            Brush brush = new SolidBrush(Color.White);
            e.Graphics.DrawString("Loading...", font, brush, new PointF(Width / 2.3f, Height / 2));
        }

        private void LoadingPanelPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            Brush brush = new SolidBrush(Color.FromArgb(66, 209, 149));
            g.FillRectangle(brush, new Rectangle(0, 0, LoadingPercent, LoadingPanel.Height));
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
