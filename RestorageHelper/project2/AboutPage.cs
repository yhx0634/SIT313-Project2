using System;
using Xamarin.Forms;

namespace project2
{
	public class AboutPage: ContentPage
	{
		public AboutPage()
		{
			Title = "About";

			//StackLayout layout = new StackLayout();
			//layout.HeightRequest = 110;
			//layout.VerticalOptions = LayoutOptions.Center;
			//layout.Padding = 5;

			var grid = new Grid { RowSpacing = 1, ColumnSpacing = 10 };

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(130) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });


			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50)});

			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				Aspect = Aspect.AspectFit,
				Margin = new Thickness(0, 20, 0, 0),
				HeightRequest = 80
			};
			image.Source = ImageSource.FromResource("project2.icon-Logo.png");


			var appName = new Label
			{	
				HorizontalOptions = LayoutOptions.Center,
				Text = "Re-Storge Helper",
				FontSize = 26
			};

			var subAppName = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				Text = "For Pacific Fish & Chips",
				FontSize = 18
			};

			var veision = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				Text = "Veision 1.2(beta)",
				FontSize = 12
			};

			var developerInfoLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				Text = "Developer:",
				FontSize = 12
			};

			var developerName01 = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End,
				Text = "HONGXING YOU (Sam)",
				FontSize = 12
			};

			var developerName02 = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End,
				Text = "YIBING XIE (Randy)",
				FontSize = 12
			};

			var developerName03 = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End,
				Text = "LIYUE CHEN (Reo)",
				FontSize = 12
			};

			var feedbackbutton = new Button
			{ 
				HeightRequest = 10,
				//Margin = new Thickness(0, 10, 0, 0),
				HorizontalOptions = LayoutOptions.Center,Text = "FeedBack" 
			};
			feedbackbutton.Clicked += (sender, e) =>
		   {
			   Navigation.PushAsync(new FeedBackContentPage());
		   };


			grid.Children.Add(image, 0, 0);
			grid.Children.Add(appName, 0, 1);
			grid.Children.Add(subAppName, 0, 2);
			grid.Children.Add(veision, 0, 3);


			grid.Children.Add(developerInfoLabel, 0, 4);
			grid.Children.Add(developerName01, 0, 5);
			grid.Children.Add(developerName02, 0, 6);
			grid.Children.Add(developerName03, 0, 7);


			grid.Children.Add(feedbackbutton, 0, 8);


			Content = grid;


		}
	}
}
