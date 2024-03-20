using Microsoft.Extensions.DependencyInjection;
namespace Services
{
   public static class ServicesExtensions
   {
      public static IServiceCollection AddServices(this IServiceCollection services)
      {
         services.AddScoped<IPeopleService, PeopleService>();
         return services;
      }
   }
}
