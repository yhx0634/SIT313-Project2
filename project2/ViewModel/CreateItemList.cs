using System;
using Xamarin.Forms;
namespace project2
{
	public class CreateItemList : ContentPage
	{

		ListView listView;


		public CreateItemList()
		{
			var layout = new StackLayout();


			Title = "New Item List";

			this.ToolbarItems.Add(new ToolbarItem("Save", "", () =>
			 {
				App.Database.SaveItemTest();
				//App.Database.SaveListTest();

				 Navigation.PopToRootAsync();
			 }));

			listView = new ListView();
			listView.RowHeight = 120;
			listView.ItemTemplate = new DataTemplate
				(typeof(ItemListCell));


			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.Start;
			Content = layout;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//App.Database.GetItemsListTest();
			if (Data.ItemList.Count == 0)
			{
				Data.ItemList.Add(new ItemsList() { ItemsName = "", ItemsUnit = "", ItemsImage = "", SupplierName = ""});
			}

			listView.ItemsSource = Data.ItemList;
		}
	}
}

