using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SyrianPound
{
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();
			var vm = new MainPageViewModel (); 
			Title = vm.Title; 
			Children.Add (new RatesContentPage (){BindingContext = vm.ExchangeRateViewModel}); 
			Children.Add (new CalculatorContentPage () {BindingContext = vm.CalculatorVm} );           

		}
	}
}

