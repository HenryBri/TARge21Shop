
using System.Text.Json.Serialization;

namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class OpenWeatherRootDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weather")]
        public List<Weathers> Weather { get; set; }

        [JsonPropertyName("main")]
        public Mains Main { get; set; }
        public Syss Sys { get; set; }

        public class Mains
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("feels_like")]
            public double Feels_like { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }
        }

        public class Weathers
        {
            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }
        }

        public class Syss
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("sunrise")]
            public int Sunrise { get; set; }

            [JsonPropertyName("sunset")]
            public int Sunset { get; set; }
        }
    }
}
