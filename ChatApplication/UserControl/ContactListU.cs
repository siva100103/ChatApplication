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
