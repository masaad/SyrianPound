using System;

using Xamarin.Forms;

namespace SyrianPound
{
	public class RateView : ContentView
	{
		public RateView ()
		{
			var grid = CreateMainGrid (); 
			AddRateLabel (grid); 
			AddRateChanges (grid); 
			Content = grid; 
		}

		private Grid CreateMainGrid()
		{
			var grid = new Grid 
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowSpacing=1, 
				BackgroundColor = Color.FromHex("FFADADAD"),
				RowDefinitions = 
				{
					new RowDefinition { Height = new GridLength(0.75, GridUnitType.Star)},
					new RowDefinition { Height = new GridLength(0.25, GridUnitType.Star)}
				}, 
				ColumnDefinitions = 
				{ 
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
				}
			}; 
			return grid; 
		}

		private void AddRateLabel(Grid layoutGrid) 
		{
			var rateLabel = new Label {				
				TextColor = Color.White, 
				XAlign = TextAlignment.Center, 
				YAlign = TextAlignment.Center,
				FontSize = 30, 
			}; 

			rateLabel.SetBinding(Label.TextProperty, "ExchangePrice");  
			layoutGrid.Children.Add(rateLabel); 

			Grid.SetRow (rateLabel, 0);
			Grid.SetColumn (rateLabel, 0); 				
		}

		private void AddRateChanges(Grid layoutGrid)
		{
			var nestedGrid = createNestedGrid (); 
			layoutGrid.Children.Add (nestedGrid); 
			Grid.SetRow (nestedGrid, 1); 
			Grid.SetColumn (nestedGrid, 0); 

			AddRateChangeLabel (nestedGrid); 
			AddChangeImage (nestedGrid); 
		}			

		private Grid createNestedGrid()
		{
			var grid = new Grid 
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowSpacing=0, 
				BackgroundColor = Color.FromHex("FFADADAD"),
				RowDefinitions = 
					{
						new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}
					}, 
				ColumnDefinitions = 
					{ 
						new ColumnDefinition { Width = new GridLength(0.25, GridUnitType.Star) },
					    new ColumnDefinition { Width = new GridLength(0.75, GridUnitType.Star) }
					}
				}; 
			return grid; 
		}

		private void AddRateChangeLabel(Grid nestedGrid)
		{
			var lblChangeAmount = new Label ();
		
			lblChangeAmount.SetBinding(Label.TextProperty, "Change.Amount"); 				
			nestedGrid.Children.Add(lblChangeAmount);

			Grid.SetRow (lblChangeAmount, 0);
			Grid.SetColumn (lblChangeAmount, 1); 
		}

		private void AddChangeImage(Grid nestedGrid) 
		{			
			var changeImage = new Image { Source = ImageSource.FromResource ("SyrianPound.Images.UpGreen.png"), IsVisible=false };

			var style = new Style (typeof(Image)); 
			//this.FindByName<Style> (""); 
			var multiTrigger = new MultiTrigger (typeof(Image)); 

	
			var changecondition = new BindingCondition (); 
			changecondition.Binding = new Binding (path: "Change.Type"); 
			changecondition.Value = ChangeType.Increase; 
			multiTrigger.Conditions.Add (changecondition); 

			var tradeCondition = new BindingCondition (); 
			tradeCondition.Binding = new Binding (path: "Trade"); 
			tradeCondition.Value = TradeType.Selling; 
			multiTrigger.Conditions.Add (tradeCondition);

			var visibilitySetter = new Setter (); 
			visibilitySetter.Property = Image.IsVisibleProperty; 
			visibilitySetter.Value = true; 

			multiTrigger.Setters.Add (visibilitySetter); 

		    
			changeImage.Style = style; 

			nestedGrid.Children.Add (changeImage); 
		
			Grid.SetRow (changeImage, 0); 
			Grid.SetColumn (changeImage, 0); 
		}				
	}
}


