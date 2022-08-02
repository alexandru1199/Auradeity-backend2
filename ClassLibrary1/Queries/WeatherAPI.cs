using Interfaces.Queries;
using Models.Weather;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Logic.Queries
{
    public class WeatherAPI : IWeatherAPI
    {
        private const string OpenWeatherBaseApiUrl = "http://api.openweathermap.org/data/2.5/find?q=";
        private const string OpenWeatherApiUrlSettings = "&units=metric&appid=a3436f5ff8cf99795339640c85d3b6d3";

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherAPI"/> class.
        /// </summary>
        public WeatherAPI()
        {
            SetupHttpClientSettingsCall();
        }

        private HttpClient HttpClient { get; set; } = new HttpClient();

        /// <summary>
        /// Get the weather data by using the OpenWeather API
        /// based only on location for the sake of example.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns>Returns the WeatherDto object.</returns>
        public async Task<Weather> GetWeatherDataByCity(string location)
        {
            string openWeatherApiUrl = GetOpenWeatherApiUrl(location);

            try
            {
                var cityWeather = new Weather { };
                using (HttpResponseMessage httpResponse = await this.HttpClient.GetAsync(openWeatherApiUrl))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        cityWeather = JsonConvert.DeserializeObject<Weather>(await httpResponse.Content.ReadAsStringAsync());
                    }
                }

                return cityWeather;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.HttpClient.Dispose();
            }
        }

        /// <summary>
        /// Setup the necessary  settings for our HttpClient
        /// used for interacting with the OpenWeather API.
        /// </summary>
        private void SetupHttpClientSettingsCall()
        {
            this.HttpClient.DefaultRequestHeaders.Accept.Clear();
            this.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Construct the full API path.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns>Returns the path for the API call.</returns>
        private static string GetOpenWeatherApiUrl(string location)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(OpenWeatherBaseApiUrl);
            stringBuilder.Append(location?.Trim());
            stringBuilder.Append(OpenWeatherApiUrlSettings);

            return stringBuilder.ToString();
        }
    }

}
