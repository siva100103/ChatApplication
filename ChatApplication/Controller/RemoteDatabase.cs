using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3;

namespace ChatApplication.Controller
{
    public class RemoteDatabase:DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=192.168.3.52;Port=3306;Database=chatApplicationServer;Uid=root;Pwd=Suriya@123;");
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
