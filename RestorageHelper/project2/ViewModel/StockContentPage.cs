using System;
using Xamarin.Forms;
namespace project2
{
	public class StockContentPage : ContentPage
	{
		
		ListView listView;


		public StockContentPage()
		{
			Title = "Stock";

			this.ToolbarItems.Add(new ToolbarItem("Save", "", () =>
			 {
				Functions.setStockList();
				App.Database.SaveStockTest();
				App.Database.GetDynamListByStockDate();
				 Navigation.PopToRootAsync();
			 }));


			listView = new ListView();
			listView.RowHeight = 100;
			listView.ItemTemplate = new DataTemplate
				(typeof(StockCell));

			//this.ToolbarItems.Add(new ToolbarItem("Save", "", () =>
			// {
			//	Functions.setStockList();

			//	App.Database.SaveStockTest();
			//	App.Database.GetItemsListByStockDate();

			

			//	 Navigation.PopToRootAsync();
			// }));

			//Functions.setQuality();

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

