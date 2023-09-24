using Microsoft.AspNetCore.Mvc;
using GateWay.Models.ImaggaAPISample;

namespace GateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImaggaController : ControllerBase
    {
        private readonly ImaggaSampleClass _imaggaSample;

        public ImaggaController(ImaggaSampleClass imaggaSample)
        {
            _imaggaSample = imaggaSample;
        }

        [HttpGet]
        public ActionResult<string> CheckImageForIceCream(string imageUrl)
        {
            string result = _imaggaSample.ImaggaPic(imageUrl);

            return result;
        }
    }
}
