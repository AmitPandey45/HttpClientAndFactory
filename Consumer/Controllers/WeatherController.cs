using Api.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public static readonly HttpClient httpClient;

        static WeatherController()
        {
            httpClient = new HttpClient();
        }

        public WeatherController()
        {

        }

        [HttpGet]
        [Route("{cityName}")]
        public async Task<string> GetWeatherDetail(string cityName)
        {
            string url = $"http://api.weatherapi.com/v1/current.json?key=00140c27b738416a80393748230608&q={cityName}&aqi=yes";

            using (var client = new HttpClient())
            {
                //var response = await client.GetAsync(url);
                //response.Content.ReadAsStringAsync();

                return await client.GetStringAsync(url);
            }
        }

        [HttpGet]
        [Route("SingleClient/{cityName}")]
        public async Task<string> SingleHttpClient(string cityName)
        {
            string url = $"http://api.weatherapi.com/v1/current.json?key=00140c27b738416a80393748230608&q={cityName}&aqi=yes";

            return await httpClient.GetStringAsync(url);
        }

        [HttpGet]
        [Route("TypedClient/{cityName}")]
        public async Task<string> TypedClient([FromServices] ApiClient client, string cityName)
        {
            string url = $"?key=00140c27b738416a80393748230608&q={cityName}&aqi=yes";

            return await client.GetStringAsync(url);
        }
    }
}
