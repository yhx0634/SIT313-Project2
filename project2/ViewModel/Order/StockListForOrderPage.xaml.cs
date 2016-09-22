using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace project2
{
	public partial class StockListForOrderPage : ContentPage
	{
		public static DateTime oederdynmdate { get; set;}
		public StockListForOrderPage()
		{
			InitializeComponent();

			App.Database.GetDynamListByStockDate();
			stocklistview.ItemsSource = Data.DynamList;

			Title = "sdhsakdhk";

			this.ToolbarItems.Add(new ToolbarItem("Add","", () =>
			{
				Navigation.PushAsync(new OrderContentPage());
			}));



			stocklistview.ItemSelected += (sender, e) =>
			{

				var todoItem = (DynamLists)e.SelectedItem;

				DateTime ate = todoItem.Date;
				oederdynmdate = ate;
				Functions.getItemListbyDate(ate);

				Navigation.PushAsync(new OrderContentPage());
			};

		}

		//async void ListClick(object sender, EventArgs args)
		//{
		//	await Navigation.PushAsync(new StockContentPage());
		//}


		void OnEdit(object sender, EventArgs e)
		{
			var selected = (MenuItem)sender;
			var selectedItem = selected.CommandParameter as StockList;
			DisplayAlert("Edit", $"item {selectedItem.StockDate}", "OK");
		}

		void OnDelete(object sender, EventArgs e)
		{
			var selected = (MenuItem)sender;
			var selectedItem = selected.CommandParameter as StockList;
			DisplayAlert("Delete", $"item {selectedItem.StockDate}", "OK");
		}
	}
}

