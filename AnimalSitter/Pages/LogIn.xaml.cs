using AnimalSitter.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
	public partial class LogIn : Page
	{
		public LogIn()
		{
			InitializeComponent();
		}
		private void Login_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string login = txtLogin.Text;
				string password = txtPassword.Password;
				if (ConnectionDB.AnimalSittersEntities.User.Any(u => u.Email == login && u.Password == password))
				{
					User user = ConnectionDB.AnimalSittersEntities.User.FirstOrDefault(x => x.Email == login);
					ConnectionDB.current_id = user.Id_user;

					NavigationService.Navigate(new Main());
				}
				else
				{
					MessageBox.Show("Неправильный логин или пароль.");
				}
			}
			catch (DbEntityValidationException ex)
			{
				foreach (var validationError in ex.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors))
				{
					Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
				}

				MessageBox.Show("Ошибка валидации сущности. Подробности в консоли.");
			}
		}
		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new SignUp());
		}
	}
}
