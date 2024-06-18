using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Managers
{
    public class ServerDb : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = ChatApplicationNetworkManager.ReadServerConnectionString();
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasKey(clt => clt.IP);
            modelBuilder.Entity<Client>().Ignore(clt => clt.MessagePage);
            modelBuilder.Entity<Client>().Ignore(clt => clt.ProfilePicture);
            modelBuilder.Entity<Client>().Ignore(clt => clt.UnSeenMessagesList);
            modelBuilder.Entity<Client>().Ignore(clt => clt.UnSeenMessagesList);
            modelBuilder.Entity<Client>().Ignore(clt => clt.UnSeenMessagesList);

        }
    }

}
