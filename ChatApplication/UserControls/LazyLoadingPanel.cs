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
using ChatApplication.Managers;

namespace ChatApplication.UserControls
{
    public partial class LazyLoadingPanel : UserControl
    {
        List<MessageModel> messages = new List<MessageModel>();
        List<ChatU> chats = new List<ChatU>();
        private int PreviousMessageIndex;
        private int NextMessageIndex;
       
        public LazyLoadingPanel(List<MessageModel> messages)
        {
            InitializeComponent();
            //this.messages = messages;
            MouseWheel += LazyLoadingPanel_MouseWheel;
            DbManager.ServerDbConfig();
            DbManager.LocalDbConfig();
            this.messages=ChatApplicationNetworkManager.GetMessages(ChatApplicationNetworkManager.LocalIpAddress,"192.168.3.140");
            InitialMessageLoad();
        }

        private void LazyLoadingPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta>0)
            {
                PreviousMessageLoader();
            }
            else
            {
                NextMessageLoader();
            }
        }

        private void InitialMessageLoad()
        {
            int CurrentHeight = 0;
            for (int i=0;i<messages.Count;i++)
            {
                MessageModel msg = messages[i];
                ChatU chat = new ChatU(msg);
               // chat.MessageCreate();
                Panel p = new Panel
                {
                    Height = chat.Height,
                    Dock = DockStyle.Top
                };
                p.Controls.Add(chat);
                if (CurrentHeight > Height)
                {
                    PreviousMessageIndex = i;
                    break;
                }
                CurrentHeight += chat.Height;
                chats.Add(chat);
                Docker(chat);
                Controls.Add(p);
            }

        }

        private void NextMessageLoader()
        {
            if (NextMessageIndex != -1)
            {
                PreviousMessageIndex = messages.IndexOf(chats[chats.Count - 1].Message);
                chats[chats.Count - 1].Parent.Dispose();
                chats[chats.Count - 1].Dispose();
                chats.RemoveAt(chats.Count - 1);
                ChatU chat = new ChatU(messages[NextMessageIndex]);
                Panel p = new Panel
                {
                    Height = chat.Height,
                    Dock = DockStyle.Bottom
                };
                p.Controls.Add(chat);
                Controls.Add(p);
                chats.Insert(0, chat);
                ScrollControlIntoView(p);
                NextMessageIndex = (NextMessageIndex - 1 >= 0) ? NextMessageIndex - 1 : -1;
                Docker(chat);
            }

        }

        private void PreviousMessageLoader()
        {
            if (PreviousMessageIndex != -1)
            {
                NextMessageIndex = messages.IndexOf(chats[0].Message);
                chats[0].Parent.Dispose();
                chats[0].Dispose();
                chats.RemoveAt(0);
                ChatU chat = new ChatU(messages[PreviousMessageIndex]);
                Panel p = new Panel
                {
                    Height = chat.Height,
                    Dock = DockStyle.Top
                };
                p.Controls.Add(chat);
                p.BackColor = Color.Gold;
                Controls.Add(p);
                chats.Add(chat);
                ScrollControlIntoView(p);
                PreviousMessageIndex = (PreviousMessageIndex + 1 < messages.Count) ?PreviousMessageIndex + 1 : -1;
                Docker(chat);
            }
        }

       private void Docker(ChatU chat)
        {
            if (chat.Message.FromIP.Equals(ChatApplicationNetworkManager.LocalIpAddress))
            {
                chat.Dock = DockStyle.Right;
                chat.BackColor = Color.FromArgb(210, 254, 214);
            }
            else
            {
                chat.Dock = DockStyle.Left;
                chat.BackColor = Color.White;
            }
        }

    }
}
