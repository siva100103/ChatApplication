using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
    [SupportedOSPlatform("windows")]

    public partial class HoverMessageU : UserControl
    {
        private string message = "Message";

        public string MessageText
        {
            get => message;
            set
            {
                message = value;
                MessageLB.Text = message;
                Size = new Size(MessageLB.Width + 6, MessageLB.Height + 10);
                Padding = new Padding(3, 3, 3, 3);
            }
        }

        public HoverMessageU()
        {
            InitializeComponent();
        }

        private void HoverMessageULoad(object sender, EventArgs e)
        {

        }
    }
}
