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
			var dollarSellRate = new Rate (Guid.NewGuid ()); 
			dollarSellRate.CurrencyInfo = new Currency (Guid.NewGuid ()); 
			dollarSellRate.CurrencyInfo.Name = "Dollar"; 
			dollarSellRate.CurrencyInfo.Country = "U.S.A"; 
			dollarSellRate.CurrencyInfo.Symbol = "$"; 
			dollarSellRate.ExchangePrice = 257.00; 
			dollarSellRate.Trade = TradeType.Selling;
			dollarSellRate.Change = new RateChange { Amount = 20, Type = ChangeType.Increase }; 


			var dollarBuyRate = new Rate (Guid.NewGuid ()); 
			dollarBuyRate.CurrencyInfo = new Currency (Guid.NewGuid ()); 
			dollarBuyRate.CurrencyInfo.Name = "Dollar"; 
			dollarBuyRate.CurrencyInfo.Country = "U.S.A"; 
			dollarBuyRate.CurrencyInfo.Symbol = "$"; 
			dollarBuyRate.ExchangePrice = 248.00; 
			dollarBuyRate.Trade = TradeType.Buying; 
			dollarBuyRate.Change = new RateChange { Amount = 15, Type = ChangeType.Decrease }; 


			var euroSellRate = new Rate (Guid.NewGuid ()); 
			euroSellRate.CurrencyInfo = new Currency (Guid.NewGuid ()); 
			euroSellRate.CurrencyInfo.Name = "Euro"; 
			euroSellRate.CurrencyInfo.Country = "European Union"; 
			euroSellRate.CurrencyInfo.Symbol = "€"; 
			euroSellRate.ExchangePrice = 267.00;
			euroSellRate.Trade = TradeType.Selling; 
			euroSellRate.Change = new RateChange { Amount = 10, Type = ChangeType.Increase }; 

			var euroBuyRate = new Rate (Guid.NewGuid ()); 
			euroBuyRate.CurrencyInfo = new Currency (Guid.NewGuid ()); 
			euroBuyRate.CurrencyInfo.Name = "Euro"; 
			euroBuyRate.CurrencyInfo.Country = "European Union"; 
			euroBuyRate.CurrencyInfo.Symbol = "€"; 
			euroBuyRate.ExchangePrice = 260.00;
			euroBuyRate.Trade = TradeType.Buying; 
			euroBuyRate.Change = new RateChange { Amount = 15, Type = ChangeType.Increase }; 

			var results = new List<IRate> (); 
			results.Add (dollarBuyRate); 
			results.Add (dollarSellRate); 
			results.Add (euroBuyRate); 
			results.Add (euroSellRate); 
			return results; 
		}
	}
}

