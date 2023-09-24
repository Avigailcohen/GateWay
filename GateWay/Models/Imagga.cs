using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GateWay.Models
{


    using System;
    using RestSharp;

    namespace ImaggaAPISample
    {
        public class ImaggaSampleClass
        {
            public string ImaggaPic(string url)
            {
                try
                {
                    string apiKey = "acc_3d60a751e375dec";
                    string apiSecret = "ab6de5aa8915be606ddc95f89971361c";

                    string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

                    var client = new RestClient("https://api.imagga.com/v2/tags");
                    //client.Timeout = -1;

                    var request = new RestRequest();
                    request.AddParameter("image_url", url); // שימוש בפרמטר url הנתקבל
                    request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

                    RestResponse response = client.Execute(request);

                    if (IsValidJson(response.Content))
                    {
                        // בדיקות נוספות והחזרת התוצאה המתאימה
                        // ...

                        return "תוצאה מתאימה";
                    }
                    else
                    {
                        return "התשובה אינה JSON חוקי.";
                    }
                }
                catch (Exception ex)
                {
                    return $"שגיאה: {ex.Message}";
                }
            }

            private bool IsValidJson(string? content)
            {
                throw new NotImplementedException();
            }
        }
    }
    public class Result
    {
        public Tag[] tags { get; set; }
    }

    public class Tag
    {
        public string tag { get; set; }
        public double confidence { get; set; }
    }

    public class CheckImageForIceCream
    {
        public Result result { get; set; }
    }
}