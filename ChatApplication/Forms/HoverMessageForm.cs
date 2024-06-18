using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication.Forms
{
    [SupportedOSPlatform("windows")]

    public partial class HoverMessageForm : Form
    {
        public HoverMessageForm()
        {
            InitializeComponent();
        }
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


    }
}
