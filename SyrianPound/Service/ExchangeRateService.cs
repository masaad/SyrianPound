
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SyrianPound
{   
	public class ExchangeRateService
	{
        private const string _key = "SnSEtadGgkyNfUCgtYpLeAQNLadQqP28";
        private const string _url = "https://syrianpound.azure-mobile.net/tables/Rates/?$expand=CurrencyInfo,Change"; 

		public ExchangeRateService ()
		{
		}

        public static async Task<List<Rate>> GetActiveRates()
        {
            var results = new List<Rate>();
            HttpWebRequest request = CreateRequest();
            var responseTask = request.GetResponseAsync();
            using (var response = await responseTask)
            {
                //if (response..StatusCode != HttpStatusCode.OK)
                //    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    results = JsonConvert.DeserializeObject<List<Rate>>(content);

                }
            }

           
            return results;
        }

        private static HttpWebRequest CreateRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(_url);
            request.Credentials = new NetworkCredential("", _key);
            request.ContentType = "application/json";
            request.Method = "GET";
            return request;
        }


		
	}
}

