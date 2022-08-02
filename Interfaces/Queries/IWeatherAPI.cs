using Models.Weather;

namespace Interfaces.Queries
{
    public interface IWeatherAPI
    {
        Task<Weather> GetWeatherDataByCity(string city);
    }
}
