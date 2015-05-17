using System;
using System.ComponentModel; 
using System.Collections.ObjectModel; 
using System.Collections.Generic; 
using System.Linq; 
using Xamarin.Forms; 

namespace SyrianPound
{
	public class RatesViewModel : ViewModelBase, ITabContentViewModel 
	{
		private string _tabName; 
		private IRate _centralBankRates;
		private IRate _blackMarketRates; 

		public RatesViewModel (IEnumerable<IRate> model)
		{
			_tabName = "Rates";  //AppResources.TabRates;
			var Model = ExchangeRateService.GetExchangeRates(); 

			_centralBankRates = Model.First (x => x.Market.Name == "Central Bank"); 
			_blackMarketRates = Model.First (x => x.Market.Name == "Black Market"); 


		}

		public IEnumerable<IRate> Model { get; private set; } 

		public string TabName 
		{ 
			get { return _tabName; } 
		} 

		public string CentralBankMarketName 
		{
			get { return _centralBankRates.Market.Name; }
		}

		public double CentralBankExchangePrice
		{
			get { return _centralBankRates.ExchangePrice;  }
		}

		public DateTime LastUpdate { get; set; } 


	}
}

