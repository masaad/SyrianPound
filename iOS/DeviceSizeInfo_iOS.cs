using System;
using SystemConfiguration;
using SyrianPound.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SyrianPound.iOS.DeviceSizeInfo_iOS))]
namespace SyrianPound.iOS
{
	public class DeviceSizeInfo_iOS : IDeviceSizeInfo
	{
		public DeviceSizeInfo_iOS ()
		{			
		}

		public float GetWidth()
		{
			return float.Parse(IosDeviceSizeInfoSinglton.Instance.MainScreenBounds.Width.ToString()); 
		}

		public float GetHeight() 
		{
			return float.Parse(IosDeviceSizeInfoSinglton.Instance.MainScreenBounds.Height.ToString()); 
		}
	}

	public class IosDeviceSizeInfoSinglton
	{
		private static IosDeviceSizeInfoSinglton _instance; 

		private IosDeviceSizeInfoSinglton(){}

		public static IosDeviceSizeInfoSinglton Instance
		{
			get 
			{
				if (_instance == null) 
				{
					_instance = new IosDeviceSizeInfoSinglton (); 
				}
				return _instance; 
			}
		}

		public CoreGraphics.CGRect MainScreenBounds {
			get;
			set;
			
		}

	}
}

