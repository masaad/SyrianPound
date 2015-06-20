using SystemConfiguration;
using SyrianPound.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkConnectionInfoInfo_iOS))]
namespace SyrianPound.iOS
{
    public class NetworkConnectionInfoInfo_iOS : INetworkConnectionInfo
    {
        public bool IsOnline()
        {
            return IsHostReachable("www.google.com"); 
        }

        private static bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {          
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                noConnectionRequired = true;

            return isReachable && noConnectionRequired;
        }

        private static bool IsHostReachable(string host)
        {
            if (string.IsNullOrEmpty(host))
                return false;

            using (var r = new NetworkReachability(host))
            {
                NetworkReachabilityFlags flags;

                if (r.TryGetFlags(out flags))
                {
                    return IsReachableWithoutRequiringConnection(flags);
                }
            }
            return false;
        }
    }
}