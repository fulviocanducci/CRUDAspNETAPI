using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccess
{
   public static class DatabaseExtension
   {
      public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfigurationManager configuration)
      {
         services.AddDbContext<DatabaseContext>(config =>
         {
            config.UseSqlServer(configuration.GetConnectionString("Database"));
         });
         services.AddScoped<IUnitOfWork, UnitOfWork>();
         return services;
      }
   }
}
