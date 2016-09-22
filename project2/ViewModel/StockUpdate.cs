using System;
using Xamarin.Forms;
namespace project2
{
	public class StockUpdate : ContentPage
	{

		ListView listView;

		public StockUpdate()
		{
			Title = "Stock";

			this.ToolbarItems.Add(new ToolbarItem("Save", "", () =>
			 {
				
				App.Database.GetStockListTest();
				Functions.updateStockList(StockListPage.dynamdate);
				 App.Database.UpdateStockTest();
				 Navigation.PopToRootAsync();
			 }));


			listView = new ListView();
			listView.RowHeight = 100;
			listView.ItemTemplate = new DataTemplate
				(typeof(StockCell));

			var layout = new StackLayout();


			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			// reset the 'resume' id, since we just want to re-start here
			//((App)App.Current).ResumeAtTodoId = -1;
			listView.ItemsSource = Data.ItemList;
		}

	}
}

