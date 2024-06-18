using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
    [SupportedOSPlatform("windows")]

    public partial class StatusIndicator : UserControl
    {
        private Color color = Color.FromArgb(128, 255, 128);

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Invalidate();
            }
        }
        public StatusIndicator()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            Brush b = new SolidBrush(color);
            g.FillEllipse(b, r);
        }
    }
}
