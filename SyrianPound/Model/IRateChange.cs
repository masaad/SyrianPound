using System;

namespace SyrianPound
{
	public interface IRateChange
	{
		double Amount { get; set;} 
		ChangeType Type { get; set; } 	
	}
}

