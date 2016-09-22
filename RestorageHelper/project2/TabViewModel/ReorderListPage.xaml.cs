using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace project2
{
	public partial class ReorderListPage : ContentPage
	{
		public static DateTime reorderdynamdate { get; set; }
		public static DateTime orderupdatedynamdate { get; set; }

		public ReorderListPage()
		{
			InitializeComponent();
			App.Database.GetDynamListByStockDate();
			App.Database.GetDynamListByOrderTime();
			orderlistview.ItemsSource = Data.DynamListForOrder;

			this.ToolbarItems.Add(new ToolbarItem("Add", "", () =>
			 {
				Navigation.PushAsync(new StockListForOrderPage());
			 }));


			orderlistview.ItemSelected += (sender, e) =>
			{
				if (orderlistview.SelectedItem != null)
				{
					var todoItem = (DynamListForOrder)e.SelectedItem;

					DateTime ate = todoItem.Date;
					reorderdynamdate = ate;
					orderupdatedynamdate = todoItem.StockDate;
					Functions.getItemListbyOrderDate(ate);

					Navigation.PushAsync(new OrderUpdatePage());

				}

				orderlistview.SelectedItem = null;

			};
		}





		void OnDelete(object sender, EventArgs e)
		{
			var selected = (MenuItem)sender;
			var selectedItem = selected.CommandParameter as DynamListForOrder;
			App.Database.DeleteOrder(selectedItem.Date);
			App.Database.GetDynamListByOrderTime();
			orderlistview.ItemsSource = Data.DynamListForOrder;
		}
	}
}

