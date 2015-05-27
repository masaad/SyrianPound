using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace SyrianPound
{
	public class ExchangeRateService
	{
		public ExchangeRateService ()
		{
		}

 public static MobileServiceClient MobileService = new MobileServiceClient(
                                                        "https://syrianpound.azure-mobile.net/",
                                                        "SnSEtadGgkyNfUCgtYpLeAQNLadQqP28");
	       
	    public static async Task<IEnumerable<Rate>> GetExchangeRatesFromWebApi()
	    {
	        var rates = MobileService.GetTable<Rate>();
	        return await rates.ToEnumerableAsync();
	    }

		
	}
}

