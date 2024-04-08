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
    public partial class EmojiBox : UserControl
    {
        public event EventHandler<ListViewItem> SelectEmoji;

        public EmojiBox()
        {
            InitializeComponent();
            if (Emojis.EmojiList.Count < 1)
            {
                Emojis.AddToList();
            }
            AddToListView();
        }

        private void AddToListView()
        {
            foreach (string emoji in Emojis.EmojiList)
            {
                listView.Items.Add(emoji);
            }
        }

        private void ListViewMouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                SelectEmoji?.Invoke(this, item);
            }
        }
    }
}
