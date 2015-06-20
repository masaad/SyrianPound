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
             var connection = DependencyService.Get<INetworkConnectionInfo>();
		    if (!connection.IsOnline())
		    {
                DisplayAlert("Internet Connection", "Your rates maybe out of date. Connect to the internet get the current rates.", "OK"); 
		    }		   
		}


	}
}

