using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApplication.Managers;
using ChatApplication.Models;

namespace ChatApplication.UserControls
{
    public partial class StarredMessages : UserControl
    {
        private int chatArcWidth = 10;
        private Models.Message message;
        private int chatUMaximumWidth = 400;

        public Models.Message Message
        {
            set
            {
                if (value != null)
                {
                    message = value;
                }

            }
            get
            {
                return message;
            }
        }

        public StarredMessages(Models.Message msg)
        {
            InitializeComponent();
            Message = msg;
        }

        private void StarredMessagesLoad(object sender, EventArgs e)
        {
            MessageCreate();
            MouseClick += OnMouseClick;
            messageLB.MouseClick += OnMouseClick;
            ChatUBottomP.MouseClick += OnMouseClick;
            StarIcon.MouseClick += OnMouseClick;

            messageLB.MouseDown += OnMouseDown;
            ChatUBottomP.MouseDown += OnMouseDown;
            StarIcon.MouseDown += OnMouseDown;
            MouseDown += OnMouseDown;

            messageLB.MouseUp += OnMouseUp;
            ChatUBottomP.MouseUp += OnMouseUp;
            StarIcon.MouseUp += OnMouseUp;
            MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            BackColor = SystemColors.Control;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(209, 209, 209);
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Clipboard.SetText(Message.Msg);
            }
            else if(e.Button == MouseButtons.Right)
            {
                Message.Starred = false;
                DbManager.StarMessages(Message);
                Dispose();
            }
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
            Width = messageLB.Width + Padding.Left + Padding.Right + chatArcWidth + 5;
            Height = messageLB.Height + Padding.Top + Padding.Bottom + ChatUBottomP.Height;
            Invalidate();
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

    }
}
