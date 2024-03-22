using System.Threading.Tasks;
using Pokemon.Core.Entities.General;
using Pokemon.Core.Interfaces.IServices;


namespace Pokemon.Core.Services
{
    
    public class WeatherService : IWeatherService
    {
        private readonly string[] summaries = new []{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public async Task<WeatherForecast[]> GetWeatherForecast() {
            //this supposed to be API/DB calls
            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        }
    }
}