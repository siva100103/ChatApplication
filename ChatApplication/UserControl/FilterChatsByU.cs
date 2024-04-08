using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class FilterChatsByU : UserControl
    {
        public event EventHandler OnClickUnreadBtn;
        public event EventHandler OnClickContactBtn;
        public event EventHandler OnClickNonContactBtn;
        public event EventHandler OnClickGroupBtn;
        public event EventHandler OnClickDraftsBtn;
        public FilterChatsByU()
        {
            InitializeComponent();
            unreadBtn.Click += UnreadBtnClick;
            contactBtn.Click += ContactBtnClick;
            nonContactBtn.Click += NonContactBtnClick;
            groupsBtn.Click += GroupsBtnClick;
            draftsBtn.Click += DraftsBtnClick;
        }

        private void DraftsBtnClick(object sender, EventArgs e)
        {
            OnClickDraftsBtn?.Invoke(this, EventArgs.Empty);
        }

        private void GroupsBtnClick(object sender, EventArgs e)
        {
            OnClickGroupBtn?.Invoke(this, EventArgs.Empty);
        }

        private void NonContactBtnClick(object sender, EventArgs e)
        {
            OnClickNonContactBtn?.Invoke(this, EventArgs.Empty);
        }

        private void ContactBtnClick(object sender, EventArgs e)
        {
            OnClickContactBtn?.Invoke(this, EventArgs.Empty);
        }
       
        private void UnreadBtnClick(object sender, EventArgs e)
        {
            OnClickUnreadBtn?.Invoke(this,EventArgs.Empty);
        }

        private void BtnMouseEnter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = ColorTranslator.FromHtml("#D4D2D1");
        }

        private void BtnMouseLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = Color.Transparent;
        }
    }
}
