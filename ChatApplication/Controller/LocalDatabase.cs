using Microsoft.EntityFrameworkCore;
using WindowsFormsApp3;

namespace ChatApplication
{
    public class LocalDatabase:DbContext
    {
         public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string s = "server=localhost;port=3306;Database=ChatApplication;Uid=root;Pwd=Suriya@123";
            optionsBuilder.UseMySQL(s);
        }
    }
}
