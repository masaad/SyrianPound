using System;
using System.Collections.Generic;
using System.Linq;
using SyrianPound.Resources;
using Xamarin.Forms;

namespace SyrianPound
{
	public class RatesHostViewModel : ViewModelBase, ITabContentViewModel 
	{		
		public RatesHostViewModel ()
		{
			TabName = AppResources.TabNameRates;

            MessagingCenter.Subscribe<MainPageViewModel, IEnumerable<Rate>>(this, "GetLocal", (model, list) =>
            {                
                Intialize(list.ToList());              
                ExchangeRateService.SyncRemoteRates(LastUpdate).ContinueWith(r => Intialize(r.Result.ToList())); 
            });                      
		}

	    private void Intialize(List<Rate> rates)
	    {
            if (!rates.Any()) return;
            LastUpdate = (from d in rates select d.LastUpdated).Max();
            SellingDollarRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Selling);
            BuyingDollarRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Buying);
            SellingEuroRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Selling);
            BuyingEuroRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Buying);	      	       
	    }
	
		public string TabName { get; private set; } 

		private Rate _sellingDollarRate; 

		public Rate SellingDollarRate
		{
			get { return _sellingDollarRate;  }
			set 
			{
				_sellingDollarRate = value; 
				OnPropertyChanged (); 
			}
		} 

		private Rate _buyingDollarRate; 

		public Rate BuyingDollarRate 
		{ 
			get { return _buyingDollarRate; } 
			set 
			{
				_buyingDollarRate = value; 
				OnPropertyChanged (); 
			}
		} 
	
		private Rate _sellingEuroRate; 

		public Rate SellingEuroRate
		{
			get { return _sellingEuroRate; } 
			set 
			{
				_sellingEuroRate = value; 
				OnPropertyChanged (); 
			}
		} 

		private Rate _buyingEuroRate; 

		public Rate BuyingEuroRate
		{ 
			get { return _buyingEuroRate; } 
			set 
			{
				_buyingEuroRate = value; 
				OnPropertyChanged (); 
			}
		} 

		private DateTime _lastUpdate; 

		public DateTime LastUpdate
		{
			get { return _lastUpdate; } 
			set 
			{
				_lastUpdate = value; 
				OnPropertyChanged (); 
			}
		} 
	}
}

