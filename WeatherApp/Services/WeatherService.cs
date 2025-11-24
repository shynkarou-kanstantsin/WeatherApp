using System.Net.Http;
using System.Text.Json;
using WeatherApp.Model;

namespace WeatherApp.Services
{
    internal class WeatherService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiKey = "Insert_Your_API_Key_Here";

        public async Task<CityWeather> GetWeatherAsync(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
            
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            var root = doc.RootElement;
            var main = root.GetProperty("main");
            var weather = root.GetProperty("weather")[0];

            return new CityWeather
            {
                CityName = root.GetProperty("name").GetString(),
                Temperature = main.GetProperty("temp").GetDouble().ToString(),
                Condition = weather.GetProperty("description").GetString()
            };
        }
    
    }
}
