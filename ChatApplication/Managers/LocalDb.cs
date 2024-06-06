using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Managers
{
    public class LocalDb : DbContext
    {
        public DbSet<MessageModel> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            string connectionString = ChatApplicationNetworkManager.ReadLocalConnectionString();
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MessageModel>().HasKey(msg=>msg.Id);
            modelBuilder.Entity<MessageModel>().Ignore(msg=>msg.type);
        }
    }
}
