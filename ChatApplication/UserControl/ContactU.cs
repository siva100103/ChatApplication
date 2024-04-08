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

namespace WindowsFormsApp3
{
    public partial class ContactU : UserControl
    {
        public Image img { get; set; } 
        public string Name { get; set; } = "";
        public Client Client { get; set; }
        public string TimeLB
        {
            set
            {
                timeLB.Text = value;
            }
        }
        public event EventHandler Clicked;
        public ContactU(Client c)
        {
            InitializeComponent();
            Client = c;
            img = c.Dp;
            contactNameLB.Text = c.Name;
            dpPictureBox.Image = img;

            contactInformationP.MouseEnter+= Hovering;
            timeP.MouseEnter += Hovering;
            dpPictureBox.MouseEnter += Hovering;
            contactNameLB.MouseEnter += Hovering;

            contactInformationP.MouseLeave += Leaving;
            timeP.MouseLeave += Leaving;
            dpPictureBox.MouseLeave += Leaving;
            contactNameLB.MouseLeave += Leaving;

            contactInformationP.MouseClick += LabelClicked;
            timeP.MouseClick += LabelClicked;
            dpPictureBox.MouseClick += LabelClicked;
            contactNameLB.MouseClick += LabelClicked;
            lastMessageLB.Click += LabelClicked;
            c.StatusChanged += statusChange;
            c.UnseenMessageChanged += UpdateUnseenMessage;
            UpdateUnseenMessage(Client,Client.UnseenMessages);
        }

        private void UpdateUnseenMessage(object sender, int n)
        {
            if (n == 0) bendingMessages1.Visible = false;
            else
            {
                bendingMessages1.Visible = true;
                bendingMessages1.UnReadCount(n);
            }
        }

        private void statusChange(object sender, bool e)
        {
            if (e) statusIndicator1.Color = Color.FromArgb(128, 255, 128);
            else statusIndicator1.Color = Color.FromArgb(255, 128, 128);
        }

        private void LabelClicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(Client,e);
            if(Client.IsConnected)
            ChatApplicationNetworkManager.SendResponseForReadedMessage(Client.UnSeenMessages,Client);

            ChatApplicationNetworkManager.MessagePage = Client.MessagePage;
            Client.UnseenMessages = 0;
            ChatApplicationNetworkManager.MessagePage = Client.MessagePage;
        }

        private void Leaving(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void Hovering(object sender, EventArgs e)
        {
            Cursor=Cursors.Hand;
            BackColor = Color.LightGray;
        }
    }
}
