using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Managers
{
    public class ServerDb : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "server=localhost;port=3306;Uid=root;pwd=Suriya@123;database=IpMessagingServer;charset=utf8mb4";
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasKey(clt => clt.IP);
            modelBuilder.Entity<Client>().Ignore(clt=>clt.MessagePage);
            modelBuilder.Entity<Client>().Ignore(clt=>clt.ProfilePicture);
            modelBuilder.Entity<Client>().Ignore(clt=>clt.UnSeenMessagesList);
            modelBuilder.Entity<Client>().Ignore(clt=>clt.UnSeenMessagesList);
            modelBuilder.Entity<Client>().Ignore(clt=>clt.UnSeenMessagesList);

        }
    }

}
