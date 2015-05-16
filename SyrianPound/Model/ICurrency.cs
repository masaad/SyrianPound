using System;

namespace SyrianPound
{
	public interface ICurrency
	{
		double BlackMarketValue { get; set;} 
		double CentralBankValue { get; set;} 
	}
}

