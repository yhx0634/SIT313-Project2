using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace project2
{
	public class CreateSupplier : ContentPage
	{
		ListView supplierListView;


		public CreateSupplier()
		{
			

			var layout = new StackLayout();
			//var addButtonLayout = new StackLayout();




			Title = "Supplier Set";

			this.ToolbarItems.Add(new ToolbarItem("Next", "", () =>
			 {
				 App.Database.SaveSupplierTest();

				 Navigation.PushAsync(new CreateItemList());
			 }));

			supplierListView = new ListView();
			//supplierListView.RowHeight = 30;
			supplierListView.ItemTemplate = new DataTemplate
				(typeof(SupplierCell));



			layout.Children.Add(supplierListView);

			layout.VerticalOptions = LayoutOptions.Start;

			Content = layout;

		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			// reset the 'resume' id, since we just want to re-start here
			//((App)App.Current).ResumeAtTodoId = -1;

			App.Database.GetSupplierListTest();
			if (Data.SupplierList.Count == 0)
			{
				Data.SupplierList.Add(new SupplierList() { SupplierName = "" });
			}
			
			supplierListView.ItemsSource = Data.SupplierList;
		}

	}
}

