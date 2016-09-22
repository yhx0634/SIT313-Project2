using System;
using Xamarin.Forms;

namespace project2
{
	public class OrderCell : ViewCell
	{
		public OrderCell()
		{
			var grid = new Grid { RowSpacing = 1, ColumnSpacing = 10 };

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
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
				Margin = new Thickness(10, 0, 0, 0),
				VerticalTextAlignment = TextAlignment.Center,
			};
			itemNameLable.SetBinding(Label.TextProperty, "ItemsName");


			var supplierNameLable = new Label
			{
				Text = "Lable",
				FontSize = 20,
				TextColor = Color.Navy,
				Margin = new Thickness(10, 0, 0, 0),
				VerticalTextAlignment = TextAlignment.Center,
			};
			supplierNameLable.SetBinding(Label.TextProperty, "SupplierName");


			var stockCountLable2222 = new Label
			{
				Text = "Stock Count:",
				FontSize = 20,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
			};


			var stockCountLable = new Label
			{
				Text = "Lable",
				FontSize = 20,
				HorizontalTextAlignment = TextAlignment.End,
				Margin = new Thickness(0, 0, 5, 0),
				VerticalTextAlignment = TextAlignment.Center,
			};
			stockCountLable.SetBinding(Label.TextProperty, "Count");


			var countInput = new Entry
			{
				Text = "0",
				FontSize = 18,
				WidthRequest = 120,
				HorizontalTextAlignment = TextAlignment.Center,


			};
			countInput.SetBinding(Entry.TextProperty, "OrderCount");

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


			grid.Children.Add(itemNameLable, 0, 0);
			grid.Children.Add(stockCountLable2222, 1, 0);
			grid.Children.Add(stockCountLable, 1, 0);
			grid.Children.Add(supplierNameLable, 0, 1);
			grid.Children.Add(input, 1, 1);

			View = grid;
		}
	}
}

