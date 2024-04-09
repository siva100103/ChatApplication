using ChatApplication.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace ChatApplication
{
    public partial class MainForm : Form
    {

        #region Curve Dll
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion
        ProfilePage MyProfile;
        RemoteDatabase MyDetails = new RemoteDatabase();

        public MainForm()
        {
            InitializeComponent();
            Initial();
            SideMenuBar.OnClickProfilePicture += OnProfileInfoClick;
           
            MyProfile = new ProfilePage
            {
                Size = new Size((Width * 74) / 100, (Height * 62) / 100),
                StartPosition = FormStartPosition.Manual,
                UserName = MyDetails.Clients.FirstOrDefault(c => c.IP.Equals(ChatApplicationNetworkManager.FromIPAddress.ToString()))?.Name,
                ProfilePhoto = SideMenuBar.ProfileImage
            };
            ChatApplicationNetworkManager.Inform += ChatApplicationNetworkManagerInform;
        }

        private void ChatApplicationNetworkManagerInform()
        {
            chatContactPanel.Controls.Clear();
            foreach(var a in ChatApplicationNetworkManager.ContactLabels)
            {
                chatContactPanel.Controls.Add(a);
                a.Clicked += PageAdd;
            }
        }

        private bool click = false;
        private void OnProfileInfoClick(object sender, EventArgs e)
        {
            Point location = PointToScreen(SideMenuBar.Location);
            location.Offset(SideMenuBar.Width + 10, SideMenuBar.Height - MyProfile.Height - 20);
            MyProfile.Location = location;
            if (!click)
            {
                MyProfile.Visible = true;
            }
            else
            {
                MyProfile.Visible = false;
            }
            click = !click;
        }

        private void PageAdd(object sender, EventArgs e)
        {
            MessagePagePanel.Controls.Clear();
            MessagePage page = (sender as Client).MessagePage;
            if (page != null)
            {
                page.Dock = DockStyle.Fill;
                MessagePagePanel.Controls.Add(page);
            }
        }

        public void Initial()
        {
            ChatApplicationNetworkManager.Initialize();
            foreach (var a in ChatApplicationNetworkManager.Clients)
            {
                ContactU con = new ContactU(a.Value)
                {
                    Dock = DockStyle.Top
                };
                //ct.Add(con);
                chatContactPanel.Controls.Add(con);
                con.Clicked += PageAdd;
            }

        }

        protected async override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
  
            foreach (var a in ChatApplicationNetworkManager.Clients)
            {
                Message msg = new Message(ChatApplicationNetworkManager.FromIPAddress, a.Value.IP, "Close", DateTime.Now, Type.Response);
                if (a.Value.IsConnected)
                {
                    await ChatApplicationNetworkManager.SendMessage(msg, a.Value);
                }
            }
        }
    }
}
