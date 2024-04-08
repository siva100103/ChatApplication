using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{

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

        private void HoverMessageFormLoad(object sender, EventArgs e)
        {

        }
    }
}
