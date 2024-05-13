using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication
{
    public static class ChatTheme
    {
        public static bool Current = false;

        public static Color OuterLayerColor;
        public static Color InnerLayerColor;
        public static Color ContactsColor;
        public static Color ContactBackgroundColor;
        public static Color MessagePageColor;
        public static Color CurrentlySelectedColor;
        public static Color BorderColor;
        public static Color TextColor;

        public static void SetTheme(bool dark)
        {
            Current = dark;
            if (dark)
            {
                OuterLayerColor = Color.FromArgb(97, 97, 97);
                InnerLayerColor = Color.FromArgb(97, 97, 97);
                ContactsColor = Color.FromArgb(30, 30, 30);
                ContactBackgroundColor = Color.FromArgb(48, 55, 78);
                MessagePageColor = Color.FromArgb(107, 104, 102);
                BorderColor = Color.FromArgb(211, 137, 242);
                TextColor = Color.WhiteSmoke;
                CurrentlySelectedColor = Color.FromArgb(97, 97, 97);
            }
            else
            {
                OuterLayerColor = Color.FromArgb(229, 227, 222);
                InnerLayerColor = Color.FromArgb(229, 227, 222);
                ContactsColor = Color.FromArgb(243, 243, 243);
                ContactBackgroundColor = Color.White;
                MessagePageColor = Color.FromArgb(239, 234, 227);
                BorderColor = Color.FromArgb(66, 209, 149);
                TextColor = Color.Black;
                CurrentlySelectedColor = Color.FromArgb(229, 227, 222);
            }
        }
    }
}
