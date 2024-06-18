using ChatApplication.Managers;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApplication.Models
{
    public class MessageModel
    {
        public String Id { get; set; }
        public string FromIP { get; set; }
        public string ReceiverIP { get; set; }
        public string Msg { get; set; }
        public DateTime Time { get; set; }

        [NotMapped]
        public MessageType type { get; set; }

        public bool Seen { get; set; }
        public bool Starred { get; set; } = false;
        public static bool ClickedInfo = false;

        public event EventHandler IsSended;
        public event EventHandler IsReaded;

        [JsonConstructor]
        public MessageModel(string FromIP, string ReceiverIP, String Msg, DateTime Time, MessageType type)
        {
            Id = UniqueIdGenerator();
            this.FromIP = FromIP;
            this.ReceiverIP = ReceiverIP;
            this.Msg = Msg;
            this.Time = Time;
            this.type = type;
        }


        public MessageModel()
        {

        }
        public MessageModel(MessageModel m)
        {
            Id = m.Id;
            FromIP = m.FromIP;
            ReceiverIP = m.ReceiverIP;
            Msg = m.Msg;
            Time = m.Time;
            type = m.type;
            Seen = m.Seen;
            Starred = m.Starred;
        }

        public void IsSendedInvoker()
        {
            IsSended?.Invoke(this, EventArgs.Empty);
        }

        public void IsReadedInvoker()
        {
            Seen = true;
            MessageModel m = ChatApplicationNetworkManager.ReadMessage(Id);
            m.Seen = true;
            ChatApplicationNetworkManager.UpdateMessage(m);
            IsReaded?.Invoke(this, EventArgs.Empty);
        }

        private string UniqueIdGenerator()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 99999);
            return $"{FromIP},{ReceiverIP},{DateTime.Now.Ticks},{randomNumber}";
        }
    }

    public enum MessageType
    {
        Message, Response, File, ProfileUpdated
    }
}
