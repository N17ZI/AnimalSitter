using AnimalSitter.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimalSitter.Pages
{
	public partial class Profile : Page
	{
		public Profile()
		{
			InitializeComponent();
			LoadUserProfiles(ConnectionDB.current_id);
			Start(ConnectionDB.current_id);
		}
		public void Start(int id)
		{
			User user = ConnectionDB.AnimalSittersEntities.User.FirstOrDefault(x => x.Id_user == id);
			if (user != null)
			{
				Name.Text = user.Name;
				Surname.Text= user.Surname;
				Email.Text= user.Email;
			}
		}
		private ObservableCollection<Listining> userProfiles;

		private void LoadUserProfiles(int userId)
		{
			userProfiles = new ObservableCollection<Listining>(ConnectionDB.AnimalSittersEntities.Listining.Where(x => x.Id_user == ConnectionDB.current_id).ToList());
			profilesListBox.ItemsSource = userProfiles;
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (profilesListBox.SelectedItem != null)
			{
				var selectedProfile = (Listining)profilesListBox.SelectedItem;

				ConnectionDB.AnimalSittersEntities.Listining.Remove(selectedProfile);
				ConnectionDB.AnimalSittersEntities.SaveChanges();

				userProfiles.Remove(selectedProfile);
			}
		}

		private void ProfilesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			User user = ConnectionDB.AnimalSittersEntities.User.FirstOrDefault(x => x.Id_user == ConnectionDB.current_id);
			if (user != null && !ConnectionDB.AnimalSittersEntities.User.Any(u => u.Email == Email.Text))
			{
				user.Email = Email.Text;
				user.Name = Name.Text;
				user.Surname = Surname.Text;

				ConnectionDB.AnimalSittersEntities.SaveChanges();
			}
			else
			{
				MessageBox.Show("Ошибка.");
			}
		}
	}
}
