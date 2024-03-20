using Microsoft.Extensions.DependencyInjection;
namespace Repositories
{
   public static class RepositoryExtensions
   {
      public static IServiceCollection AddRepositories(this IServiceCollection services)
      {
         services.AddScoped<IPeopleRepository, PeopleRepository>();
         return services;
      }
   }
}
