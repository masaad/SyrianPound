using System;
using System.Collections.Generic;
using System.Diagnostics;
using SyrianPound.Service;
using Xamarin.Forms;

namespace SyrianPound
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new MainPage(); 
		}

		protected override void OnStart ()
		{
			// Handle when your app starts	


        
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
            var rates = LocalDatabaseService.GetRates();
            rates.ContinueWith(x =>
            {
                Debug.WriteLine("MessaginCenter: about to send (SyncOnResume)");
                MessagingCenter.Send<App, IEnumerable<Rate>>(this, "SyncOnResume", x.Result);
            }); 		               		    
		}
	}
}

