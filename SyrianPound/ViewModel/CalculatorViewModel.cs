using System;
using SyrianPound.Resources;

namespace SyrianPound
{
	public class CalculatorViewModel : ViewModelBase, ITabContentViewModel
	{
		private string _tabName; 
		public CalculatorViewModel ()
		{
			_tabName = AppResources.TabNameCalculator; 
		}

		public string TabName 
		{
			get { return _tabName; } 
		} 
	}
}

