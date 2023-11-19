using AnimalSitter.Class;
using System.Data.Entity.Validation;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Controls.Primitives;

namespace AnimalSitter.Pages
{

	public partial class SignUp : Page
	{
		public SignUp()
		{
			InitializeComponent();
		}
		string role;
		private void SignUp_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string login = txtLogin.Text;
				string password = txtPassword.Password;
				string Firstname = txtFirstname.Text;
				string Lastname = txtLastName.Text;

				if (!ConnectionDB.AnimalSittersEntities.User.Any(u => u.Email == login))
				{
					User newUser = new User
					{
						Email = login,
						Password = password,
						Role = role,
						Surname = Lastname,
						Name= Firstname,
					};

					ConnectionDB.AnimalSittersEntities.User.Add(newUser);
					ConnectionDB.AnimalSittersEntities.SaveChanges();

					User user = ConnectionDB.AnimalSittersEntities.User.FirstOrDefault(x => x.Email == login);
					ConnectionDB.current_id = user.Id_user;

					NavigationService.Navigate(new Main());
				}
				else
				{
					MessageBox.Show("Пользователь с таким логином уже существует.");
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
			NavigationService.Navigate(new LogIn());
		}
		private void ToggleButton_Checked(object sender, RoutedEventArgs e)
		{
			var clickedButton = (ToggleButton)sender;

			if (clickedButton.IsChecked == true)
			{
				if (clickedButton.Name == "btnOption1")
				{
					btnOption2.IsChecked = false;
				}
				else if (clickedButton.Name == "btnOption2")
				{
					btnOption1.IsChecked = false;
				}
				role = clickedButton.Content.ToString();
			}
		}
	}
}
