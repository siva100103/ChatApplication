using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChatApplication
{
    public delegate void ChatUClickked1(object sender, int a);

    public partial class ChatU : UserControl
    {

        private int borderRadius = 10;
        private bool isReceivedMessage = false;
        private bool isSent = false;
        private int chatArcWidth = 10;
        private bool isNormal;
        private bool isViewed;
        private Message message;
        private int chatUMaximumWidth = 400;
        public string path { get; set; } = "";
        public ChatUClickked1 ChatUClickked;


        public Message Message
        {
            set
            {
                if (value != null)
                {
                    message = value;
                    timingLB.Text = value.Time.ToString("hh:mm tt");
                    // ChatCreate();
                }

            }
            get
            {
                return message;
            }
        }

       
        public bool IsReceivedMessage
        {
            get
            {
                return isReceivedMessage;
            }
            set
            {
                isReceivedMessage = value;
                if (value == true)
                    BackColor = Color.White;
                Invalidate();
            }
        }


        public ChatU(Message message)
        {
            InitializeComponent();
            Message = message;

            if (message.Seen && message.FromIP.Equals(ChatApplicationNetworkManager.FromIPAddress))
            {
                MessageSendIconPB.Visible = true;
                MessageSendIconPB.Image = Properties.Resources.double_check__1_;
            }

            message.IsSended += (obj, e) =>
            {
                MessageSendIconPB.Image = Properties.Resources.icons8_double_tick_13;
                MessageSendIconPB.Visible = true;
            };

            message.IsReaded += (obj, e) =>
            {
                Message m = obj as Message;
                if(m.FromIP.Equals(ChatApplicationNetworkManager.FromIPAddress)) MessageSendIconPB.Image = Properties.Resources.double_check__1_;
            };
        }

       

        public string StringFormatChange(string str, int width, Font font)
        {
            int lineCharCount;
            string space = "";

            Graphics g = CreateGraphics();
            string temp = "";
            string formatedstring = "";
            for (lineCharCount = 0; lineCharCount < str.Length;)
            {
                var w = g.MeasureString(temp, font);
                if (w.Width < width)
                {
                    temp = temp + str[lineCharCount];
                    lineCharCount++;
                }
                else
                    break;
            }

            for (int i = 0; i < lineCharCount; i++)
            {
                space = space + " ";
            }
            str = str.Replace("\n", " \n ");
            str = str.Replace("\r", " \r ");
            string[] s = str.Split(' ');


            temp = "";
            int bracket = 0;
            for (int i = 0; i < s.Length;)
            {
                if (i != 0 && s[i - 1] == "\n" && s[i] != "\n")
                {
                    formatedstring = formatedstring + "\n" + temp;
                    temp = "";
                }

                if (i == 1)
                {
                    bracket = 1;
                }

                if ((temp.Length + s[i].Length + bracket) <= lineCharCount)                    //+1 for bracket
                {
                    temp = temp + " " + s[i];
                    i++;
                }
                else
                {
                    if (s[i].Length >= lineCharCount)
                    {
                        int k = temp.Length;
                        temp = temp + " " + s[i].Substring(0, (lineCharCount - temp.Length - bracket) <= 0 ? 1 : (lineCharCount - temp.Length - bracket));
                        s[i] = s[i].Substring(lineCharCount - k);
                        formatedstring = formatedstring + "\n" + temp;
                        temp = "";

                        while (s[i].Length >= lineCharCount)
                        {
                            k = temp.Length;
                            temp = temp + s[i].Substring(0, lineCharCount - temp.Length);
                            s[i] = s[i].Substring(lineCharCount - k);
                            formatedstring = formatedstring + "\n" + temp;
                            temp = "";
                        }
                        if (s[i].Length == 0)
                            i++;
                    }
                    else
                    {
                        formatedstring = formatedstring + "\n" + temp;
                        temp = "";
                    }
                    //-1 for bracket
                }
            }
            if (temp != "")
            {
                formatedstring = formatedstring + "\n" + temp;
            }

            return formatedstring;

        }

        public void MessageCreate()
        {
            string str = "";
            if (Message.Msg != "")
            {
                str = StringFormatChange(Message.Msg, chatUMaximumWidth, messageLB.Font);
                str = str.Substring(1);
            }
            messageLB.Text = str;
            var g = CreateGraphics();
            SizeF a = g.MeasureString(str, messageLB.Font);
            messageLB.Size = new Size((int)(a.Width + 5), (int)a.Height + 20);
            this.Width = messageLB.Width + this.Padding.Left + Padding.Right + chatArcWidth + 5;
            this.Height = messageLB.Height + this.Padding.Top + Padding.Bottom + ChatUBottomP.Height;
            Invalidate();

            if (Message.FromIP.Equals(ChatApplicationNetworkManager.FromIPAddress))
            {
                IsReceivedMessage = false;
            }
            else
            {
                IsReceivedMessage = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int CornerRadius = 10;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, CornerRadius * 2, CornerRadius * 2), 180, 90);
            path.AddLine(CornerRadius, 0, Width - CornerRadius * 2, 0);
            path.AddArc(new Rectangle(Width - CornerRadius * 2, 0, CornerRadius * 2, CornerRadius * 2), -90, 90);
            path.AddLine(Width, CornerRadius * 2, Width, Height - CornerRadius * 2);
            path.AddArc(new Rectangle(Width - CornerRadius * 2, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2), 0, 90);
            path.AddLine(Width - CornerRadius * 2, Height, CornerRadius * 2, Height);
            path.AddArc(new Rectangle(0, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2), 90, 90);
            path.AddLine(0, Height - CornerRadius * 2, 0, CornerRadius * 2);
            path.CloseFigure();

            this.Region = new Region(path);

            using (var pen = new Pen(this.BackColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }


    }
}
