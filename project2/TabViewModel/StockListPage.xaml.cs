using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace project2
{
	public partial class StockListPage : ContentPage
	{
		public static DateTime dynamdate { get; set;}
		public StockListPage()
		{
			InitializeComponent();


			App.Database.GetDynamListByStockDate();
			stocklistview.ItemsSource = Data.DynamList;


			this.ToolbarItems.Add(new ToolbarItem("Add","", () =>
			{
				Navigation.PushAsync(new StockListChoose());
			}));

			var supplieridLable = new Button
			{
				Text = "Stock Empty, Click start stock",
				FontSize = 20,
				//VerticalTextAlignment = TextAlignment.Center,
				IsVisible = true
			};

			stocklistview.ItemSelected += (sender, e) =>
			{
				if (stocklistview.SelectedItem != null)
				{

					var todoItem = (DynamLists)e.SelectedItem;

					DateTime ate = todoItem.Date;
					dynamdate = ate;
					Functions.getItemListbyDate(ate);

					Navigation.PushAsync(new StockUpdate());

				}
				stocklistview.SelectedItem = null;

			};

		}

		//async void ListClick(object sender, EventArgs args)
		//{
		//	await Navigation.PushAsync(new StockContentPage());
		//}



		void OnDelete(object sender, EventArgs e)
		{
			var selected = (MenuItem)sender;
			var selectedItem = selected.CommandParameter as DynamLists;
			//DisplayAlert("Delete", $"item {selectedItem.Date}", "OK");
			App.Database.DeleteStock(selectedItem.Date);
			App.Database.GetDynamListByStockDate();
			stocklistview.ItemsSource = Data.DynamList;

		}
	}
}

