﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using SyrianPound.Resources;
using Xamarin.Forms;

namespace SyrianPound
{
	public class CalculatorViewModel : ViewModelBase, ITabContentViewModel
	{	   
	    private string _conversionDirection = "From";
	    private string _symbol = "$"; 
		public CalculatorViewModel ()
		{
			TabName = AppResources.TabNameCalculator;
            MessagingCenter.Subscribe<RatesHostViewModel, IEnumerable<Rate>>(this, "RatesAcquired", (model, list) =>
            {
                Rates = list.ToList(); 
            });           

            OperationButtonCommand = new Command<string>(OperationButtonClicked);
            NumbersButtonCommand = new Command<string>(NumbersButtonClicked);
            AcButtonCommand = new Command(AcButtonClicked);

		    InputSymbol = "$";
		    ResultSymbol = AppResources.SyrianPoundSymbol; 
		}



        public ICommand OperationButtonCommand { get; private set; }
        public ICommand NumbersButtonCommand { get; private set; }

        public ICommand AcButtonCommand { get; private set; }


        private string _results = "0";

        public string Results
	    {
            get { return _results;  }
	        set
	        {
	            _results = value;
	            OnPropertyChanged();
	        }
	    }

        private string _input = "0";

        public string Input
	    {
            get { return _input; }
	        set
	        {
	            _input = value;
	            OnPropertyChanged();
	        }
	    }

	    private string _inputSymbol;

	    public string InputSymbol
	    {
            get { return _inputSymbol;  }
	        set
	        {
	            _inputSymbol = value;
	            OnPropertyChanged();
	        }
	    }

	    private string _resultSymbol; 
	    public string ResultSymbol
	    {
            get { return _resultSymbol; }
	        set
	        {
	            _resultSymbol = value; 
	            OnPropertyChanged();
	        }
	    }

	    private string _selectedTradeType;

	    public string SelectedTradType
	    {
            get { return _selectedTradeType; }
	        set
	        {
	            _selectedTradeType = value;
                Calculate(Input.ToString(), true); 
	        }
	    }

        public string TabName { get; private set; }

        public List<Rate> Rates { get; private set; }

	    private void AcButtonClicked()
	    {
	        Results = "0";
	        Input = "0"; 	     
	    }
	   

	    public void OperationButtonClicked(string value)
	    {
	        string[] paramters = value.Split('-');
	        _conversionDirection = paramters[0];
	        _symbol = paramters[1];

	        switch (value)
	        {
                case "From-$":
	                InputSymbol = "$";
                    ResultSymbol = AppResources.SyrianPoundSymbol;
	                break;               
                case "To-$":
                    InputSymbol = AppResources.SyrianPoundSymbol;
	                ResultSymbol = "$"; 
	                break;
                case "From-€":
                    InputSymbol = "€";
                    ResultSymbol = AppResources.SyrianPoundSymbol;
	                break;
                case "To-€":
                    InputSymbol = AppResources.SyrianPoundSymbol;
	                ResultSymbol = "€"; 
	                break;
	        }
            Calculate(Input, true); 
	    }

    

	    public void NumbersButtonClicked(string value)
	    {	        
	        Calculate(value, false);
	    }

	    private void Calculate(string inputValue, bool isInternalCall)
	    {
	        if (!Rates.Any())
	        {
                MessagingCenter.Send<CalculatorViewModel, bool>(this, "IsOnline", false);
	            return; 
	        }
            if (Input == "Error") return; 

	        if (!isInternalCall)
	        {
                Input += inputValue;
	            Input = Input.StartsWith("0") && !Input.Contains(".")
	                ? Input.TrimStart('0')
	                : Input;
	        }
	            
            double doubleInput =  GetDoubleFor(Input);

	        if (doubleInput > 999999999999999999999.00)
	        {
	            Input = "Error"; 
	            return;
	        }
           
	        TradeType trade = SelectedTradType == AppResources.LblSelling ? TradeType.Selling : TradeType.Buying;
	        var selectedRate = Rates.First(r => r.CurrencyInfo.Symbol == _symbol && r.Trade == trade);

	        Results = _conversionDirection == "To"
                ? Math.Round(doubleInput / selectedRate.ExchangePrice, 2).ToString()
                : Math.Round(selectedRate.ExchangePrice * doubleInput, 2).ToString();
	    }

        private double GetDoubleFor(string inputValue)
	    {
	        if (string.IsNullOrEmpty(inputValue)) return 0;
            var trimmedValue = inputValue.EndsWith(".")
                ? inputValue + "0"
                : inputValue; 	    
	        return double.Parse(trimmedValue, CultureInfo.InvariantCulture); 
	    }	   
	}
}

