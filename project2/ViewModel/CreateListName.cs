using System;
using Xamarin.Forms;
namespace project2
{
	public class CreateListName : ContentPage
	{
		public CreateListName()
		{

			var layout = new StackLayout();



			Title = "New Item List";

			Data.ItemList.Clear();

			var Lable1 = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Margin = new Thickness(0, 50, 0 , 20),
				Text = "Please set a list name",
				FontSize = 20
			};




			var listNameInput = new Entry
			{
				Text ="List Name",
				HeightRequest = 50,
				Margin = new Thickness(20,0,20,0)
			};

			layout.Children.Add(Lable1);
			layout.Children.Add(listNameInput);


			this.ToolbarItems.Add(new ToolbarItem("Next", "", () =>
			 {
				Data.ListofItemList.Add(new ListofItemList() { ListName = listNameInput.Text });
				App.Database.SaveListTest();

				 Navigation.PushAsync(new CreateSupplier());
			 }));


		
			layout.VerticalOptions = LayoutOptions.Start;
			Content = layout;

		}

		//protected override void OnAppearing()
		//{
		//	base.OnAppearing();
		//	//App.Database.GetItemsListTest();
		//	if (Data.ListofItemList.Count == 0)
		//	{
		//		Data.ListofItemList.Add(new ListofItemList() { ListName = "" });
		//	}


		//}
	}
}

