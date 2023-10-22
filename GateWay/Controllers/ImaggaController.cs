using GateWay.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace GateWay.Controllers
{
    [ApiController]
    [Route("api/imagga")]

    public class ImaggaController : ControllerBase
    {
        [HttpGet]
        public IActionResult CheckForIceCream(string imageUrl)
        {
            ImaggaSampleClass imaggaSample = new ImaggaSampleClass();

            
            List<string> tags = imaggaSample.CheckImage(imageUrl);
            //Console.WriteLine("All tags received from Imagga: " + string.Join(", ", tags));

            
            bool containsIceCream = tags.Any(tag => tag.Equals("ice cream", StringComparison.OrdinalIgnoreCase));

            return Ok(containsIceCream);
        }
    }
}
