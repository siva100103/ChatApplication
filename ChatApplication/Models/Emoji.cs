using System.Collections.Generic;
using System.Reflection;

namespace System.Text
{
    public static class Emojis
    {
        public static List<string> EmojiList = new List<string>();

        public static void AddToList()
        {

            Type emojiType = typeof(Emojis);
            FieldInfo[] fields = emojiType.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                if (field.Name == "EmojiList")
                    continue;
                string emojiName = field.Name;
                string emojiValue = (string)field.GetValue(null);
                EmojiList.Add(emojiValue);
            }
        }

        public const string GrinningFace = "😀";
        public const string GrinningFaceWithSmilingEyes = "😄";
        public const string BeamingFaceWithSmilingEyes = "😁";
        public const string GrinningSquintingFace = "😆";
        public const string GrinningFaceWithSweat = "😅";
        public const string RollingOnTheFloorLaughing = "🤣";
        public const string FaceWithTearsOfJoy = "😂";
        public const string SlightlySmilingFace = "🙂";
        public const string UpsideDownFace = "🙃";
        public const string WinkingFace = "😉";
        public const string SmilingFaceWithHalo = "😇";
        public const string SmilingFaceWithHearts = "🥰";
        public const string SmilingFaceWithHeartEyes = "😍";
        public const string StarStruck = "🤩";
        public const string FaceBlowingAKiss = "😘";
        public const string FaceSavoringFood = "😋";
        public const string FaceWithTongue = "😛";
        public const string WinkingFaceWithTongue = "😜";
        public const string MoneyMouthFace = "🤑";
        public const string SmilingFaceWithOpenHands = "🤗";
        public const string FaceWithHandOverMouth = "🤭";
        public const string ShushingFace = "🤫";
        public const string ThinkingFace = "🤔";
        public const string ZipperMouthFace = "🤐";
        public const string FaceWithRaisedEyebrow = "🤨";
        public const string NeutralFace = "😐";
        public const string ExpressionlessFace = "😑";
        public const string FaceWithoutMouth = "😶";
        public const string SmirkingFace = "😏";
        public const string UnamusedFace = "😒";
        public const string FaceWithRollingEyes = "🙄";
        public const string GrimacingFace = "😬";
        public const string SleepyFace = "😪";
        public const string DroolingFace = "🤤";
        public const string SleepingFace = "😴";
        public const string FaceWithMedicalMask = "😷";
        public const string FaceWithThermometer = "🤒";
        public const string FaceWithHeadBandage = "🤕";
        public const string NauseatedFace = "🤢";
        public const string FaceVomiting = "🤮";
        public const string SneezingFace = "🤧";
        public const string HotFace = "🥵";
        public const string WoozyFace = "🥴";
        public const string FaceWithCrossedOutEyes = "😵";
        public const string ExplodingHead = "🤯";
        public const string PartyingFace = "🥳";
        public const string SmilingFaceWithSunglasses = "😎";
        public const string NerdFace = "🤓";
        public const string FaceWithMonocle = "🧐";
        public const string ConfusedFace = "😕";
        public const string WorriedFace = "😟";
        public const string SlightlyFrowningFace = "🙁";
        public const string SadButRelievedFace = "😥";
        public const string LoudlyCryingFace = "😭";
        public const string FaceScreamingInFear = "😱";
        public const string PerseveringFace = "😣";
        public const string YawningFace = "🥱";
        public const string FaceWithSteamFromNose = "😤";
        public const string FaceWithSymbolsOnMouth = "🤬";
        public const string SmilingFaceWithHorns = "😈";
        public const string AngryFaceWithHorns = "👿";
        public const string Skull = "💀";
        public const string PileOfPoo = "💩";
        public const string ClownFace = "🤡";
        public const string GrinningCatWithSmilingEyes = "😸";
        public const string SmilingCatWithHeartEyes = "😻";
        public const string WearyCat = "🙀";
        public const string SeeNoEvilMonkey = "🙈";
        public const string HearNoEvilMonkey = "🙉";
        public const string SpeakNoEvilMonkey = "🙊";
        public const string BrokenHeart = "💔";
        public const string RedHeart = "❤️";
        public const string HundredPoints = "💯";
        public const string Collision = "💥";
        public const string SweatDroplets = "💦";
        public const string WavingHand = "👋";
        public const string HandWithFingersSplayed = "🖐️";
        public const string OKHand = "👌";
        public const string VictoryHand = "✌️";
        public const string CrossedFingers = "🤞";
        public const string LoveYouGesture = "🤟";
        public const string SignOfTheHorns = "🤘";
        public const string ThumbsUp = "👍";
        public const string ThumbsDown = "👎";
        public const string OncomingFist = "👊";
        public const string LeftFacingFist = "🤛";
        public const string RightFacingFist = "🤜";
        public const string ClappingHands = "👏";
        public const string PalmsUpTogether = "🤲";
        public const string Handshake = "🤝";
        public const string FoldedHands = "🙏";
        public const string FlexedBiceps = "💪";
        public const string Man_CurlyHair = "👨‍🦱";
        public const string Woman = "👩";
        public const string PersonFrowning = "🙍";
        public const string PersonGesturingNO = "🙅";
        public const string MenHoldingHands = "👬";
        public const string MonkeyFace = "🐵";
        public const string PigFace = "🐷";
        public const string PigNose = "🐽";
        public const string Goat = "🐐";
        public const string Bat = "🦇";
        public const string Sparkles = "✨";
    }
}
