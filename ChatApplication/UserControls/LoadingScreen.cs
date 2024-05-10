using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace ChatApplication.UserControls
{
    public partial class LoadingScreen : UserControl
    {
        private Timer timer;
        private int LoadingPercent = 0;

        public LoadingScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void LoadingScreenLoad(object sender, EventArgs e)
        {
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, LoadingPanel, new object[] { true });
            PictureBox icon = new PictureBox
            {
                Image = Properties.Resources.icons8_wechat_481,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(1, 5)
            };
            Controls.Add(icon);
            BackColor = Color.FromArgb(42, 40, 60);
            LoadingPanel.Paint += LoadingPanelPaint;
            timer = new Timer
            {
                Interval = 3
            };
            timer.Tick += TimerTick;
            timer.Start();
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

        private void TimerTick(object sender, EventArgs e)
        {
            if (LoadingPercent >= Width)
            {
                timer.Stop();
                Dispose();
            }
            LoadingPercent += 5;
            LoadingPanel.Invalidate();
        }
    }
}
