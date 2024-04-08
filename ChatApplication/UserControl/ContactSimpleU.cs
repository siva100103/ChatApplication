using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace ChatApplication
{
    public partial class ContactSimpleU : UserControl
    {
        public event EventHandler<Client> OnClickContactSimpleU;
        private Client contact;      
        public Client Contact
        {
            get
            {
                return contact;
            }
            set
            {
            if(value!=null){
                    contact = value;
                    nameLB.Text = value.Name;
                }                                   
           }
        }
        public Image DpImage
        {
            set
            {
                dpPictureBox.Image = value;
            }
            get
            {
                return dpPictureBox.Image;
            }
        }
        public ContactSimpleU()
        {
            InitializeComponent();
            Resize += ContactSimpleUResize;
            
        }

        public ContactSimpleU(Client _contact)
        {
            InitializeComponent();

            //Initialize Datas
            this.Contact = _contact;

            Resize += ContactSimpleUResize;         
        }

        private void ContactSimpleUResize(object sender, EventArgs e)
        {
            nameLB.Location = new Point(labelP.Width/2 - nameLB.Width/2, labelP.Height/ 2 - nameLB.Height / 2);
        }

        private void ContactSimpleUClick(object sender, EventArgs e)
        {
            OnClickContactSimpleU?.Invoke(this,this.Contact);
        }
    }
}
