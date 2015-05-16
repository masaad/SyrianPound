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
			ItemsSource = vm.Tabs; 
		}
	}
}

