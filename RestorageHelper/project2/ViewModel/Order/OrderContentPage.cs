using System;
using Xamarin.Forms;
namespace project2
{
	public class OrderContentPage : ContentPage
	{
		ListView listView;

		public OrderContentPage()
		{
			Title = "New Order";

			this.ToolbarItems.Add(new ToolbarItem("Save", "", () =>
			 {
				Functions.setOrderList();
				App.Database.SaveOrderTest();
				 App.Database.GetDynamListByOrderTime();
				 Navigation.PopToRootAsync();
			 }));



			listView = new ListView();
			listView.RowHeight = 100;
			listView.ItemTemplate = new DataTemplate
				(typeof(OrderCell));


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

