using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
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
                this.Size = new Size(MessageLB.Width + 6, MessageLB.Height + 10);
                Padding = new Padding(3, 3, 3, 3);
            }
        }
        public HoverMessageU()
        {
            InitializeComponent();
        }

        private void HoverMessageU_Load(object sender, EventArgs e)
        {

        }
    }
}
