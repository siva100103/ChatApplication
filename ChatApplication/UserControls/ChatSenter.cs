﻿using System;
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
    public partial class ChatSenter : UserControl
    {
        public EventHandler<string> MsgReady;
        public EventHandler<string> FileChoosen;

        private int initialHeightOfRichtextbox;
        private Point initialLocationRichtextbox;
        private Size initialSize;
        public Point initialLocation;
        private int flag = 0, flag2 = 0;

        [Browsable(true)]
        public bool FileShareIconVisibility
        {
            get { return FileShareIcon.Visible; }
            set { FileShareIcon.Visible = value; }
        }

        public bool SendButtonVisibility
        {
            get { return SendButton.Visible; }
            set { SendButton.Visible = value; }
        }

        public Image SendButtonSymbol
        {
            get { return SendButton.Image; }
            set
            {
                SendButton.Image = value;
            }
        }

        public Image FileShareSymbol
        {
            get { return FileShareIcon.Image; }
            set
            {
                FileShareIcon.Image = value;
                TextArea.ForeColor = ChatTheme.TextColor;
            }
        }

        public string TextMessage
        {
            get { return TextArea.Text; }
            set { TextArea.Text = value; }
        }

        public Color SenderColor
        {
            get { return BackColor; }
            set
            {
                BackColor = value;
                TextArea.BackColor = value;
                SendButton.BackColor = value;
                FileShareIcon.BackColor = value;
            }
        }

        public ChatSenter()
        {
            InitializeComponent();
            DoubleBuffered = true;
            TextArea.BackColor = Color.FromArgb(243, 243, 243);
            TextArea.Font = new Font("Noto Emoji", 16);
            TextArea.GotFocus += TextAreaGotFocus;
            TextArea.LostFocus += TextAreaLostFocus;

            pictureBox1.MouseLeave += MouseLev1;
            FileShareIcon.MouseLeave += MouseLev1;
            SendButton.MouseLeave += MouseLev1;
            pictureBox1.MouseEnter += MouseEnt1;
            SendButton.MouseEnter += MouseEnt1;
            FileShareIcon.MouseEnter += MouseEnt1;

            initialHeightOfRichtextbox = TextArea.Height;
            initialLocationRichtextbox = TextArea.Location;
            initialSize = Size;

            foreach (Control control in Controls)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, control, new object[] { true });
            }
        }

        private void TextAreaLostFocus(object sender, EventArgs e)
        {
            TextArea.Text = "Type a message";
            TextArea.ForeColor = ChatTheme.TextColor;
        }

        private void TextAreaGotFocus(object sender, EventArgs e)
        {
            TextArea.Text = "";
            TextArea.ForeColor = ChatTheme.TextColor;
        }

        public void OnThemeChange()
        {
            TextArea.ForeColor = ChatTheme.TextColor;
            Refresh();
        }

        private void MouseEnt1(object o, EventArgs e)
        {
            PictureBox p = (PictureBox)o;
            p.BackColor = ChatTheme.OuterLayerColor;

        }
        private void MouseLev1(object o, EventArgs e)
        {
            PictureBox p = (PictureBox)o;
            p.BackColor = ChatTheme.ContactsColor;
        }

        private void TextAreaMouseClick(object sender, MouseEventArgs e)
        {
            if (TextArea.Text == "Type a message")
            {
                TextArea.Text = "";
            }
            //   TextArea.ForeColor = ChatTheme.TextColor;
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            TextArea.ForeColor = ChatTheme.TextColor;
            MsgReady?.Invoke(sender, TextArea.Text);
            TextArea.Text = "";
        }

        private void FileShareIconClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Choose File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    FileChoosen?.Invoke(this, path);
                }
            }
        }

        private void TextAreaKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TextArea.Text != "")
            {
                MsgReady?.Invoke(sender, TextArea.Text);
                TextArea.ResetText();
                TextArea.Text = "Type a message";
                TextArea.ForeColor = Color.FromArgb(200, 200, 200);

                Size = initialSize;
                Location = initialLocation;
                flag = 0;
            }
        }

        private void TextAreaTextChanged(object sender, EventArgs e)
        {
            if (TextArea.ForeColor == Color.FromArgb(200, 200, 200) && !TextArea.Text.Equals("Type a message") && TextArea.Text.Length >= 1)
            {
                TextArea.Text = TextArea.Text.ToString().Substring(0, 1);
                TextArea.ForeColor = Color.Black;
                TextArea.SelectionStart = TextArea.Text.Length;
                TextArea.ScrollToCaret();
            }
            // Measure the width of the text
            int textWidth = TextRenderer.MeasureText(TextArea.Text, TextArea.Font).Width;

            if (textWidth >= TextArea.Width && flag == 0)
            {

                Height += initialHeightOfRichtextbox;
                Location = new Point(Location.X, Location.Y - initialHeightOfRichtextbox);
                TextArea.Location = new Point(TextArea.Location.X, TextArea.Location.Y - initialHeightOfRichtextbox);//(int)((float)richTextBox1.Height/1.5));
                TextArea.Height *= 2;

                flag = 1;
                flag2 = 1;
            }

            else if (textWidth <= TextArea.Width && TextArea.Height > initialHeightOfRichtextbox && flag2 == 1)
            {
                Height = initialHeightOfRichtextbox;
                Location = new Point(Location.X, Location.Y + initialHeightOfRichtextbox);
                TextArea.Location = new Point(TextArea.Location.X, TextArea.Location.Y + initialHeightOfRichtextbox);
                flag = 0;
            }
        }
    }
}
