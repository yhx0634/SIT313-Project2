using Xamarin.Forms;
using System;
namespace project2
{
	public partial class App : Application
	{

		static DataBaseFunction database;
		public static DataBaseFunction Database
		{
			get
			{
				if (database == null)
				{
					database = new DataBaseFunction();
				}
				return database;
			}
		}


		public App()
		{
			InitializeComponent();

			var tabs = new TabbedPage();
			if (Device.OS == TargetPlatform.Android)
			{
				tabs.Children.Add(new NavigationPage(new StockListPage() { Title = "Stock" })
				{

					Title = "Stock",
					//Icon = "SockIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
				);
				tabs.Children.Add(new NavigationPage(new ReorderListPage() { Title = "Order" })
				{
					Title = "Order",
					//Icon = "OrderIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
				 );
				tabs.Children.Add(new NavigationPage(new ItemListPage() { Title = "Item List" })
				{
					Title = "Item",
					//Icon = "ListIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
				 );
				tabs.Children.Add(new NavigationPage(new AccountPage() { Title = "Setting" })
				{
					Title = "Setting",
					//Icon = "SettingsIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
				 );
			}

			if (Device.OS == TargetPlatform.iOS)
			{
				tabs.Children.Add(new NavigationPage(new StockListPage() { Title = "Stock" })
				{

					Title = "Stock",
					Icon = "SockIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
			);
				tabs.Children.Add(new NavigationPage(new ReorderListPage() { Title = "Order" })
				{
					Title = "Order",
					Icon = "OrderIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
				 );
				tabs.Children.Add(new NavigationPage(new ItemListPage() { Title = "Item List" })
				{
					Title = "Item List",
					Icon = "ListIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
				 );
				tabs.Children.Add(new NavigationPage(new AccountPage() { Title = "Setting" })
				{
					Title = "Setting",
					Icon = "SettingsIcon.png",
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#2B84D3")
				}
				 );
			}


			MainPage = tabs;

			//App.database.GetSupplierListTest();
		}

		public int ResumeAtItemsID { get; set;}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

