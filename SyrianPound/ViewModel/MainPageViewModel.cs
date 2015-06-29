using System.Collections.Generic;
using System.Diagnostics;
using SyrianPound.Resources;
using SyrianPound.Service;
using Xamarin.Forms;

namespace SyrianPound
{
	public class MainPageViewModel
	{
		
		public MainPageViewModel ()
		{  
            Title = AppResources.Title; 
			InitializeRateViewModel ();
			CalculatorVm = new CalculatorViewModel ();            
		}
		
        public string Title { get; private set; }


		public RatesHostViewModel ExchangeRateViewModel { get; private set; } 
		public CalculatorViewModel CalculatorVm { get; private set; } 

		private void InitializeRateViewModel()
		{
			ExchangeRateViewModel = new RatesHostViewModel { IsBusy = true }; 
			CalculatorVm = new CalculatorViewModel();

            var rates = LocalDatabaseService.GetRates();
            rates.ContinueWith(x =>
            {
                Debug.WriteLine("MessaginCenter: about to send (GetLocal)");
                MessagingCenter.Send<MainPageViewModel, IEnumerable<Rate>>(this, "GetLocal", x.Result);
            });
		    
		}
	   
				
	}		
}

