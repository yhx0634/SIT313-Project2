using Xamarin.Forms;
using System;

namespace project2
{
	public partial class project2Page : ContentPage
	{
		public project2Page()
		{
			InitializeComponent();
		}


		async void StockLsit_Clicked(object sender, EventArgs args)
		{
			StockListPage newPage = new StockListPage();

			await Navigation.PushAsync(newPage);
		}
	}
}

