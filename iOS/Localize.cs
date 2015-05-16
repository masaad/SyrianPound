using Xamarin.Forms; 
using Foundation; 

[assembly:Dependency(typeof(SyrianPound.iOS.Localize))]
namespace SyrianPound.iOS
{
	public class Localize : SyrianPound.ILocalize
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo ()
		{
			var netLanguage = "en";
			if (NSLocale.PreferredLanguages.Length > 0) {
				var pref = NSLocale.PreferredLanguages [0];
				netLanguage = pref.Replace ("_", "-"); // turns pt_BR into pt-BR
			}
			return new System.Globalization.CultureInfo(netLanguage);
		}
	}
}

