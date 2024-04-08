using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace ChatApplication

{
    class CustomPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs args)
        {
            Graphics g= args.Graphics;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode= SmoothingMode.AntiAlias;
            
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(args);
        }

    }
}