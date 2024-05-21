using ChatApplication.Managers;
using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApplication.Forms;

namespace ChatApplication.UserControls
{
    public partial class MenuControl : UserControl
    {
        List<HoverButton> buttonArray;

        public bool ProfileShow
        {
            get { return ProfilePictureBox.Visible; }
            set { ProfilePictureBox.Visible = value; }
        }

        public Image ProfileImage
        {
            get { return ProfilePictureBox.Image; }
            set
            {
                ProfilePictureBox.Image = value;
                ProfilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public Image ChatSymbol
        {
            get { return ChatsBtn.Image; }
            set
            {
                ChatsBtn.Image = value;
            }
        }

        public Image ExitSymbol
        {
            get { return ExitButton.Image; }
            set
            {
                ExitButton.Image = value;
            }
        }

        public Image ArchiveSymbol
        {
            get { return ArchieveButton.Image; }
            set
            {
                ArchieveButton.Image = value;
            }
        }

        public Color HoverSideColor
        {
            get { return ChatsBtn.ButtonSideHoverlineColor; }
            set
            {
                ChatsBtn.ButtonSideHoverlineColor = value;
                ArchieveButton.ButtonSideHoverlineColor = value;

                ChatsBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, BackColor.R+10,BackColor.G+10,BackColor.B+10);
                ChatsBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(BackColor.R+10,BackColor.G+10,BackColor.B+10);

                ArchieveButton.FlatAppearance.MouseDownBackColor = ChatsBtn.FlatAppearance.MouseDownBackColor;
                ArchieveButton.FlatAppearance.MouseOverBackColor = ChatsBtn.FlatAppearance.MouseOverBackColor;

                ExitButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, Color.Red);
                ExitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(BackColor.R+10,BackColor.G+10,BackColor.B+10);
                
            }
        }

        private HoverButton currentObject;
        private Color HoverColor = Color.FromArgb(234, 234, 234);

        public event EventHandler OnClickChatsBtn;
        public EventHandler OnClickCallsBtn;
        public EventHandler OnClickStatusBtn;
        public EventHandler OnClickStarBtn;
        public EventHandler OnClickSettingBtn;
        public event EventHandler OnClickExitBtn;
        public event EventHandler OnClickProfilePicture;
        public event EventHandler ControlClicked;
        public event EventHandler OnArciveButtonClick;

        private HoverMessageForm messageFormobj = null;
        Timer timer = new Timer();

        public MenuControl()
        {
            InitializeComponent();
            buttonArray = new List<HoverButton> { ChatsBtn, CallsBtn, StatusBtn, StarBtn, ArchivedBtn, SettingBtn,ArchieveButton };
            messageFormobj = new HoverMessageForm();
            currentObject = ChatsBtn;
            for (int i = 0; i < buttonArray.Count; i++)
            {
                buttonArray[i].MouseEnter += HoverMessageShow;
                buttonArray[i].MouseLeave += HoverMessageLeave;
                buttonArray[i].Click += ButtonClick;
            }
          

            //messageFormobj.Visible = true;
            //messageFormobj.Enabled = false;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ChatsBtn.Click += ChatsBtnClick;
            CallsBtn.Click += CallsBtnClick;
            StatusBtn.Click += StatusBtnClick;
            StarBtn.Click += StarBtnClick;
            ArchivedBtn.Click += ArchivedBtnClick;
            SettingBtn.Click += SettingBtnClick;
            ArchieveButton.Click += ArchieveButtonClick;

            timer.Interval += 80;
            timer.Tick += MessageFormobjShow;
            if (!DesignMode)
            {
                SetDpPicture();
            }

        }


        private void SetDpPicture()
        {
            Client me = DbManager.Clients[ChatApplicationNetworkManager.LocalIpAddress];
            ProfilePictureBox.Image = me.ProfilePicture;
        }

        private void ArchieveButtonClick(object sender, EventArgs e)
        {
            OnArciveButtonClick?.Invoke(this, e);
        }
        
        private void ProfilePictureBoxClick(object sender, EventArgs e)
        {
            OnClickProfilePicture?.Invoke(this, EventArgs.Empty);
        }

        private void SettingBtnClick(object sender, EventArgs e)
        {
            OnClickSettingBtn?.Invoke(sender, EventArgs.Empty);
        }

        private void ArchivedBtnClick(object sender, EventArgs e)
        {
            OnArciveButtonClick?.Invoke(sender, EventArgs.Empty);
        }

        private void StarBtnClick(object sender, EventArgs e)
        {
            OnClickStarBtn?.Invoke(sender, EventArgs.Empty);
        }


