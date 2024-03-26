using Pokemon.Core.Interfaces.IRepositories;
using Pokemon.Core.Interfaces.IServices;
using Pokemon.Core.Services;
using Pokemon.Infrastructure.Repositories;

namespace Pokemon.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<ITypeService, TypeService>();

            #endregion

            #region Repositories
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();

            #endregion

            return services;
        }
    }
}