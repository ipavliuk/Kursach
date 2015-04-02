using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RentAppartment.Client.Utils
{
	public class BitmapImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string)
				return new BitmapImage(new Uri((string)"C\\untitled.png", UriKind.RelativeOrAbsolute));

			if (value is Uri)
				return new BitmapImage((Uri)value);

			throw new NotSupportedException();

			//var image = new BitmapImage();
			//int BytesToRead = 100;

			//WebRequest request = WebRequest.Create(new Uri((string)value, UriKind.Absolute));
			//request.Timeout = -1;
			//request.Credentials = CredentialCache.DefaultNetworkCredentials;
			//WebResponse response = request.GetResponse();
			//Stream responseStream = response.GetResponseStream();
			//BinaryReader reader = new BinaryReader(responseStream);
			//MemoryStream memoryStream = new MemoryStream();

			//byte[] bytebuffer = new byte[BytesToRead];
			//int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

			//while (bytesRead > 0)
			//{
			//	memoryStream.Write(bytebuffer, 0, bytesRead);
			//	bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
			//}

			//image.BeginInit();
			//memoryStream.Seek(0, SeekOrigin.Begin);

			//image.StreamSource = memoryStream;
			//image.EndInit();

			//return image;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
