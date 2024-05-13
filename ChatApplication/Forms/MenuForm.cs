using ChatApplication.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApplication;
using ChatApplication.UserControls;

namespace ChatApplication.Forms
{
    public partial class MenuForm : Form
    {
        public event EventHandler Delete;
        public event EventHandler Copy;
        public event EventHandler<List<ChatU>> Star;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuFormLoad(object sender, EventArgs e)
        {
            Opacity = 0.9;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LostFocus += MenuFormLostFocus;
        }

        private void MenuFormLostFocus(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void MenuFormMouseEnter(object sender, EventArgs e)
        {
            Control current = sender as Control;
            current.BackColor = Color.FromArgb(159, 192, 218);
        }

        private void MenuFormMouseLeave(object sender, EventArgs e)
        {
            Control current = sender as Control;
            current.BackColor = Color.Transparent;
        }

        private void DeleteLabelClick(object sender, EventArgs e)
        {
            if(ChatApplicationNetworkManager.SelectedMessages.Count > 0)
            {
                Delete?.Invoke(this, e);

                foreach (ChatU msg in ChatApplicationNetworkManager.SelectedMessages)
                {
                    msg.Message.Msg = "This Message is Deleted";
                    msg.MessageCreate();
                    msg.BackColor = Color.FromArgb(208, 212, 227);
                    msg.ChatMessageIcon = Properties.Resources.icons8_double_tick_13;
                    DbManager.DeleteMessage(msg.MessageId);
                }
                ChatApplicationNetworkManager.SelectedMessages.Clear();
            }
            Hide();
        }

        private void CopyLabel_Click(object sender, EventArgs e)
        {
            if (ChatApplicationNetworkManager.SelectedMessages.Count > 0)
            {
                Copy?.Invoke(this, e);

                string toBeCopied = "";
                foreach (ChatU msg in ChatApplicationNetworkManager.SelectedMessages)
                {
                    toBeCopied += msg.Message.Msg + " ";
                }

                Clipboard.SetText(toBeCopied);
            }
            Hide();
            ChatApplicationNetworkManager.SelectedMessages.Clear();
        }

        private void StarLabelClick(object sender, EventArgs e)
        {
            if (ChatApplicationNetworkManager.SelectedMessages.Count > 0)
            {
                Star?.Invoke(this, ChatApplicationNetworkManager.SelectedMessages);
                ChatApplicationNetworkManager.SelectedMessages.Clear();
            }
            Hide();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
