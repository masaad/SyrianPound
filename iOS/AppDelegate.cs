using Foundation;
using UIKit;
using Xamarin.Forms;

namespace SyrianPound.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{	   
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

			global::Xamarin.Forms.Forms.Init ();
           
            DependencyService.Register<INetworkConnectionInfo, NetworkConnectionInfoInfo_iOS>();
			DependencyService.Register<IDeviceSizeInfo, DeviceSizeInfo_iOS> (); 
			 
		 
			IosDeviceSizeInfoSinglton.Instance.MainScreenBounds = UIScreen.MainScreen.Bounds; 

			// Code for starting up the Xamarin Test Cloud Agent
			//#if ENABLE_TEST_CLOUD
			//Xamarin.Calabash.Start();
			//#endif

			LoadApplication (new App ()); 

			return base.FinishedLaunching (app, options);
		}
	}
}

