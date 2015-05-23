using System;

namespace SyrianPound
{
	public class RateChange : IRateChange
	{
		public RateChange ()
		{
		}

		public double Amount { get; set;} 
		public ChangeType Type { get; set; } 
	}
}

