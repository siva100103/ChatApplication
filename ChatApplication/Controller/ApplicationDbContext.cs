using Microsoft.EntityFrameworkCore;
using WindowsFormsApp3;

namespace ChatApplication
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Message> Messages { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=chatApplication;Uid=root;Pwd=12345;");
            base.OnConfiguring(optionsBuilder);
        }   
    }
}
