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

                // קריאה לפונקציה שבודקת אם יש גלידה בתמונה
                List<string> tags = imaggaSample.CheckImage(imageUrl);

                // בדיקה אם "גלידה" נמצאת בתגים
                bool containsIceCream = tags.Contains("ice cream");

                return Ok(new { ContainsIceCream = containsIceCream });
            }
        }
 }





