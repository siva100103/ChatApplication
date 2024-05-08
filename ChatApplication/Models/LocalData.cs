using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

}
