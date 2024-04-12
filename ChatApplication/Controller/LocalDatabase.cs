using Microsoft.EntityFrameworkCore;
using System.IO;
using WindowsFormsApp3;
using System.Xml.Serialization;

namespace ChatApplication
{
    public class LocalDatabase : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string xmlFilePath = @"data.xml";
            LocalData data;
            XmlSerializer serializer = new XmlSerializer(typeof(LocalData));
            using (TextReader reader = new StreamReader(xmlFilePath))
            {
                data = (LocalData)serializer.Deserialize(reader);
            }

            base.OnConfiguring(optionsBuilder);
            string s = $"server={data.Server};port={data.Port};Database={data.Database};Uid={data.Uid};Pwd={data.Password}";
            optionsBuilder.UseMySQL(s);
        }
    }
}
