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
		

		public RatesHostViewModel (IEnumerable<Rate> model)
		{
			TabName = AppResources.TabNameRates;
            Model = model.ToList();

			SellingDollarRate = Model.First (x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Selling); 
			BuyingDollarRate = Model.First (x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Buying); 
			SellingEuroRate = Model.First (x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Selling);
			BuyingEuroRate = Model.First (x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Buying); 


		}

		public IEnumerable<Rate> Model { get; private set; } 

		public string TabName { get; private set; } 

		public Rate SellingDollarRate { get; private set; } 

		public Rate BuyingDollarRate { get; private set; } 

		public Rate SellingEuroRate { get; private set; } 

		public Rate BuyingEuroRate { get; private set; } 
				
		public DateTime LastUpdate { get; set; } 


	}
}

