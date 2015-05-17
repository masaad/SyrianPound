using System;

namespace SyrianPound
{
	public class Currency : ICurrency
	{
		private Guid _id; 
		
		public Currency (Guid id)
		{
			_id = id; 	
		}

		public Guid Id 
		{
			get { return _id; } 	
		} 
		public string Name { get; set; } 
		public string Symbol { get; set; } 
		public string Country { get; set; } 
		public string CreatedBy { get; set; } 
		public string UpdatedBy { get; set; } 
		public DateTime CreatedDate { get; set;} 
		public DateTime UpdatedDate { get; set; } 
	}
}

