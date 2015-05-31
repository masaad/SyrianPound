using System;

namespace SyrianPound
{
	public class Rate
	{
        public string Id { get; set; }
		public Currency CurrencyInfo { get; set; }
		public double ExchangePrice { get; set; }
		public TradeType Trade { get; set; } 
		public RateChange Change { get; set; } 
		public DateTime StartDate { get; set; } 
		public DateTime? EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
	}
}

