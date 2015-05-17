using System;
using System.Collections.Generic; 

namespace SyrianPound
{
	public class ExchangeRateService
	{
		public ExchangeRateService ()
		{
		}

		public static IEnumerable<IRate> GetExchangeRates()
		{			
			var rate = new Rate (Guid.NewGuid ()); 
			rate.CurrencyInfo = new Currency (Guid.NewGuid ()); 
			rate.CurrencyInfo.Name = "Syrian Pound"; 
			rate.CurrencyInfo.Country = "Syria"; 
			rate.CurrencyInfo.Symbol = "S.P"; 
			rate.Market = new MarketPlace (Guid.NewGuid ()); 
			rate.Market.Name = "Central Bank"; 
			rate.ExchangePrice = 250.00; 

			var rate1 = new Rate (Guid.NewGuid ()); 
			rate1.CurrencyInfo = new Currency (Guid.NewGuid ()); 
			rate1.CurrencyInfo.Name = "Syrian Pound"; 
			rate1.CurrencyInfo.Country = "Syria"; 
			rate1.CurrencyInfo.Symbol = "S.P"; 
			rate1.Market = new MarketPlace (Guid.NewGuid ()); 
			rate1.Market.Name = "Black Market"; 
			rate1.ExchangePrice = 250.00; 	

			var results = new List<IRate> (); 
			results.Add (rate); 
			results.Add (rate1); 
			return results; 
		}
	}
}

