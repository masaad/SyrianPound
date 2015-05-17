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
			rate.CurrencyInfo.Name = "Dollar"; 
			rate.CurrencyInfo.Country = "U.S.A"; 
			rate.CurrencyInfo.Symbol = "$"; 
			rate.ExchangePrice = 250.00; 

			var rate1 = new Rate (Guid.NewGuid ()); 
			rate1.CurrencyInfo = new Currency (Guid.NewGuid ()); 
			rate1.CurrencyInfo.Name = "Euro"; 
			rate1.CurrencyInfo.Country = "European Union"; 
			rate1.CurrencyInfo.Symbol = "€"; 
			rate1.ExchangePrice = 250.00; 	

			var results = new List<IRate> (); 
			results.Add (rate); 
			results.Add (rate1); 
			return results; 
		}
	}
}

