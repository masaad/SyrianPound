using System;
using System.Collections.Generic;
using SyrianPound.Resources;
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
		            DisplayAlert(AppResources.NoConnectionMsgTitle, AppResources.NoConnectionMsg, "OK");

		    }); 
           
		}


	}
}

