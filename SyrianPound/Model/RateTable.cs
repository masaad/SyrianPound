using System;
using SQLite;

namespace SyrianPound.Model
{
    [Table("Rate")]
    public class RateTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string CurrencyName { get; set; }       
        [MaxLength(4)]
        public string CurrencySymbol { get; set; }
        public double ExchangePrice { get; set; }
        public TradeType Trade { get; set; }        
        public double ChangeAmount { get; set;} 
		public ChangeType ChangeAmountType { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
