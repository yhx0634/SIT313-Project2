using System;
using Xamarin.Forms;

namespace project2
{
	public class FeedBackContentPage :ContentPage
	{
		public FeedBackContentPage()
		{
			Title = "FeedBack";
			var grid = new Grid { RowSpacing = 1, ColumnSpacing = 10 };

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(300) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });


			var feedbackLabel = new Label
			{
				Text = "FeedBack",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12,
				Margin = new Thickness(5,5,5,5)
			};

			var feedbackContent = new Entry
			{
				HeightRequest = 200,
				Placeholder = "Please entry.",
				PlaceholderColor = Color.White,
				BackgroundColor = Color.FromHex("#2c3e50"),
				TextColor = Color.White,
				Margin = new Thickness(5, 5, 5, 5)
			};
			feedbackContent.SetBinding(Entry.TextProperty, "Feedback");

			var submit = new Button
			{
				Text = "Submit",
				FontSize = 24,
				HeightRequest = 90,
				Margin = new Thickness(12, 12, 12, 12)
			};
			submit.Clicked += (sender, e) => 
			{
				DateTime d = System.DateTime.Now;
				//var feedbackList = (FeedBack)BindingContext;
				Data.feedBack.Add(new FeedBack() { Feedback = feedbackContent.Text, time = d});
				App.Database.SaveFeedback();
				Navigation.PopAsync();
			};


			grid.Children.Add(feedbackLabel, 0, 0);

			grid.Children.Add(feedbackContent, 1, 0);
			//Grid.SetRowSpan(feedbackContent, 2);

			grid.Children.Add(submit, 0, 1);
			Grid.SetColumnSpan(submit, 2);

			Content = grid;
		}

	}
}
