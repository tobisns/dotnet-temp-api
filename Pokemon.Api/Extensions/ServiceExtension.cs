using Pokemon.Core.Interfaces.IServices;
using Pokemon.Core.Services;

namespace Pokemon.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IWeatherService, WeatherService>();

            #endregion

            return services;
        }
    }
}