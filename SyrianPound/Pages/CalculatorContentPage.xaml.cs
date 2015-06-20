﻿using System;
using System.Collections.Generic;
using SyrianPound.Resources;
using Xamarin.Forms;

namespace SyrianPound
{
	public partial class CalculatorContentPage : ContentPage
	{
		public CalculatorContentPage ()
		{
			InitializeComponent ();
		    SwitchLabel.Text = AppResources.LblBuying;
            MessagingCenter.Subscribe<CalculatorViewModel, bool>(this, "IsOnline", (model, result) =>
            {
                DisplayAlert("Internet Connection", "Internet connection is required to caculate rates", "OK");
            });
		}

	    private CalculatorViewModel ViewModel
	    {
            get { return BindingContext as CalculatorViewModel; }
	    }

	    private void SwitchKey_OnToggled(object sender, ToggledEventArgs e)
	    {
	        SwitchLabel.Text = e.Value
	            ? AppResources.LblSelling
	            : AppResources.LblBuying;
            ViewModel.SelectedTradType = SwitchLabel.Text; 
	    }
	}
}

