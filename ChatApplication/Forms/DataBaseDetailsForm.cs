using ChatApplication.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.Forms
{
    public partial class DataBaseDetailsForm : Form
    {
        [SupportedOSPlatform("windows")]
        public DataBaseDetailsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MessageBox.Show("You Need To Have An Valid MySQl Database To Use this Application.It Seems Your Db Configuration is Not Valid.Please Fill the Form And restart the App","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            string port=PortNumericUpDown.Value.ToString();
            string Uid=UidTextBox.Text;
            string Password = PasswordTextBox.Text;
            ChatApplicationNetworkManager.UpdateLocalData(port, Uid, Password);
            Close();
            MessageBox.Show("Please run Your Application Now","Information",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
    }
}
