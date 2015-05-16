using System;

namespace SyrianPound
{
	public class Currency : ICurrency
	{
		public Currency ()
		{
		}

	 	public double BlackMarketValue { get; set;} 
		public double CentralBankValue { get; set;} 
	}
}

