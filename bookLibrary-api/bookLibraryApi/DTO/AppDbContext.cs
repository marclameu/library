using bookLibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreExample
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}