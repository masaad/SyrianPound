using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SyrianPound
{
	public partial class RatesContentPage : ContentPage
	{
		public RatesContentPage ()
		{
			InitializeComponent ();

		    MessagingCenter.Subscribe<App, bool>(this, "NoConnection", (model, isDisconnected) =>
		    {
		        if (isDisconnected)
		            DisplayAlert("Internet Connection",
		                "Your rates maybe out of date. Connect to the internet get the current rates.", "OK");

		    }); 
           
		}


	}
}

