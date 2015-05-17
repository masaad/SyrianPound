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
		private string _tabName; 
		private IRate _dollorRate;
		private IRate _euroRate; 

		public RatesHostViewModel (IEnumerable<IRate> model)
		{
			_tabName = "Rates";  //AppResources.TabRates;
			var Model = ExchangeRateService.GetExchangeRates(); 

			_dollorRate = Model.First (x => x.CurrencyInfo.Symbol == "$"); 
			_euroRate = Model.First (x => x.CurrencyInfo.Symbol == "€"); 


		}

		public IEnumerable<IRate> Model { get; private set; } 

		public string TabName 
		{ 
			get { return _tabName; } 
		} 

		public IRate DollarRate 
		{
			get { return _dollorRate; } 
		}

		public IRate EuroRate 
		{
			get { return _euroRate; } 
		}
				
		public DateTime LastUpdate { get; set; } 


	}
}

