using System;
using System.Collections.Generic; 
using System.Collections.ObjectModel; 

namespace SyrianPound
{
	public class MainPageViewModel
	{
		
		public MainPageViewModel ()
		{
			_title = "Currency Exchange"; 
			MockRateVm ();
			CalculatorVm = new CalculatorViewModel (); 

		}

		private string _title; 
		public string Title 
		{
			get { return _title; }  
		}


		public RatesViewModel ExchangeRateViewModel { get; private set; } 
		public CalculatorViewModel CalculatorVm { get; private set; } 

		private void MockRateVm()
		{
			ExchangeRateViewModel = new RatesViewModel (ExchangeRateService.GetExchangeRates()){ LastUpdate = DateTime.Now }; 

		}

		private void MockCalculatorVm()
		{
			
		}
				
	}		
}

