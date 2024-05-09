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
using ChatApplication;
using ChatApplication.Managers;
using ChatApplication.Models;
namespace ChatApplication.UserControls
{
    public partial class ContactU : UserControl
    {
        public Image Img { get; set; } 
        public string UserName { get; set; } = "";
        public Client Client { get; set; }
        public string TimeLB
        {
            set
            {
                timeLB.Text = value;
            }
        }

        public Color MPBackColor
        {
            set
            {
                mainP.BackColor = value;
            }
            get
            {
                return mainP.BackColor;
            }
        }
        public bool Selected { get; set; } = false;
        public event EventHandler Clicked;

        public ContactU(Client c)
        {
            InitializeComponent();
            BackColor = Color.Transparent;

            Client = c;
            UserName = c.Name;
            Img = c.ProfilePicture;
            contactNameLB.Text = c.Name;
            dpPictureBox.Image = Img;

            ChatApplication.Models.Message LastMsg = DbManager.Messages.Values.LastOrDefault(m =>
                {
                    return (m.FromIP.Equals(ChatApplicationNetworkManager.LocalIpAddress) && m.ReceiverIP.Equals(c.IP)) || (m.FromIP.Equals(c.IP) && m.ReceiverIP.Equals(ChatApplicationNetworkManager.LocalIpAddress));
                });

            if (LastMsg != null)
            {
                string LastMsgTime = LastMsg.Time.Hour + ":" + LastMsg.Time.Minute;
                TimeLB = LastMsgTime;
            }
           
            contactInformationP.MouseEnter+= Hovering;
            timeP.MouseEnter += Hovering;
            dpPictureBox.MouseEnter += Hovering;
            contactNameLB.MouseEnter += Hovering;
            lastMessageLB.MouseEnter += Hovering;

            contactInformationP.MouseLeave += Leaving;
            timeP.MouseLeave += Leaving;
            dpPictureBox.MouseLeave += Leaving;
            contactNameLB.MouseLeave += Leaving;
            lastMessageLB.MouseLeave += Leaving;

            contactInformationP.MouseClick += LabelClicked;
            timeP.MouseClick += LabelClicked;
            dpPictureBox.MouseClick += LabelClicked;
            contactNameLB.MouseClick += LabelClicked;
            lastMessageLB.Click += LabelClicked;

            c.StatusChanged += StatusChange;
            c.UnseenMessageChanged += UpdateUnseenMessage;
            UpdateUnseenMessage(Client,Client.UnseenMessages);

            if (c.UnseenMessages > 0)
            {
                PendingMessages.Visible = true;
                PendingMessages.UnReadCount(c.UnseenMessages);
            }

            c.MessageSend += (obj, e) => SetTimeLbValue();
            c.MessageReceive += (obj, e) => SetTimeLbValue();
        }

        private void UpdateUnseenMessage(object sender, int n)
        {
            if (n == 0) PendingMessages.Visible = false;
            else
            {
                PendingMessages.Visible = true;
                PendingMessages.UnReadCount(n);
            }
        }

        private void StatusChange(object sender, bool e)
        {
            if (e) statusIndicator1.Color = Color.FromArgb(128, 255, 128);
            else statusIndicator1.Color = Color.FromArgb(255, 128, 128);
        }

        private void LabelClicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(Client,e);
            ChatApplicationNetworkManager.SendResponseForReadedMessage(Client.UnSeenMessagesList,Client);
            ChatApplicationNetworkManager.MessagePage = Client.MessagePage;
            Client.UnseenMessages = 0;
            Selected = true;
        }

        private void Leaving(object sender, EventArgs e)
        {
            if (!Selected)
            {
                SuspendLayout();
                mainP.BackColor = Color.FromArgb(243,243,243);
                ResumeLayout();
            }
        }

        private void Hovering(object sender, EventArgs e)
        {
            if (!Selected)
            {
                SuspendLayout();
                Cursor = Cursors.Hand;
                mainP.BackColor = Color.FromArgb(209, 209, 209);
                ResumeLayout();
            }
        }

        private void SetTimeLbValue()
        {
            DateTime now = DateTime.Now;
            string LbValue = now.Hour + ":" + now.Minute;
            TimeLB = LbValue;
        }

        public void UpdateDetais(Image i)
        {
            dpPictureBox.Image = i;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int CornerRadius = 27;
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
