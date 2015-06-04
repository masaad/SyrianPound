using System.Runtime.Serialization;

namespace SyrianPoundService.DataObjects
{
    [DataContract(Name = "RateChange")]
    public class RateChangeDTO
    {
        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public ChangeType Type { get; set; } 
    }
}