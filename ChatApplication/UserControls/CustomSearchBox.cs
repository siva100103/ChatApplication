using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
    [SupportedOSPlatform("windows")]

    public partial class CustomSearchBox : UserControl
    {
        public event EventHandler OnTextChange;
        public event EventHandler FocusLost;

        private bool isUnderLine = false;
        private int borderSize = 1;
        private Color borderColor = Color.Black;
        private Color defaultBorderColor = Color.Gray;

        public Image SearchSymbol
        {
            get { return SearchIcon.Image; }
            set
            {
                SearchIcon.Image = value;
            }
        }

        public Font Font
        {
            get { return textBox.Font; }
            set { textBox.Font = value; }
        }
        public string PlaceholderText
        {
            get { return textBox.Text; }
            set
            {
                textBox.Text = value;
                Invalidate();
            }
        }
        public bool IsUnderLine
        {
            get { return isUnderLine; }
            set
            {
                isUnderLine = value;
                Invalidate();
            }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }
        public Color DefaultBorderColor
        {
            get { return defaultBorderColor; }
            set
            {
                defaultBorderColor = value;
                Invalidate();
            }
        }
        public Color PlaceHolderColor
        {
            get { return textBox.PlaceHolderColor; }
            set
            {
                textBox.PlaceHolderColor = value;
                textBox.ForeColor = value;
                Invalidate();
            }
        }

        public Color SearchBackColor
        {
            get { return BackColor; }
            set
            {
                BackColor = value;
                textBox.BackColor = value;
                TextBoxPanel.BackColor = value;
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                //// if(borderSize<value)
                // Padding = new Padding(borderSize + 3);
                borderSize = value;
                Invalidate();
            }
        }
        public bool IsSearchIconVisible
        {
            get
            {
                return SearchIcon.Visible;
            }
            set
            {
                SearchIcon.Visible = value;
            }
        }
        public CustomSearchBox()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Load += CustomSearchBoxLoad;
            textBox.GotFocus += TextBoxGotFocus;
            textBox.LostFocus += TextBoxLostFocus;
        }

        private void TextBoxLostFocus(object sender, EventArgs e)
        {
            FocusLost?.Invoke(this, e);
            textBox.ForeColor = PlaceHolderColor;
            Invalidate();
        }

        private void TextBoxGotFocus(object sender, EventArgs e)
        {
            textBox.ForeColor = PlaceHolderColor;
            Invalidate();
        }

        private void CustomSearchBoxLoad(object sender, EventArgs e)
        {
            textBox.ForeColor = PlaceHolderColor;
        }

        public GraphicsPath GetPath(Rectangle rec)
        {
            GraphicsPath g = new GraphicsPath();
            g.StartFigure();
            /*   g.AddArc(rec.X, rec.Height - borderRadius * 2, rec.Height- borderRadius *2, rec.Height - borderRadius *2, 90, 180);
            g.AddArc(rec.Width - borderRadius*2, rec.Y, rec.Height - borderRadius *2, rec.Height - borderRadius *2, 270, 180);*/
            g.AddArc(rec.X, rec.Y, 12, 12, 180, 90);
            g.AddArc(rec.Width - 12 - 3, rec.Y, 12, 12, 270, 90);
            g.AddArc(rec.Width - 12 - 3, rec.Height - 12 - 3, 12, 12, 0, 90);
            g.AddArc(rec.X, rec.Height - 12 - 3, 12, 12, 90, 90);
            g.CloseFigure();
            return g;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.DoubleBuffered = true;
            base.OnPaint(e);
            GraphicsPath path = GetPath(ClientRectangle);
            this.Region = new Region(path);
            var eg = e.Graphics;
            eg.SmoothingMode = SmoothingMode.AntiAlias;
            //  using (SolidBrush brush = new SolidBrush(BackColor))
            // {
            //eg.FillPath(brush, path);
            // }
            if (textBox.Focused)
            {
                if (isUnderLine == false)
                {

                    using (Pen Drawpen = new Pen(BorderColor, BorderSize))
                    {
                        eg.DrawPath(Drawpen, path);
                    }
                }
                else
                {
                    using (Pen Drawpen = new Pen(BorderColor, BorderSize))
                    {
                        eg.DrawLine(Drawpen, new Point(1, Height - BorderSize), new Point(Width - 1, Height - BorderSize));
                    }
                }
            }
            else
            {
                if (isUnderLine == false)
                {

                    using (Pen Drawpen = new Pen(DefaultBorderColor, BorderSize))
                    {
                        eg.DrawPath(Drawpen, path);
                    }
                }
                else
                {
                    using (Pen Drawpen = new Pen(DefaultBorderColor, BorderSize))
                    {
                        eg.DrawLine(Drawpen, new Point(1, Height - BorderSize), new Point(Width - 1, Height - BorderSize));
                    }
                }
            }
        }

        private void SearchBoxEnter(object sender, EventArgs e)
        {
            BorderSize = 6;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            PlaceholderText = textBox.Text;
            textBox.ForeColor = PlaceHolderColor;
            OnTextChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
