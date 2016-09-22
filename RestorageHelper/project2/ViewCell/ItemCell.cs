using System;
using Xamarin.Forms;

namespace project2
{
	public class ItemCell: ViewCell
	{
		public ItemCell()
		{
			var label = new Label
			{
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			label.SetBinding(Label.TextProperty, "ListName");



			//var tick = new Image
			//{
			//	Source = FileImageSource.FromFile("check.png"),
			//	HorizontalOptions = LayoutOptions.End
			//};
			//tick.SetBinding(Image.IsVisibleProperty, "Done");

			var layout = new StackLayout
			{
				Padding = new Thickness(20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{ 
					label 
				}
			};

			View = layout;
			}
	}
}
