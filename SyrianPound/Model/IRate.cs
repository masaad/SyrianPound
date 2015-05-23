using System;

namespace SyrianPound
{
	public interface IRate : IAuditable
	{
		 Guid Id { get; } 
		 ICurrency CurrencyInfo { get; set; }
		 TradeType Trade{ get; set; } 
		 double ExchangePrice { get; set; }
		IRateChange Change{ get; set; } 
		 DateTime StartDate { get; set; } 
		 DateTime EndDate { get; set; } 
	}
}

