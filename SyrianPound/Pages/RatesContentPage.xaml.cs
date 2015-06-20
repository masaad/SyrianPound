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
            MessagingCenter.Subscribe<MainPageViewModel, bool>(this, "IsOnline", (model, result) =>
            {
                DisplayAlert("Internet Connection", "Internet connection is required", "OK"); 
            });
		}


	}
}

