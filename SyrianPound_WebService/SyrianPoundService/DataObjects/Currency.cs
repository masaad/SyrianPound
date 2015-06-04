using Microsoft.WindowsAzure.Mobile.Service;

namespace SyrianPoundService.DataObjects
{
	public class Currency : EntityData 
	{  
		public string Name { get; set; } 
		public string Symbol { get; set; } 
		public string Country { get; set; } 
		public string CreatedBy { get; set; } 
		public string UpdatedBy { get; set; } 		
	}
}

