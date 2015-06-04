using System;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace SyrianPoundService.DataObjects
{
	public class Rate : EntityData 
	{
		public Currency CurrencyInfo { get; set; }
		public double ExchangePrice { get; set; }
		public TradeType Trade { get; set; } 
		public RateChange Change { get; set; } 
		public DateTime StartDate { get; set; } 
		public DateTime? EndDate { get; set; } 
		public string CreatedBy { get; set; } 
		public string UpdatedBy { get; set; }
	}
}

