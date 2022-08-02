namespace Models.Weather
{
    /// <summary>
    /// Responsible to holds only the interested properties for client.
    /// </summary>
    public class WeatherResponse
    {
        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Temperature.
        /// </summary>
        public double? Temperature { get; set; }
    }
}
