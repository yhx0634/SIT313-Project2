using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace project2
{
	public partial class ItemListPage : ContentPage
	{
		
		public ItemListPage()
		{
			InitializeComponent();



			//this.ToolbarItems.Add(new ToolbarItem { Text = "Add+" });

			App.Database.GetListofItemsListTest();
			itemlistview.ItemsSource = Data.ListofItemList;

			#region toolbar
			ToolbarItem tbi = null;
			if (Device.OS == TargetPlatform.iOS)
			{
				tbi = new ToolbarItem("Add", null, () =>
					{
					var todoItem = new SupplierList();
					var todoPage = new CreateListName();
						todoPage.BindingContext = todoItem;
						Navigation.PushAsync(todoPage);
					}, 0, 0);
			}
			if (Device.OS == TargetPlatform.Android)
			{ // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem("Add", "plus", () =>
				{
					var todoItem = new SupplierList();
					var todoPage = new CreateListName();
					todoPage.BindingContext = todoItem;
					Navigation.PushAsync(todoPage);
				}, 0, 0);
			}

			ToolbarItems.Add(tbi);
			#endregion
			itemlistview.ItemSelected += (sender, e) =>
			{
				
					itemlistview.SelectedItem = null;

			};


		}



		void OnDelete(object sender, EventArgs e)
		{
			var selected = (MenuItem)sender;
			var selectedItem = selected.CommandParameter as ListofItemList;

			App.Database.DeleteItemList(selectedItem.ID);
			App.Database.DeleteListOfItemList(selectedItem.ID);
			App.Database.GetListofItemsListTest();
			itemlistview.ItemsSource = Data.ListofItemList;
		}


	}
}

