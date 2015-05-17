using System;

namespace SyrianPound
{
	public class CalculatorViewModel : ViewModelBase, ITabContentViewModel
	{
		private string _tabName; 
		public CalculatorViewModel ()
		{
			_tabName = "Calculator";  //AppResources.TabCalculator; 
		}

		public string TabName 
		{
			get { return _tabName; } 
		} 
	}
}

