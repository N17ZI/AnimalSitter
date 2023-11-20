using AnimalSitter.Class;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ZXing;


namespace AnimalSitter.Pages
{
	public partial class ListSitter : Page
	{

		public ListSitter()
		{
			InitializeComponent();
			List<Listining> animals = ConnectionDB.AnimalSittersEntities.Listining.ToList();

			animalListBox.ItemsSource = animals;
		}

		private void ShowContactButton_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Button button && button.Tag is int Id_user)
			{
				User foundUser = ConnectionDB.AnimalSittersEntities.User.FirstOrDefault(u => u.Id_user == Id_user);

				if (foundUser != null)
				{
					string contactInfo = $"Name: {foundUser.Name}\nEmail: {foundUser.Email}";

					QRCodeWindow qrCodeWindow = new QRCodeWindow(contactInfo);
					qrCodeWindow.ShowDialog();
				}
				else
				{
					MessageBox.Show("Пользователь не найден.");
				}
			}
		}
		private void Main_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Main());
		}
		private void Listining_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new ListSitter());
		}
		private void Profile_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Profile());
		}
		private void AddSitter_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddSitter());
		}
	}
}

