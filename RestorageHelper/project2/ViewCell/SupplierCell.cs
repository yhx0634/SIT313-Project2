using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace project2
{
	public class SupplierCell : ViewCell
	{

		public SupplierCell()
		{
			var grid = new Grid { RowSpacing = 1, ColumnSpacing = 10 };

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });

			StackLayout layout = new StackLayout();
			layout.VerticalOptions = LayoutOptions.Center;
			layout.Padding = 5;


			var supplierLable = new Label
			{
				Text = "Supplier Name",
				FontSize = 20,
				VerticalTextAlignment = TextAlignment.Center,
			};


			var supplieridLable = new Label
			{
				Text = "Supplier Name",
				FontSize = 20,
				VerticalTextAlignment = TextAlignment.Center,
				IsVisible = false
			};
			supplieridLable.SetBinding(Label.TextProperty, "ID");


			//var inputLayout = new StackLayout();
			//inputLayout.VerticalOptions = LayoutOptions.Center;
			//inputLayout.Padding = 5;


			var supplierInput = new Entry
			{
				Text = "SupplierName",
				FontSize = 18,
				//WidthRequest = 120,
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.End
			};
			supplierInput.SetBinding(Entry.TextProperty, "SupplierName");


			var addButton = new Button
			{
				Text = "+",
				FontSize = 20,

			};




			grid.Children.Add(supplieridLable, 0, 0);
			grid.Children.Add(supplierLable, 0, 0);
			grid.Children.Add(supplierInput, 1, 0);
			grid.Children.Add(addButton, 2, 0);

			var deleteButton = new Button
			{
				Text = "-",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
			};

		
			addButton.Clicked += (sender, e) =>
			{
				grid.Children.Remove(addButton);

				grid.Children.Add(deleteButton,2,0);

				Data.SupplierList.Add(new SupplierList() { SupplierName = "" });

			};

			deleteButton.Clicked += (sender, e) =>
				{
					Functions.removeList(Functions.IndexofSupplier(Convert.ToInt32(supplieridLable.Text)));
				};

			layout.Children.Add(grid);
			View = layout;
		}
	}
}

