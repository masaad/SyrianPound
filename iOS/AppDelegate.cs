using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;

namespace SyrianPound.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
	    public static MobileServiceClient MobileService = new MobileServiceClient("https://syrianpound.azure-mobile.net/", 
                                                                                  "SnSEtadGgkyNfUCgtYpLeAQNLadQqP28" ); 
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

			global::Xamarin.Forms.Forms.Init ();

            CurrentPlatform.Init();



			// Code for starting up the Xamarin Test Cloud Agent
			//#if ENABLE_TEST_CLOUD
			//Xamarin.Calabash.Start();
			//#endif

			LoadApplication (new App ()); 

			return base.FinishedLaunching (app, options);
		}
	}
}

