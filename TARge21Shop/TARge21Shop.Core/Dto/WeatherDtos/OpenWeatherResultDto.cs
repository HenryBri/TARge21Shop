namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class OpenWeatherResultDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set;}
    }
}
