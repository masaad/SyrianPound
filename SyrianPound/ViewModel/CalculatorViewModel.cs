using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Xml;
using SyrianPound.Resources;
using Xamarin.Forms;

namespace SyrianPound
{
	public class CalculatorViewModel : ViewModelBase, ITabContentViewModel
	{
	    private string _enteryPlaceHolder = string.Empty;
	    private string _conversionDirection = "From";
	    private string _symbol = "$"; 
		public CalculatorViewModel ()
		{
			TabName = AppResources.TabNameCalculator;
            MessagingCenter.Subscribe<MainPageViewModel, IEnumerable<Rate>>(this, "GetLocal", (model, list) =>
            {
                Rates = list.ToList(); 
            });

            MessagingCenter.Subscribe<App, IEnumerable<Rate>>(this, "SyncOnResume", (model, list) =>
            {
                Rates = list.ToList(); 
            });

            OperationButtonCommand = new Command<string>(OperationButtonClicked);
            NumbersButtonCommand = new Command<string>(NumbersButtonClicked);
            AcButtonCommand = new Command(AcButtonClicked);

		    ConversionToDisplay = AppResources.BtnDollarToSyrianPound; 

		}


        public ICommand OperationButtonCommand { get; private set; }
        public ICommand NumbersButtonCommand { get; private set; }

        public ICommand AcButtonCommand { get; private set; }


	    private double _results = 0;

	    public double Results
	    {
            get { return _results;  }
	        set
	        {
	            _results = value;
	            OnPropertyChanged();
	        }
	    }

	    private string _convesionToDisplay;

	    public string ConversionToDisplay
	    {
            get { return _convesionToDisplay;  }
	        set
	        {
	            _convesionToDisplay = value;
	            OnPropertyChanged();
	        }
	    }

        public string SelectedTradType { get; set; }

	    private void AcButtonClicked()
	    {
	        Results = 0;
	        _enteryPlaceHolder = string.Empty;        

	    }
	   

	    public void OperationButtonClicked(string value)
	    {
	        string[] paramters = value.Split('-');
	        _conversionDirection = paramters[0];
	        _symbol = paramters[1];

	        switch (value)
	        {
                case "From-$":
	                ConversionToDisplay = AppResources.BtnDollarToSyrianPound;
	                break;
                case "To-$":
	                ConversionToDisplay = AppResources.BtnSyrianPoundToDollar;
	                break;
                case "From-€":
	                ConversionToDisplay = AppResources.BtnEuroToSyrianPound;
	                break;
                case "To-€":
	                ConversionToDisplay = AppResources.BtnSyrianPoundToEuro;
	                break;

	        }
	    }

    

	    public void NumbersButtonClicked(string value)
	    {
	        if (string.IsNullOrEmpty(_enteryPlaceHolder) && value == ".")
	            _enteryPlaceHolder = "0"; 
	        _enteryPlaceHolder += value; 
	        TradeType trade = SelectedTradType == AppResources.LblSelling ? TradeType.Selling : TradeType.Buying;

	        var selectedRate = Rates.First(r => r.CurrencyInfo.Symbol == _symbol && r.Trade == trade);


	        double valueEntered = double.Parse(_enteryPlaceHolder);

            if (valueEntered == 0) return;  

	        Results = _conversionDirection == "To"
	            ? Math.Round(selectedRate.ExchangePrice*valueEntered, 2)
	            : Math.Round(valueEntered/selectedRate.ExchangePrice, 2); 
	    }

		public string TabName { get; private set;  }

        public List<Rate> Rates { get; private set; }
	}
}

