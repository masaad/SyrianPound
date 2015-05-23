using System;
using Xamarin.Forms;

namespace SyrianPound
{
	public class ChangeTypeConverter : IValueConverter
	{
		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ((ChangeType)value == ChangeType.Increase)
				return "Increase"; 
			else 
				return "Decrease"; 
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
		
	}
}

