using GateWay.Models;
using Microsoft.AspNetCore.Mvc;

namespace GateWay.Controllers
{
    [ApiController]
    [Route("api/address")]

    public class AddressController : Controller
    {

        
      
       [HttpGet(Name = "CheckAdd")]
        public async Task<string> CheckAdd(string CityName,string StreetName)
        {
            try
            {
                var address = new AddressModel();
                bool exist = await address.Check(CityName, StreetName);
                if(exist)
                {
                    return "City exist";
                }
                else
                {
                    return "Not exsit";
                }
            }
            catch (Exception)
            {
                return "ERROR";
            }
        }
    }
}
