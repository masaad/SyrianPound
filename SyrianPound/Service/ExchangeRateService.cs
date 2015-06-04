using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SyrianPound.Service;

namespace SyrianPound
{   
	public class ExchangeRateService
	{
        private const string Key = "SnSEtadGgkyNfUCgtYpLeAQNLadQqP28";
        private const string Url = "https://syrianpound.azure-mobile.net/tables/Rates/?$expand=CurrencyInfo,Change";

	    public static async Task<List<Rate>> GetActiveRates()
        {
            var results = new List<Rate>();
            HttpWebRequest request = CreateRequest();
            var responseTask = request.GetResponseAsync();
            using (var response = await responseTask)
            {               
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    results = JsonConvert.DeserializeObject<List<Rate>>(content);

                }
            }           
            return results;
        }

	    public static async Task<IEnumerable<Rate>>  SyncRemoteRates(DateTime? lastUpdate)
	    {	        
            List<Rate> results;
            HttpWebRequest request = CreateRequest();
            var responseTask = request.GetResponseAsync();
            using (var response = await responseTask)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    results = JsonConvert.DeserializeObject<List<Rate>>(content);

                }
            }
         
	        DateTime remoteLastUpdate = (from d in results select d.LastUpdated).Max();
	        if (!lastUpdate.HasValue ||  lastUpdate.Value != remoteLastUpdate)
	        {
	            await LocalDatabaseService.SyncLocalDatabase(results);               
	        }
	        return results; 
	    }

        private static HttpWebRequest CreateRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Credentials = new NetworkCredential("", Key);
            request.ContentType = "application/json";
            request.Method = "GET";
            return request;
        }
		
	}
}

