using System;

using Xamarin.Forms;

namespace SyrianPound
{
	public class RateView : ContentView
	{
		public RateView ()
		{
			var grid = CreateGrid (); 
			AddRateLabel (grid); 
			Content = grid; 
		}

		private Grid CreateGrid()
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
				Text = "$250", 
				TextColor = Color.White, 
				XAlign = TextAlignment.Center, 
				YAlign = TextAlignment.Center,
				FontSize = 30, 
			}; 

			layoutGrid.Children.Add(rateLabel); 

			Grid.SetRow (rateLabel, 0);
			Grid.SetColumn (rateLabel, 0); 

		
			var rateLabel1 = new Label {
				Text = "Test", 
				TextColor = Color.White, 

					//FontSize = 20, 

			}; 

			layoutGrid.Children.Add(rateLabel1);

			Grid.SetRow (rateLabel1, 1);
			Grid.SetColumn (rateLabel1, 0); 
		}
	}
}


