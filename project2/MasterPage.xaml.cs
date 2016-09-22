using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace project2
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			InitializeComponent();
			if (Device.OS == TargetPlatform.iOS)
			{
				Icon = new FileImageSource
				{
					File = "buttonMenu.png"
				};
			}

		}

		async void HomePage_Clicked(object sender, EventArgs args)
		{
			ItemListPage newPage = new ItemListPage();

			await Navigation.PushModalAsync(newPage);
		}

		async void ItemList_Clicked(object sender, EventArgs args)
		{
			ItemListPage newPage = new ItemListPage();

			await Navigation.PushModalAsync(newPage);
		}

		async void StockManage_Clicked(object sender, EventArgs args)
		{
			ItemListPage newPage = new ItemListPage();

			await Navigation.PushModalAsync(newPage);
		}

		async void ReorderManage_Clicked(object sender, EventArgs args)
		{
			ItemListPage newPage = new ItemListPage();

			await Navigation.PushModalAsync(newPage);
		}

		async void StaffManage_Clicked(object sender, EventArgs args)
		{
			ItemListPage newPage = new ItemListPage();

			await Navigation.PushModalAsync(newPage);
		}

		async void AccountSetting_Clicked(object sender, EventArgs args)
		{
			ItemListPage newPage = new ItemListPage();

			await Navigation.PushModalAsync(newPage);
		}

	}
}

