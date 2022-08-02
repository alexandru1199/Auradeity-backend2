namespace Models.Weather
{
    public class WeatherDetails
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Coord.
        /// </summary>
        public Coordinates Coord { get; set; }

        /// <summary>
        /// Gets or sets the Main.
        /// </summary>
        public MainData Main { get; set; }

        /// <summary>
        /// Gets or sets the Dt.
        /// </summary>
        public int Dt { get; set; }

        /// <summary>
        /// Gets or sets the Wind.
        /// </summary>
        public Wind Wind { get; set; }

        /// <summary>
        /// Gets or sets the Sys.
        /// </summary>
        public CountryInfo Sys { get; set; }

        /// <summary>
        /// Gets or sets the Clouds.
        /// </summary>
        public Clouds Clouds { get; set; }

        /// <summary>
        /// Gets or sets the Weather.
        /// </summary>
        public List<WeatherDescription> Weather { get; set; }
    }
}