        private void StatusBtnClick(object sender, EventArgs e)
        {
            OnClickStatusBtn?.Invoke(sender, EventArgs.Empty);
        }

        private void CallsBtnClick(object sender, EventArgs e)
        {
            OnClickCallsBtn?.Invoke(sender, EventArgs.Empty);
        }

        private void ChatsBtnClick(object sender, EventArgs e)
        {
            OnClickChatsBtn?.Invoke(sender, EventArgs.Empty);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender != currentObject)
            {
                HoverButton obj = (HoverButton)(sender);
                if (currentObject != null)
                {
                    if (buttonArray.IndexOf(obj) > buttonArray.IndexOf(currentObject))
                    {
                        currentObject.IsFormUp = false;
                        obj.IsFormUp = true;
                    }
                    else
                    {
                        currentObject.IsFormUp = true;
                        obj.IsFormUp = false;
                    }
                    currentObject.CallToLeaveSideLineEffect();
                }
                currentObject = obj;

            }
        }

        private void CustomPictureBox1Click(object sender, EventArgs e)
        {

        }

        private void DPPanelHover(object sender, EventArgs e)
        {
            ProfilePictureBox.BackColor = HoverColor;
        }

        private void DPPanelLeave(object sender, EventArgs e)
        {
            ProfilePictureBox.BackColor = Color.Transparent;

        }

        private void HoverMessageShow(object sender, EventArgs e)
        {
            Control obj = (Control)sender;
            if (obj == SettingBtn)
            {
                messageFormobj.MessageText = "Setting";
            }
            else if (obj == ArchivedBtn)
            {
                messageFormobj.MessageText = "Archived Chats";

            }
            else if (obj == StarBtn)
            {
                messageFormobj.MessageText = "Starred messages";
            }
            else if (obj == ChatsBtn)
            {
                //messageFormobj.MessageText = "Chats";
                return;
            }
            else if(obj == ArchieveButton)
            {
                return;
            }
            else if (obj == CallsBtn)
            {
                messageFormobj.MessageText = "Calls";

            }
            else if (obj == StatusBtn)
            {
                messageFormobj.MessageText = "Status";

            }
            messageFormobj.Location = PointToScreen(new Point(obj.Location.X + (obj.Width / 2) - (messageFormobj.Width / 2), obj.Location.Y - messageFormobj.Height - 10));
            timer.Start();
            messageFormobj.Opacity = 10;

        }
        public void MessageFormobjShow(object sender, EventArgs e)
        {
            if (messageFormobj.Visible == false)
            {
                messageFormobj.Show();
                messageFormobj.Focus();
            }
            //if (messageFormobj.Enabled = false)
            //{
            //    messageFormobj.Enabled = true;

            //}
            //messageFormobj.BringToFront();
            messageFormobj.Opacity += 10;
            if (messageFormobj.Opacity >= 100)
            {
                timer.Stop();
            }
        }
        private void HoverMessageLeave(object sender, EventArgs e)
        {
            //messageFormobj.Enabled = false;
            messageFormobj.Hide();
            timer.Stop();
        }

        private void MenuControlLoad(object sender, EventArgs e)
        {
            ExitButton.ButtonSideHoverlineColor = Color.Transparent;
            ExitButton.MouseDown += ExitButtonMouseDown;
            ExitButton.MouseUp += ExitButtonMouseUp;
        }

        private void ExitButtonMouseUp(object sender, MouseEventArgs e)
        {
            ExitButton.BackColor = Color.Transparent;
            OnClickExitBtn?.Invoke(this, e);
        }

        private void ExitButtonMouseDown(object sender, MouseEventArgs e)
        {
            ExitButton.BackColor = Color.Red;
        }

        private void ProfilePictureBoxMouseEnter(object sender, EventArgs e)
        {
            ProfilePictureBox.BackColor = ChatsBtn.FlatAppearance.MouseOverBackColor;
        }

        private void ProfilePictureBoxMouseLeave(object sender, EventArgs e)
        {
            ProfilePictureBox.BackColor = Color.Transparent;
        }

        private void ExitButtonMouseHover(object sender, EventArgs e)
        {
            ExitButton.IsFormUp = false;
            ExitButton.ButtonSideHoverlineColor = Color.Red;
            ExitButton.CallToLeaveSideLineEffect();
            ExitButton.IsSelected = true;
        }

        private void ExitButtonMouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Transparent;
            ExitButton.ButtonSideHoverlineColor = Color.Red;
            ExitButton.CallToLeaveSideLineEffect();
            ExitButton.IsSelected = false;
        }

        private void MenuControlMouseClick(object sender, MouseEventArgs e)
        {
            ControlClicked?.Invoke(this, e);
        }
    }
}
