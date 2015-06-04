using System;
using System.Runtime.Serialization;

namespace SyrianPoundService.DataObjects
{
    [DataContract]
    public class RateDTO
    {
        [DataMember]
        public CurrencyDTO CurrencyInfo { get; set; }

        [DataMember]
        public double ExchangePrice { get; set; }

        [DataMember]
        public TradeType Trade { get; set; }

        [DataMember]
        public RateChangeDTO Change { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}