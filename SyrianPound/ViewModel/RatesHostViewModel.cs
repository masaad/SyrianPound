using System;
using System.ComponentModel; 
using System.Collections.ObjectModel; 
using System.Collections.Generic; 
using System.Linq; 
using Xamarin.Forms; 

namespace SyrianPound
{
	public class RatesHostViewModel : ViewModelBase, ITabContentViewModel 
	{
		

		public RatesHostViewModel (IEnumerable<IRate> model)
		{
			TabName = AppResources.TabNameRates; 
			var Model = ExchangeRateService.GetExchangeRates(); 

			SellingDollarRate = Model.First (x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Selling); 
			BuyingDollarRate = Model.First (x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Buying); 
			SellingEuroRate = Model.First (x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Selling);
			BuyingEuroRate = Model.First (x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Buying); 


		}

		public IEnumerable<IRate> Model { get; private set; } 

		public string TabName { get; private set; } 

		public IRate SellingDollarRate { get; private set; } 

		public IRate BuyingDollarRate { get; private set; } 

		public IRate SellingEuroRate { get; private set; } 

		public IRate BuyingEuroRate { get; private set; } 
				
		public DateTime LastUpdate { get; set; } 


	}
}

