using ChatApplication.Models;
using ChatApplication.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.Forms
{
    public partial class TestForm : Form
    {
        public TestForm(List<MessageModel> messages)
        {
            InitializeComponent();
            LazyLoadingPanel lp = new LazyLoadingPanel(messages);
            lp.Dock = DockStyle.Fill;
            Controls.Add(lp);
            lp.AutoScroll = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
