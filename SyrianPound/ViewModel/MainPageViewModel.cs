using System.Collections.Generic;
using System.Diagnostics;
using SyrianPound.Service;
using Xamarin.Forms;

namespace SyrianPound
{
	public class MainPageViewModel
	{
		
		public MainPageViewModel ()
		{
            Title = "Syrian Pound Exchange Exchange Rate"; 
			InitializeRateViewModel ();
			CalculatorVm = new CalculatorViewModel ();            
		}
		
        public string Title { get; private set; }


		public RatesHostViewModel ExchangeRateViewModel { get; private set; } 
		public CalculatorViewModel CalculatorVm { get; private set; } 

		private void InitializeRateViewModel()
		{
		   
		    var rates = LocalDatabaseService.GetRates(); 
		    rates.ContinueWith(x =>
		    {
                Debug.WriteLine("MessaginCenter: about to send (GetLocal)");
                MessagingCenter.Send<MainPageViewModel, IEnumerable<Rate>>(this, "GetLocal", x.Result); 
		    }); 		               		    
		   
            ExchangeRateViewModel = new RatesHostViewModel(); 
		}
	   
				
	}		
}

