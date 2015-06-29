using Android.App;
using Android.Content;
using Android.Net;
using SyrianPound.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkConnectionInfo_Android))]
namespace SyrianPound.Droid
{
    public class NetworkConnectionInfo_Android : Activity, INetworkConnectionInfo
    {
        public bool IsOnline()
        {
			var connectionMngr = ConnectivitySingleton.Instance.ConnectivityManager;   
            var activeConnection = connectionMngr.ActiveNetworkInfo;
            return activeConnection != null &&
                   activeConnection.IsConnected; 
        }

       
    }

	public class ConnectivitySingleton
	{
		private static ConnectivitySingleton _instance; 

		private ConnectivitySingleton(){}

		public static ConnectivitySingleton Instance
		{
			get 
			{ 
				if (_instance == null) 
				{
					_instance = new ConnectivitySingleton (); 
				}
				return _instance; 
			}
		}

		public ConnectivityManager ConnectivityManager {
			get;
			set; 
		}
	}


}