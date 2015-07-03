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
			MessagingCenter.Subscribe<RatesHostViewModel, bool>(this, "NoConnection", (model, isDisconnected) =>
			{
				if (isDisconnected)
						DisplayAlert(AppResources.NoConnectionMsgTitle, AppResources.NoConnectionSyncMsg, "OK");

			}); 
           
		}


	}
}

