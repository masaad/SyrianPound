using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SyrianPound
{
	public class ViewModelBase : INotifyPropertyChanged 
	{
		public event PropertyChangedEventHandler PropertyChanged; 

		public ViewModelBase () 
		{					
		}

		protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName)); 
		}
	}
}

