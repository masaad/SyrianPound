using System;

namespace SyrianPound
{
	public interface ICurrency : IAuditable
	{
	    Guid Id { get; } 
		string Name { get; set; } 
		string Symbol { get; set; } 
		string Country { get; set; } 	
	}
}

