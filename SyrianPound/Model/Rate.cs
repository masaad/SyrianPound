using System;

namespace SyrianPound
{
	public class Rate : IRate 
	{
		public Rate (Guid id)
		{
			_id = id; 
		}

		private Guid _id; 
		public Guid Id
		{
			get { return _id; } 
		}
		public ICurrency CurrencyInfo { get; set; }
		public double ExchangePrice { get; set; }
		public TradeType Trade { get; set; } 
		public IRateChange Change { get; set; } 
		public DateTime StartDate { get; set; } 
		public DateTime EndDate { get; set; } 
		public string CreatedBy { get; set; } 
		public string UpdatedBy { get; set; } 
		public DateTime CreatedDate { get; set;} 
		public DateTime UpdatedDate { get; set; } 
	}
}

