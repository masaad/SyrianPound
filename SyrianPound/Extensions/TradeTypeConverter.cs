using System;
using Xamarin.Forms;

namespace SyrianPound
{
	public class TradeTypeConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ((TradeType)value == TradeType.Selling)
				return "Selling";
			else
				return "Buying"; 
				
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion

	}
}

