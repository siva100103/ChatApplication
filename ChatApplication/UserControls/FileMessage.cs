using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Versioning;

namespace ChatApplication.UserControls
{
    [SupportedOSPlatform("windows")]

    public partial class FileMessage : UserControl
    {
        private string FilePath = "";

        public FileMessage(string path)
        {
            InitializeComponent();
            DoubleBuffered = true;
            FilePath = path;
        }

        private void FileMessageLoad(object sender, EventArgs e)
        {
            if (FilePath != "")
            {
                FileNameLabel.Text = Path.GetFileName(FilePath);
            }

            FileNameLabel.MouseClick += OnMouseClick;
            PicturePanel.MouseClick += OnMouseClick;
            FilePicture.MouseClick += OnMouseClick;
            MainPanel.MouseClick += OnMouseClick;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            string path = FilePath;
            string NetworkPath = @"\\SPARE-B11\Chat Application Profile\";
            string filePath = Path.Combine(NetworkPath, Path.GetFileNameWithoutExtension(path) + Path.GetExtension(path));
            try
            {
                if (File.Exists(filePath))
                {
                    //Process.Start(filePath);
                    string extension = Path.GetExtension(filePath);
                    string filter = "All Files (*.*)|*.*";

                    if (!string.IsNullOrEmpty(extension))
                    {
                        string fileExtension = extension.ToUpperInvariant().TrimStart('.');
                        filter = $"{fileExtension} Files (*{extension})|*{extension}|All Files (*.*)|*.*";
                    }
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.FileName = Path.GetFileName(filePath);
                        saveFileDialog.Filter = filter;
                        saveFileDialog.Title = "Save File As";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string destinationPath = saveFileDialog.FileName;

                            try
                            {
                                File.Copy(filePath, destinationPath, true);
                                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch
            {
                MessageBox.Show("File not found.");
            }
            Dispose();
        }

        public void ThemeChange()
        {
            FilePicture.BackColor = ChatTheme.OuterLayerColor;
            PicturePanel.BackColor = ChatTheme.ContactsColor;
            FileNameLabel.BackColor = ChatTheme.BorderColor;
            FileNameLabel.ForeColor = ChatTheme.TextColor;
        }
    }
}
