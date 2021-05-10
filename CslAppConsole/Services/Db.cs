using Canducci.EntityFrameworkCore.Timestamps.Extensions;
using CslAppConsole.Models;
using Microsoft.EntityFrameworkCore;
namespace CslAppConsole.Services
{
    public class Db : DbContext
    {
        public Db()
        {
        }
        public DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = db.sqlite")
                .AddInterceptorITimestamps();

        }
    }
}
