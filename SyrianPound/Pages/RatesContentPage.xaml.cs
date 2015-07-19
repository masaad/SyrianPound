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

			//var deviceInfo = DependencyService.Get<IDeviceSizeInfo>(); 

			//var testwidth = deviceInfo.GetWidth(); 
			//var testHeigh = deviceInfo.GetHeight(); 

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

