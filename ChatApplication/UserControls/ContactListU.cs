using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApplication.Models;

namespace ChatApplication.UserControls
{
    public partial class ContactListU : UserControl
    {

        public ContactListU()
        {
            InitializeComponent();
        }

        public void AddContact(Client contact){
            ContactSimpleU contactSimpleU = new ContactSimpleU(contact) { Dock=DockStyle.Top};
            contactLoadP.Controls.Add(contactSimpleU);
        }
    }
}
