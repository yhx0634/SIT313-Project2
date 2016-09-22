using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace project2
{
	public class ItemsListPage : ContentPage
	{

		ListView listView;
		public ItemsListPage()
		{
			Title = "Todo";


			listView = new ListView();
			listView.ItemTemplate = new DataTemplate
					(typeof(ItemCell));
			
			//listView.ItemSelected += (sender, e) =>
			//{
			//	var todoItem = (ItemsList)e.SelectedItem;
			//	//var todoPage = new ItemsPageX();
			//	todoPage.BindingContext = todoItem;

			//	((App)App.Current).ResumeAtItemsID = todoItem.ItemsID;
			//	Debug.WriteLine("setting ResumeAtTodoId = " + todoItem.ItemsID);

			//	Navigation.PushAsync(todoPage);
			//};

			var layout = new StackLayout();
			if (Device.OS == TargetPlatform.WinPhone)
			{ // WinPhone doesn't have the title showing
				layout.Children.Add(new Label
				{
					Text = "Todo",
					FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
				});
			}
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			#region toolbar
			ToolbarItem tbi = null;
			if (Device.OS == TargetPlatform.iOS)
			{
				tbi = new ToolbarItem("+", null, () =>
					{
					var todoItem = new ItemsList();
					var todoPage = new ItemsInsertPage();
						todoPage.BindingContext = todoItem;
						Navigation.PushAsync(todoPage);
					}, 0, 0);
			}
			if (Device.OS == TargetPlatform.Android)
			{ // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem("+", "plus", () =>
				{
					var todoItem = new ItemsList();
					var todoPage = new ItemsInsertPage();
					todoPage.BindingContext = todoItem;
					Navigation.PushAsync(todoPage);
				}, 0, 0);
			}

			ToolbarItems.Add(tbi);
			#endregion
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			// reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtItemsID = -1;
			listView.ItemsSource = App.Database.GetItemsList();
		}
	}
}
