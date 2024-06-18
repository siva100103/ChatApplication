using System;

namespace ChatApplication.Models
{
    [Serializable]
    public class LocalData
    {
        public string Server { get; set; } = "localhost";
        public string Database { get; set; } = "IpMessagingapp";
        public string Port { get; set; } = "3306";
        public string Uid { get; set; } = "root";
        public string Password { get; set; } = "123";
        public int Theme { get; set; } = 0;
        //public List<string> Archieved = new List<string>();
    }

}
