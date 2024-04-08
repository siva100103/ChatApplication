using System;
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
    public partial class ChatPageTitleU : UserControl
    {
        private string conatctImagePath;
        public string ConatctImagePath
        {
            set
            {
            if(value!=null&&value!=""){
                    conatctImagePath = value;
                    contactDpPicturePB.Image = Image.FromFile(value);
                }               
            }
            get
            {
                return conatctImagePath;
            }
        }
        public Image ConatctImage
        {
            set
            {

                contactDpPicturePB.Image = value;
            }

        }
        public string ConatctName{
            set
            {
                nameLB.Text = value;
            }
            get
            {
                return nameLB.Text;
            }
        }
        public string groupinfoText{
            set
            {
                infoLB.Text = value;
            }
            get
            {
                return infoLB.Text;
            }
        }
        public ChatPageTitleU()
        {
            InitializeComponent();
            searchBtn.Click += SearchBtnClick;

        }
     
        

        private void SearchBtnClick(object sender, EventArgs e)
       {
           
        }

        private void ChatPageTitleUClick(object sender, EventArgs e)
        {

        }
    }
}
