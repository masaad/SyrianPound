using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using SyrianPound.Resources;
using Xamarin.Forms;

namespace SyrianPound
{
	public class RatesHostViewModel : ViewModelBase, ITabContentViewModel 
	{		
		public RatesHostViewModel ()
		{
			TabName = AppResources.TabNameRates;
		    IsBusy = true; 
		    OnRefreshClick = new Command(() =>
		    {
				var connection = DependencyService.Get<INetworkConnectionInfo>();
				if (!connection.IsOnline())
				{
					MessagingCenter.Send<RatesHostViewModel, bool>(this, "NoConnection", true);
				}	
				else
				{
			        IsBusy = true; 
	                ExchangeRateService.SyncRemoteRates(LastUpdate).ContinueWith(r =>
	                {
	                    Intialize(r.Result.ToList());                   
	                });
				}
		    }); 

            MessagingCenter.Subscribe<MainPageViewModel, IEnumerable<Rate>>(this, "GetLocal", (model, list) =>
            {
                SyncRates(list.ToList());
            });

            MessagingCenter.Subscribe<App, IEnumerable<Rate>>(this, "SyncOnResume", (model, list) =>
            {
                SyncRates(list.ToList());
            }); 
                     
		}

	    private void SyncRates(List<Rate> list)
	    {
            Object lockObject = new Object();
            lock (lockObject)
	        {
                Debug.WriteLine("MessagingCenter: GetLocal recieved with Rates Count: {0}", list.Count());
                Intialize(list.ToList());
                ExchangeRateService.SyncRemoteRates(LastUpdate).ContinueWith(r =>
                {
                    Intialize(r.Result.ToList());                   
                    Debug.WriteLine("MessagingCenter:  ExchangeRateService.SyncRemoteRates Complete Rates Count: {0}",
                        r.Result.Count());
                });
	        }
	       
	    }

	    private void Intialize(List<Rate> rates)
	    {
            if (!rates.Any()) return;
            LastUpdate = (from d in rates select d.LastUpdated).Max().ToLocalTime();
            SellingDollarRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Selling);
            BuyingDollarRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "$" && x.Trade == TradeType.Buying);
            SellingEuroRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Selling);
            BuyingEuroRate = rates.FirstOrDefault(x => x.CurrencyInfo.Symbol == "€" && x.Trade == TradeType.Buying);
            MessagingCenter.Send<RatesHostViewModel, IEnumerable<Rate>>(this, "RatesAcquired", rates);
	        IsBusy = false; 
	    }

        public ICommand OnRefreshClick { get; private set; }
	   
	
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
                OnPropertyChanged("DisplayLastUpdate");
			}
		}


	    public string DisplayLastUpdate
	    {
	        get
	        {         
	            return string.Format("{0}: {1:g}", AppResources.LastUpdate, LastUpdate.ToString("g", CultureInfo.InvariantCulture));
	        }
	    }

	    public string CurrentLanguage
	    {
            get { return CultureInfo.CurrentUICulture.Name.Split('-').FirstOrDefault(); }
	    }
			


	    private bool _isBusy;

	    public bool IsBusy
	    {
            get { return _isBusy; }
	        set
	        {
	            _isBusy = value;
	            OnPropertyChanged();
	        }
	    }
			

		public bool IsIOSPlatform
		{
			get { return Device.OS == TargetPlatform.iOS; }
		}

		public bool IsAndriodPlatform
		{
			get { return Device.OS == TargetPlatform.Android; } 
		}

	}
}

