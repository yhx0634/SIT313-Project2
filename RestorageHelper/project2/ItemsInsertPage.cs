using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Media;

namespace project2
{
	public class ItemsInsertPage : ContentPage
	{
		
		public ItemsInsertPage()
		{
			
			// for items add
			this.SetBinding(TitleProperty, "Items");
			NavigationPage.SetHasNavigationBar(this, true);

			var image = new Image { HeightRequest = 60 };
			var imagePicker = new Button{Text = "Image"};
			var image2 = new Image { HeightRequest = 60 };
			var imageEntry = new Entry();
			//imageEntry.IsVisible = false;
			string xx = "";

			imagePicker.Clicked += async (sender, args) =>
			{
				if (!CrossMedia.Current.IsPickPhotoSupported)
				{
					await DisplayAlert("Not Pick", "pick again", "ok");
					return;
				}
				var file = await CrossMedia.Current.PickPhotoAsync();
				if (file == null)
				{
					return;
				}
				image.Source = ImageSource.FromStream(() =>
				{
					var stream = file.GetStream();
					xx = file.Path;


					System.Diagnostics.Debug.WriteLine(xx);
					file.Dispose();
					return stream;
				});
				imageEntry.Text = xx;
				//imageEntry.Text = image.Source.Id.ToString();
				image2.Source = ImageSource.FromUri(new Uri(xx));
			};
			imageEntry.SetBinding(Entry.TextProperty, "ItemsImage");




			//imageEntry.SetBinding(Entry.TextProperty, "ItemsImage");


			var nameLabel = new Label { Text = "Name" };
			var nameEntry = new Entry();
			nameEntry.SetBinding(Entry.TextProperty, "ItemsName");

			var unitLabel = new Label { Text = "Unit" };
			var unitEntry = new Entry();
			unitEntry.SetBinding(Entry.TextProperty, "ItemsUnit");

			var supplierLabel = new Label { Text = "Supplier" };
			var supplierPicker = new Picker
			{
				Title = "Supplier",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			foreach (SupplierList sl in App.Database.GetSuppilerToItemsList())
			{
				supplierPicker.Items.Add(sl.SupplierName);
			}
			supplierPicker.SelectedIndexChanged += (sender, e) =>
			{
				if (supplierPicker.SelectedIndex == -1)
				{
					// error message
				}
				else
				{
					supplierPicker.SetBinding(Picker.SelectedIndexProperty, "SupplierName");
				}
			};


			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) =>
			{
				var itemsList = (ItemsList)BindingContext;
				App.Database.SaveItem(itemsList);
				this.Navigation.PopAsync();
			};

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					image, image2, imagePicker, imageEntry,
					nameLabel, nameEntry,
					unitLabel, unitEntry,
					supplierLabel, supplierPicker,
					saveButton
				}
			};
		}


	}
}
