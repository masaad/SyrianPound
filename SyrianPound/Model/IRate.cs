using System;

namespace SyrianPound
{
	public interface IRate : IAuditable
	{
		 Guid Id { get; } 
		ICurrency CurrencyInfo { get; set; }
		 IMarketPlace Market { get; set; } 
		 double ExchangePrice { get; set; }
		 DateTime StartDate { get; set; } 
		 DateTime EndDate { get; set; } 
	}
}

