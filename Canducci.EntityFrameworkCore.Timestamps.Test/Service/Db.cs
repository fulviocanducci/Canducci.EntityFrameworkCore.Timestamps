using Canducci.EntityFrameworkCore.Timestamps.Test.Models;
using Microsoft.EntityFrameworkCore;
using Canducci.EntityFrameworkCore.Timestamps.Extensions;
namespace Canducci.EntityFrameworkCore.Timestamps.Test.Service
{
    public class Db : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DatabaseInMemory");
            optionsBuilder.AddInterceptorTimestamps();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(config =>
            {
                config.HasKey(x => x.Id);
                config.Property(x => x.Id);
                config.Property(x => x.Name);
                config.Property(x => x.CreatedAt);
                config.Property(x => x.UpdatedAt);
            });
        }
    }
}
