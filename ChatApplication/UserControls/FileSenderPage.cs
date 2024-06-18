using System;
using System.Drawing;
using System.IO;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace ChatApplication.UserControls
{
    [SupportedOSPlatform("windows")]

    public partial class FileSenderPage : UserControl
    {
        public EventHandler<string> FileMsgReady;
        public event EventHandler CloseButtonClicked;

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
            DoubleBuffered = true;
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            if (path != "")
            {
                string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
                string newfilePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(path) + Path.GetExtension(path));
                if (!File.Exists(newfilePath))
                {
                    File.Copy(path, newfilePath, true);
                }
                FileMsgReady?.Invoke(this, path);
            }
            Hide();
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            CloseButtonClicked?.Invoke(this, e);
            Hide();
            path = "";
            FileNameLabel.Text = "";
        }

        public void OnThemeChanged()
        {
            //Back Color
            FileNameLabel.BackColor = ChatTheme.BorderColor;
            SendButton.BackColor = ChatTheme.BorderColor;
            InfoLabel.BackColor = ChatTheme.OuterLayerColor;
            FilePicture.BackColor = ChatTheme.OuterLayerColor;
            CloseButton.BackColor = ChatTheme.ContactsColor;
            PreviewPanel.BackColor = ChatTheme.ContactBackgroundColor;

            //Hover color
            CloseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, CloseButton.BackColor);

            //Fore color
            FileNameLabel.ForeColor = ChatTheme.TextColor;
            InfoLabel.ForeColor = ChatTheme.TextColor;
        }
    }
}
