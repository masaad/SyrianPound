using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Runtime.Hosting; 
using Android.Net;


namespace SyrianPound.Droid
{
	[Activity (Label = "Syrian Pound Exchange Rates", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

            //ToDo: Get Active Rates from Service. 

			var connSingleton = ConnectivitySingleton.Instance; 
			connSingleton.ConnectivityManager =  (ConnectivityManager)GetSystemService(Context.ConnectivityService);  

			LoadApplication (new App ());
		}			
	}
}

