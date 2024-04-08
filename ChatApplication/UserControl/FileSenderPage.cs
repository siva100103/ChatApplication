using System;
using System.IO;
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
    public partial class FileSenderPage : UserControl
    {
        public EventHandler<string> FileMsgReady;
        private string path = "";
        public string FileName
        {
            get { return FileNameLabel.Text; }
            set
            {
                path = value;
                FileNameLabel.Text = Path.GetFileName(path);
            }
        }
        public FileSenderPage()
        {
            InitializeComponent();
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            if (path != "")
            {
                //FileMsgReady?.Invoke(this, path); 
            }
            Hide();
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Hide();
            path = "";
            Chat.TextMessage = "Type a message";
        }
    }
}
