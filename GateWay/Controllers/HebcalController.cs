using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using static GateWay.Models.hebcal;

namespace GateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HebcalController : Controller
    {
        private readonly HttpClient _httpClient;
        //private readonly HttpClient _httpClient;
        public HebcalController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> GetDate()
        {
            try
            {
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                string hebcalData = $"https://www.hebcal.com/converter?cfg=json&date={date}%7D&g2h=1&strict=1";
                var response = await _httpClient.GetAsync(hebcalData);
                if(response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var dateHeb = JsonConvert.DeserializeObject<HebcalRoot>(json);
                    return Ok(dateHeb);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
