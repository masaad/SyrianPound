using System;
using System.Collections.Generic; 
using System.Collections.ObjectModel; 

namespace SyrianPound
{
	public class MainPageViewModel
	{
		
		public MainPageViewModel ()
		{
			_title = "Syrian Pound Exchange Exchange Rate"; 
			MockRateVm ();
			CalculatorVm = new CalculatorViewModel (); 

		}

		private string _title; 
		public string Title 
		{
			get { return _title; }  
		}


		public RatesHostViewModel ExchangeRateViewModel { get; private set; } 
		public CalculatorViewModel CalculatorVm { get; private set; } 

		private void MockRateVm()
		{
		   var result = ExchangeRateService.GetExchangeRatesFromWebApi();
			ExchangeRateViewModel = new RatesHostViewModel (result.Result){ LastUpdate = DateTime.Now }; 

		}

		private void MockCalculatorVm()
		{
			
		}
				
	}		
}

