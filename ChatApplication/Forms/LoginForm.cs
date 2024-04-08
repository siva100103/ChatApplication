using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
          
            Resize += LoginFormResize;
            LoginFormResize(this, EventArgs.Empty);
            nextBtn.Click += NextBtnClick;           
            Load += LoginFormLoad;
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
             
           // ipAddressLB.Text += ChatApplicationNetworkManager.GetPcIPAddress();
            LoginFormResize(this, EventArgs.Empty);
            
        

        }

        private void NextBtnClick(object sender, EventArgs e)
        {
          // ChatApplicationDatabaseManager.ContactCreate(firstNameTB.TextBoxtext,lastNameTB.TextBoxtext, ChatApplicationNetworkManager.GetPcIPAddress());
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();

        }

        private void LoginFormResize(object sender, EventArgs e)
        {
           centerP.Location= new Point(Width/2-centerP.Width/2, Height/2-centerP.Height/2);
            firstNameTB.Location = new Point(centerP.Width / 2 - firstNameTB.Width/2, firstNameTB.Location.Y);
            lastNameTB.Location = new Point(centerP.Width / 2 - lastNameTB.Width/2, lastNameTB.Location.Y);
            ipAddressLB.Location = new Point(centerP.Width / 2 - ipAddressLB.Width / 2, ipAddressLB.Location.Y);
            dpPictureU.Location=new Point(centerP.Width /2 - dpPictureU.Width/2, dpPictureU.Location.Y);
            nextBtn.Location= new Point(centerP.Width / 2 - nextBtn.Width / 2, nextBtn.Location.Y);
            centerP.BringToFront();
        } 

       
    }
}
