namespace API.Extensions
{
   public static class APIBaseExtension
   {
      public static IServiceCollection AddConfigurationAPI(this IServiceCollection services)
      {
         services.Configure<RouteOptions>(config =>
         {
            config.LowercaseUrls = true;
            config.LowercaseQueryStrings = true;
         });
         return services;
      }
   }
}