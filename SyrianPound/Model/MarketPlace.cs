using System;

namespace SyrianPound
{
	public class MarketPlace : IMarketPlace
	{
		private Guid _id; 
		public MarketPlace (Guid id)
		{
			_id = id; 
		}

		public Guid Id 
		{
			get { return _id; }  
		} 

		public string Name { get; set;} 

	}
}

