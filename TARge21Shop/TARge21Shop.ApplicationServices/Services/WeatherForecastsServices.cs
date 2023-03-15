using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=7WPeWWbXkV362n6qSV3en2KsXoGqbtw4&metric=true";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = new JavaScriptSerializer().Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;

                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPercipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;

            }

            return dto;
        }

        public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q=Elva&APPID=3c8a501925519f2f834306c27bce8a95";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var openWeather = new JavaScriptSerializer().Deserialize<OpenWeatherRootDto>(json);

                dto.Country = openWeather.Sys.Country;
                dto.Id = openWeather.Sys.Id;
                dto.Name = openWeather.Name;
                dto.Temp = openWeather.Main.Temp;
                dto.Feels_like = openWeather.Main.Feels_like;
                dto.Main = openWeather.Weather[0].Main;
                dto.Description = openWeather.Weather[0].Description;
                dto.Humidity = openWeather.Main.Humidity;
                dto.Pressure = openWeather.Main.Pressure;
                dto.Sunrise = openWeather.Sys.Sunrise;
                dto.Sunset = openWeather.Sys.Sunset;
            }

            return dto;
        }
    }
}
