using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class BendingMessages : UserControl
    {
        private string Unread = "";
        private Font font = new Font("Arial", 11.2f, FontStyle.Regular);
        private PointF point = new PointF();

        public BendingMessages()
        {
            InitializeComponent();
            point = new PointF((Width * 8.5f) / 100, (Height * 7.5f) / 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            Brush b = new SolidBrush(Color.FromArgb(0, 212, 111));
            g.FillEllipse(b, r);

            Brush brush = new SolidBrush(Color.FromArgb(255, 254, 246));
            g.DrawString(Unread, font, brush, point);
        }

        public void UnReadCount(int n)
        {
            string count = n.ToString();
            if (n > 99)
            {
                count = "99+";
                point = new PointF((Width * 4) / 100, (Height * 18f) / 100);
                font = new Font("Arial", 7.2f, FontStyle.Regular);
            }
            else if(n > 9)
            {
                point = new PointF((Width * 4) / 100, (Height * 18) / 100);
                font = new Font("Arial", 10f, FontStyle.Regular);
            }
            Unread = count;
            Refresh();
        }
    }
}
