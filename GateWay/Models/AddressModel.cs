using Newtonsoft.Json;
using System.Linq.Expressions;
using static GateWay.Models.Address;

namespace GateWay.Models
{
    public class AddressModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://data.gov.il/api/3/action/datastore_search?resource_id=bf185c7f-1a4e-4662-88c5-fa118a244bda&limit=145515";
        public AddressModel()
        {
            _httpClient = new HttpClient();
        }
        public async Task<bool> Check(string CityName,string StreetName)
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<AddressRoot>(content);
                    if(root?.result?.records!=null)
                    {
                        return root.result.records.Any(record=>record.city_name.TrimStart().TrimEnd()==CityName.TrimStart().TrimEnd()
                        && record.street_name.TrimStart().TrimEnd()==StreetName.TrimStart().TrimEnd());
                    }
                }
                return false;

               
            }
            catch (Exception ex)
            {
                // טיפול בשגיאה
                return false;
            }
        }
        
    }
}
