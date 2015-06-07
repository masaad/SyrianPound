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
            var connectionMngr = (ConnectivityManager)GetSystemService(Context.ConnectivityService);            
            var activeConnection = connectionMngr.ActiveNetworkInfo;
            return activeConnection != null &&
                   activeConnection.IsConnected; 
        }

       
    }


}