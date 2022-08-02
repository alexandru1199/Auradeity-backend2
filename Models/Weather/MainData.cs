namespace Models.Weather
{
    public class MainData
    {
        /// <summary>
        /// Gets or sets the Temp.
        /// </summary>
        public double Temp { get; set; }

        /// <summary>
        /// Gets or sets the Feels_Like.
        /// </summary>
        public double Feels_Like { get; set; }

        /// <summary>
        /// Gets or sets the Temp_Min.
        /// </summary>
        public double Temp_Min { get; set; }

        /// <summary>
        /// Gets or sets the Temp_Max.
        /// </summary>
        public double Temp_Max { get; set; }

        /// <summary>
        /// Gets or sets the Pressure.
        /// </summary>
        public int Pressure { get; set; }

        /// <summary>
        /// Gets or sets the Humidity.
        /// </summary>
        public int Humidity { get; set; }
    }
}
