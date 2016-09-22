using System;
using Xamarin.Forms;

namespace project2
{
	public class ItemListCell : ViewCell
	{
		public ItemListCell()
		{
			StackLayout layout = new StackLayout();
			layout.HeightRequest = 110;
			layout.VerticalOptions = LayoutOptions.Center;
			layout.Padding = 5;

			var grid = new Grid { RowSpacing = 1, ColumnSpacing = 10 };

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });




			var imageButton = new Button
			{
				//Text="Button", 
				HorizontalOptions = LayoutOptions.Start
			};
			imageButton.SetBinding(Button.ImageProperty, "Image");

			var itemNameLable = new Label
			{
				Text = "Item Name",
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center

			};

			var nameInput = new Entry
			{
				Text = "",
				//WidthRequest = 120,
				//HeightRequest = 20,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 2, 5, 0)

			};
			nameInput.SetBinding(Entry.TextProperty, "ItemsName");

			// default unit
			var unitLable = new Label
			{
				Text = "Default Unit",
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center

			};

			var unitInput = new Entry
			{
				Text = "",
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 2, 5, 0)

			};
			unitInput.SetBinding(Entry.TextProperty, "ItemsUnit");

			// default supplier
			var supplierLable = new Label
			{
				Text = "Supplier",
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center

			};
			//itemNameLable.SetBinding(Label.TextProperty, "ItemName");
			var supplierInput = new Entry
			{
				Text = "",
				//WidthRequest = 120,
				//HeightRequest = 20,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 2, 5, 2)

			};
			supplierInput.SetBinding(Entry.TextProperty, "SupplierName");


			var addButton = new Button
			{
				Text = "Add",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				//BackgroundColor = Color.Green,
				//TextColor = Color.White
			};

			var deleteButton = new Button
			{
				Text = "x",
				FontSize = 25,
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.Center,
				//BackgroundColor = Color.Green,
				//TextColor = Color.White
			};

			//AbsoluteLayout.SetLayoutBounds(addButton, new Rectangle(.5, 1, .5, .1));
			//AbsoluteLayout.SetLayoutFlags(addButton, AbsoluteLayoutFlags.All);


			addButton.Clicked += (sender, e) =>
			{
				Data.ItemList.Add(new ItemsList() {ItemsName = "", ItemsUnit = "", ItemsImage = "",  SupplierName = ""});
			};

			deleteButton.Clicked += (sender, e) =>
			{
				var itemsList = (ItemsList)BindingContext;
				App.Database.DeleteItemsItem(itemsList.ID);
				layout.Children.Remove(grid);
				View = layout;

			};



			//grid.Children.Add(imageButton, 0, 0);
			//Grid.SetRowSpan(imageButton, 3);

			grid.Children.Add(itemNameLable, 0, 0);
			grid.Children.Add(nameInput, 1, 0);
			Grid.SetColumnSpan(nameInput, 2);

			grid.Children.Add(unitLable, 0, 1);
			grid.Children.Add(unitInput, 1, 1);
			Grid.SetColumnSpan(unitInput, 2);

			grid.Children.Add(supplierLable, 0, 2);
			grid.Children.Add(supplierInput, 1, 2);
			Grid.SetColumnSpan(supplierInput, 2);

			grid.Children.Add(addButton, 3, 0);
			Grid.SetRowSpan(addButton, 2);
			grid.Children.Add(deleteButton, 3, 2);

			//var buttonLayout = new StackLayout();
			//buttonLayout.HeightRequest = 10;


			//buttonLayout.Children.Add(addButton);

			layout.Children.Add(grid);
			//layout.Children.Add(buttonLayout);

			View = layout;


		}
	}
}

