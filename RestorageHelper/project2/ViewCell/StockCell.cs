using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace project2
{
	public class StockCell : ViewCell
	{
		public StockCell()
		{
			var grid = new Grid { RowSpacing = 1, ColumnSpacing = 10 };

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


			var imageButton = new Button
			{
				//Text="Button", 
				HorizontalOptions = LayoutOptions.Start
			};
			imageButton.SetBinding(Button.ImageProperty, "Image");

			var itemNameLable = new Label
			{
				Text = "Lable",
				FontSize = 20,
			};
			itemNameLable.SetBinding(Label.TextProperty, "ItemsName");




			var countInput = new Entry
			{
				Text = "Count",
				FontSize = 18,
				WidthRequest = 120,
				HorizontalTextAlignment = TextAlignment.Center,


			};

			countInput.SetBinding(Entry.TextProperty, "Count");

			var unit = new Label
			{
				Text = "Unit",
				FontSize = 20,

				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.End
			};
			unit.SetBinding(Label.TextProperty, "Unit");

			var plusButton = new Button
			{
				Text = "+",
				FontSize = 20
			};


			plusButton.Clicked += (sender, e) =>
			{
				string t = countInput.Text;

				countInput.Text = Convert.ToString(Functions.plusButton_Clicked(t));

				//Data.StockList.Add(new StockList() { StockDate = System.DateTime.Now,  ItemsID= "", Quality = 0 });
			};

			var minButton = new Button
			{
				Text = "-",
				FontSize = 20
			};

			minButton.Clicked += (sender, e) =>
			{
				string t = countInput.Text;

				countInput.Text = Convert.ToString(Functions.minButton_Clicked(t));
			};



			var input = new StackLayout
			{
				Padding = new Thickness(20, 0, 20, 5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				Children = { plusButton, countInput, minButton, unit }
			};


			grid.Children.Add(imageButton, 0, 0);
			Grid.SetRowSpan(imageButton, 2);

			grid.Children.Add(itemNameLable, 1, 0);
			grid.Children.Add(input, 1, 1);

			View = grid;
		}
	}
}

