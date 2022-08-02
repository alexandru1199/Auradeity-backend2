namespace Models.Weather
{
    public class Weather
    {
        // <summary>
        /// Gets or sets the Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the Cod.
        /// </summary>
        public string Cod { get; set; }

        /// <summary>
        /// Gets or sets the Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the List.
        /// </summary>
        public List<WeatherDetails> List { get; set; }
    }
}
