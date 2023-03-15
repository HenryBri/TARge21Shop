namespace TARge21Shop.Models.Weather
{
    public class OpenWeatherViewModel
    {
        public string Name { get; set; }
        public Weather Weathers { get; set; }
        public Main Mains { get; set; }
        public Sys Syss { get; set; }

        public class Weather
        {
            public string Main { get; set; }
            public string Description { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double Feels_like { get; set; }
            public int Pressure { get; set; }
            public int Humidity { get; set; }
        }

        public class Sys
        {
            public int Id { get; set; }
            public string Country { get; set; }
            public int Sunrise { get; set; }
            public int Sunset { get; set;}
        }
    }
}