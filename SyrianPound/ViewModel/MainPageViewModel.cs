using System;
using System.Collections.Generic; 
using System.Collections.ObjectModel;
using Xamarin.Forms; 

namespace SyrianPound
{
	public class MainPageViewModel
	{
		
		public MainPageViewModel ()
		{
			_title = "Syrian Pound Exchange Exchange Rate"; 
			InitializeRateViewModel ();
			CalculatorVm = new CalculatorViewModel (); 

		}

		private string _title; 
		public string Title 
		{
			get { return _title; }  
		}


		public RatesHostViewModel ExchangeRateViewModel { get; private set; } 
		public CalculatorViewModel CalculatorVm { get; private set; } 

		private void InitializeRateViewModel()
		{
		    var result = ExchangeRateService.GetActiveRates();
		    result.ContinueWith(x =>
		    {
		        MessagingCenter.Send<MainPageViewModel, List<Rate>>(this, "done", result.Result);
		    }); 


			ExchangeRateViewModel = new RatesHostViewModel (); 

		}

		private void MockCalculatorVm()
		{
			
		}
				
	}		
}

