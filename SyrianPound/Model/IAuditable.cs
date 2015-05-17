using System;

namespace SyrianPound
{
	public interface IAuditable
	{
		string CreatedBy { get; set; } 
		string UpdatedBy { get; set; } 
		DateTime CreatedDate { get; set;} 
		DateTime UpdatedDate { get; set; } 

	}
}

