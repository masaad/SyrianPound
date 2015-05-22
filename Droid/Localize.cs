using System;
using Xamarin.Forms; 

[assembly:Dependency(typeof(SyrianPound.Droid.Localize))]
namespace SyrianPound.Droid
{
	public class Localize : SyrianPound.ILocalize
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo ()
		{
			var androidLocale = Java.Util.Locale.Default;
			var netLanguage = androidLocale.ToString().Replace ("_", "-"); // turns pt_BR into pt-BR
			return new System.Globalization.CultureInfo(netLanguage);
		}
	}
}

