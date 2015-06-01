using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;

namespace SyrianPound.iOS
{
    public class RatesService : DelegatingHandler
    {
        public static RatesService Instance = new RatesService();

        private RatesService()
        {
            CurrentPlatform.Init();                      
        }

        public IEnumerable<Rate> ActiveRates { get; private set; }


        private static MobileServiceClient MobileService = new MobileServiceClient("https://syrianpound.azure-mobile.net/",
                                                       "SnSEtadGgkyNfUCgtYpLeAQNLadQqP28");

        public async Task<IEnumerable<Rate>> GetExchangeRatesFromWebApi()
        {
            return await MobileService.InvokeApiAsync<IEnumerable<Rate>>("Rates", HttpMethod.Get, null);

            //var rates = MobileService.GetTable<Rate>();
            //return await rates.ToEnumerableAsync();
        }

        public async Task<IEnumerable<Rate>> GetActiveRates()
        {
            try
            {
                  var sharedService = ExchangeRateService.Create(this);
                ActiveRates = await sharedService.GetExchangeRatesFromWebApi(); 
            }
            catch (MobileServiceInvalidOperationException e)
            {

                Console.Error.WriteLine(@"ERROR {0}", e.Message);
                return null;
            }

            return ActiveRates; 
        }
    }
}