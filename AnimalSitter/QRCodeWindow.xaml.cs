using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using ZXing;

namespace AnimalSitter
{
	public partial class QRCodeWindow : Window
	{
		public QRCodeWindow(string contactInfo)
		{
			InitializeComponent();
			GenerateQRCode(contactInfo);
		}

		private void GenerateQRCode(string contactInfo)
		{
			// Создаем объект кодировщика QR-кода
			BarcodeWriter barcodeWriter = new BarcodeWriter();
			barcodeWriter.Format = BarcodeFormat.QR_CODE;

			// Создаем изображение QR-кода
			ZXing.Common.BitMatrix bitMatrix = barcodeWriter.Encode(contactInfo);

			// Создаем изображение из данных пикселей
			Bitmap bitmap = new Bitmap(bitMatrix.Width, bitMatrix.Height);
			for (int x = 0; x < bitMatrix.Width; x++)
			{
				for (int y = 0; y < bitMatrix.Height; y++)
				{
					bitmap.SetPixel(x, y, bitMatrix[x, y] ? System.Drawing.Color.Black : System.Drawing.Color.White);
				}
			}

			// Преобразуем Bitmap в BitmapImage
			BitmapImage bitmapImage = ConvertBitmapToBitmapImage(bitmap);

			// Отображаем изображение в Image в WPF
			qrCodeImage.Source = bitmapImage;
		}

		private BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
				memoryStream.Position = 0;

				BitmapImage bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memoryStream;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();

				return bitmapImage;
			}
		}
	}
}
