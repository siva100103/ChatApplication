using DatabaseLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3;

namespace ChatApplication.Controller
{
    public class ServerDatabase : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public static DatabaseManager ServerManager = new MySqlHandler();

        //public bool ServerInitialize()
        //{
        //    ServerManager.Database = "chatApplicationServer";
        //    ServerManager.HostName = "192.168.3.52";
        //    ServerManager.UserName = "root";
        //    ServerManager.Password = "Suriya@123";

        //    var ConnectionStatus = ServerManager.Connect();
        //    if (ConnectionStatus)
        //    {
        //        var data = ServerManager.FetchColumn("Clients", "IP", "").Value;
        //        string locaIp = Program.GetLocalIPAddress();
        //        foreach (var ip in data)
        //        {
        //            if(ip.ToString().Equals(locaIp))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    return false;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=192.168.3.52;Port=3306;Database=chatApplicationServer;Uid=root;Pwd=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(c => c.IP);

            modelBuilder.Entity<Client>().Ignore(c => c.IsConnected);
            modelBuilder.Entity<Client>().Ignore(c => c.MessagePage);
            modelBuilder.Entity<Client>().Ignore(c => c.ProfilePicture);
            base.OnModelCreating(modelBuilder);
        }
    }
}
