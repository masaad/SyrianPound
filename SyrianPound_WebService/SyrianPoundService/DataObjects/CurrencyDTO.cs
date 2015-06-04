using System.Runtime.Serialization;

namespace SyrianPoundService.DataObjects
{
    [DataContract(Name = "Currency")]
    public class CurrencyDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public string Country { get; set; }         
    }
}