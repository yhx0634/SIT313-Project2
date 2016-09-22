using System;
using Xamarin.Forms;
namespace project2
{
	public class StockListChoose : ContentPage
	{
		ListView ListView;

		public StockListChoose()
		{

			var layout = new StackLayout();
			//var addButtonLayout = new StackLayout();


			Title = "Choose list";

			this.ToolbarItems.Add(new ToolbarItem("Next", "", () =>
			 {
				 App.Database.SaveSupplierTest();
				 Navigation.PushAsync(new CreateItemList());
			 }));

			ListView = new ListView();
			//supplierListView.RowHeight = 30;
			ListView.ItemTemplate = new DataTemplate
				(typeof(ItemCell));

			ListView.ItemSelected += (sender, e) =>
			{
				
				var todoItem = (ListofItemList)e.SelectedItem;

				int id = todoItem.ID;

				Functions.getItemListbyid(id);

				Navigation.PushAsync(new StockContentPage());
			};



			layout.Children.Add(ListView);

			layout.VerticalOptions = LayoutOptions.Start;

			Content = layout;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			// reset the 'resume' id, since we just want to re-start here
			//((App)App.Current).ResumeAtTodoId = -1;

			App.Database.GetListofItemsListTest();

			ListView.ItemsSource = Data.ListofItemList;
		}
	}
}

