using DataAccess.Mappings;
using Microsoft.EntityFrameworkCore;
using Models;
namespace DataAccess
{
   public class DatabaseContext : DbContext
   {
      public DatabaseContext(DbContextOptions options) : base(options) { }

      public DbSet<People> Peoples { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(PeopleMapping.Default);
      }
   }
}
