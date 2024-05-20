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
        public static int Current = 0;

        public static Color OuterLayerColor;
        public static Color InnerLayerColor;
        public static Color ContactsColor;
        public static Color ContactBackgroundColor;
        public static Color MessagePageColor;
        public static Color CurrentlySelectedColor;
        public static Color BorderColor;
        public static Color TextColor;
        public static Color SentColor;
        public static Color ReceivedColor;
        public static Color ThemeColor;

        public static Image LeftAlign;
        public static Image StarMessage;
        public static Image ChatIcon;
        public static Image ArchieveIcon;
        public static Image ExitIcon;
        public static Image SearchIcon;

        public static void SetTheme(int theme)
        {
            Current = theme;
            if (theme == 1)
            {
                OuterLayerColor = Color.FromArgb(97, 97, 97);
                InnerLayerColor = Color.FromArgb(97, 97, 97);
                ContactsColor = Color.FromArgb(30, 30, 30);
                ContactBackgroundColor = Color.FromArgb(48, 55, 60);
                MessagePageColor = Color.FromArgb(107, 104, 102);
                BorderColor = Color.FromArgb(211, 137, 242);
                TextColor = Color.WhiteSmoke;
                CurrentlySelectedColor = Color.FromArgb(97, 97, 97);
                SentColor = Color.FromArgb(211, 167, 242);
                ThemeColor = Color.FromArgb(95, 101, 118);
                ReceivedColor = Color.WhiteSmoke;

                LeftAlign = Properties.Resources.icons8_align_left_19;
                StarMessage = Properties.Resources.icons8_star_22White;
                ChatIcon = Properties.Resources.icons8_chat_white_22;
                ExitIcon = Properties.Resources.icons8_macos_close_22_white;
                SearchIcon = Properties.Resources.icons8_search_19_white;
                ArchieveIcon = Properties.Resources.icons8_archive_22_white;
            }
            else if(theme == 0)
            {
                OuterLayerColor = Color.FromArgb(229, 227, 222);
                InnerLayerColor = Color.FromArgb(229, 227, 222);
                ContactsColor = Color.FromArgb(243, 243, 243);
                ContactBackgroundColor = Color.White;
                MessagePageColor = Color.FromArgb(239, 234, 227);
                BorderColor = Color.FromArgb(66, 209, 149);
                TextColor = Color.Black;
                CurrentlySelectedColor = Color.FromArgb(229, 227, 222);
                SentColor = Color.FromArgb(210, 254, 214);
                ThemeColor = Color.FromArgb(249, 249, 249);
                ReceivedColor = Color.White;

                LeftAlign = Properties.Resources.icons8_align_left_19_Black;
                StarMessage = Properties.Resources.icons8_star_22;
                ChatIcon = Properties.Resources.icons8_chat_22;
                ExitIcon = Properties.Resources.icons8_macos_close_22;
                SearchIcon = Properties.Resources.icons8_search_19;
                ArchieveIcon = Properties.Resources.icons8_archive_22;
            }
        }
    }
}
