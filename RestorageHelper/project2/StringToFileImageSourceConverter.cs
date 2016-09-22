using System;
using System.Globalization;
using Xamarin.Forms;

namespace project2
{
	public class StringToFileImageSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var filePathString = (string)value;
			if (!string.IsNullOrEmpty(filePathString))
			{
				return ImageSource.FromFile(filePathString);
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
