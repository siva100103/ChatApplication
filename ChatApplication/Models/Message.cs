using ChatApplication.Controller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication
{
    public class Message
    {
        public String Id { get; set; }
        public string FromIP { get; set; }
        public string ReceiverIP { get; set; }
        public string Msg { get; set; }
        public DateTime Time { get; set; }

        [NotMapped]
        public Type type { get; set; }

        public bool Seen { get; set; }
        public static bool ClickedInfo = false;

        public event EventHandler IsSended;
        public event EventHandler IsReaded;

        [JsonConstructor]
        public Message(string FromIP, string ReceiverIP, String Msg, DateTime Time,Type type)
        {
            Id = UniqueIdGenerator();
            this.FromIP = FromIP;
            this.ReceiverIP = ReceiverIP;
            this.Msg = Msg;
            this.Time = Time;
            this.type = type;
        }


        public Message()
        {

        }
        public Message(Message m)
        {
            Id = m.Id;
            FromIP = m.FromIP;
            ReceiverIP = m.ReceiverIP;
            Msg = Msg;
            Time = m.Time;
            type = m.type;
        }

        public void IsSendedInvoker()
        {
            IsSended?.Invoke(this, EventArgs.Empty);
        }

        public void IsReaderInvoker()
        {
            Seen = true;
            var context = new LocalStorage();
            Message m = context.Messages.Find((msg) => msg.Id == Id);
            m.Seen = true;
            context.UpdateMessage(m);
            IsReaded?.Invoke(this, EventArgs.Empty);
        }

        private string UniqueIdGenerator()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 99999);
            return $"{FromIP},{ReceiverIP},{DateTime.Now.Ticks},{randomNumber}";
        }
    }

    public enum Type
    {
        Message, Response, File
    }
}
