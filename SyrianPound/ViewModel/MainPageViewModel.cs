using System;
using System.Collections.Generic; 
using System.Collections.ObjectModel; 

namespace SyrianPound
{
	public class MainPageViewModel
	{
		
		public MainPageViewModel ()
		{
			Tabs = new ObservableCollection<TabsTest> ();
			Tabs.Add (new TabsTest{ TabName = "Exchange Rate"}); 
			Tabs.Add (new TabsTest { TabName = "Caculator"}); 
		}

		public ObservableCollection<TabsTest> Tabs { get; private set; } 
	}

	public class TabsTest
	{
		public string TabName { get; set; } 
	}
}

