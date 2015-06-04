using Microsoft.WindowsAzure.Mobile.Service;

namespace SyrianPoundService.DataObjects
{
    
	public class RateChange : EntityData
	{	       
		public double Amount { get; set;}      
		public ChangeType Type { get; set; } 
	}
}

