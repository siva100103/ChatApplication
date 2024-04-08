using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ChatApplication{


    //public class CustomToolTip : ToolTip
    //{
    //    public CustomToolTip()
    //    {
    //        this.OwnerDraw = true;
    //        Draw += CustomToolTip_Draw;
    //        BackColor = Color.LightGray;

    //    }

    //    private void CustomToolTip_Draw(object sender, DrawToolTipEventArgs e)
    //    {
    //        // Custom drawing code here
    //        using (GraphicsPath path = CreateRoundRect(e.Bounds, 3))
    //        {
    //            e.Graphics.FillPath(Brushes.White, path);
    //           // e.Graphics.DrawPath(Pens.Black, path);
    //        }
    //        e.Graphics.DrawString(e.ToolTipText, e.Font, Brushes.Black, e.Bounds.X+2 , e.Bounds.Y );
    //    }

    //    //protected override void OnDraw(DrawToolTipEventArgs e)
    //    //{

    //    //}

    //    //protected override bool ShowToolTips
    //    //{
    //    //    get { return true; }
    //    //}

    //    // Override WndProc to intercept WM_PAINT message
    //    //protected override void WndProc(ref Message m)
    //    //{
    //    //    const int WM_PAINT = 0xF;

    //    //    if (m.Msg == WM_PAINT)
    //    //    {
    //    //        // Call base WndProc for default painting
    //    //        base.WndProc(ref m);

    //    //        // Perform custom painting after the base painting
    //    //        using (Graphics g = Graphics.FromHwnd(m.HWnd))
    //    //        {
    //    //            // Custom painting code here
    //    //            // e.g., g.DrawString("Custom Tooltip", SystemFonts.DefaultFont, Brushes.Red, 0, 0);
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        base.WndProc(ref m);
    //    //    }
    //    //}

  
        class CustomTooltip : ToolTip
        {
            public CustomTooltip()
            {
                this.OwnerDraw = true;
                this.Popup += new PopupEventHandler(this.OnPopup);
                this.Draw += new DrawToolTipEventHandler(this.OnDraw);
            }

            private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
            {
                  
               // e.ToolTipSize = size;
            }
       // Size size=new Size(100,40);
            private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
            {
            Size size;
                Graphics g = e.Graphics;
             size = new Size((int)(e.Graphics.MeasureString(this.ToolTipTitle,new Font(FontFamily.GenericSerif,9)).Width),(int) (e.Graphics.MeasureString(this.ToolTipTitle, new Font(FontFamily.GenericSerif, 9)).Height));
           LinearGradientBrush b = new LinearGradientBrush(e.Bounds,
                    Color.White, Color.LightGray, 45f);
            g.FillPath(b, CreateRoundRect(e.Bounds,6));
            
                g.DrawRectangle(new Pen(Brushes.Red, 1), new Rectangle(e.Bounds.X, e.Bounds.Y,
                    e.Bounds.Width - 1, e.Bounds.Height - 1));

                g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Silver,
                    new PointF(e.Bounds.X + 6, e.Bounds.Y + 6)); // shadow layer
                g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Black,
                    new PointF(e.Bounds.X + 5, e.Bounds.Y + 5)); // top layer

                b.Dispose();
            }

        private GraphicsPath CreateRoundRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

    }


}



