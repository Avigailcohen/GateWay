using GateWay.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using static GateWay.Models.Address;

namespace GateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "8ebbf8f7a6f33f4101e4f89297cafc9f";
        private readonly string _weatherApiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherController()
        {
            _httpClient = new HttpClient();
        }


        [HttpGet(Name = "GetCurrentWeather")]
        public async Task<IActionResult> GetCurrentWeather(string cityNmae)//et the current weather by the given coordinates
        {

            try
            {
                string apiUrl = $"{_weatherApiUrl}?q={cityNmae}&appid={_apiKey}";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonConvert.DeserializeObject<Weather>(content);

                    return Ok(new { FeelsLike=weatherResponse.Main.FeelsLike, Humidity =weatherResponse.Main.Humidity, City =cityNmae});
                }

				else
				{
					// Return an error response.
					return StatusCode((int)response.StatusCode);
				}
			}
			catch (Exception ex)
			{
				// Return an error response.
				return BadRequest(ex.Message);
			}

		}
    }
}
