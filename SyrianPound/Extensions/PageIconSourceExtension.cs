using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml; 

namespace SyrianPound
{
	[ContentProperty ("Source")]
	public class PageIconSourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			// Do your translation lookup here, using whatever method you require
			var imageSource = UIImage.FromFile("Images/second.png"); 

			return imageSource;
		}
	}
}

