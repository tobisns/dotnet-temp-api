using System.Threading.Tasks;
using Pokemon.Core.Entities.General;

namespace Pokemon.Core.Interfaces.IServices
{
    public interface IWeatherService
    {
        Task<WeatherForecast[]> GetWeatherForecast();
    }
}