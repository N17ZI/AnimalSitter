using AnimalSitter.Class;
using System;
using System.Collections.Generic;
using System.Data;
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
	public partial class AddSitter : Page
	{
		public AddSitter()
		{
			InitializeComponent();
		}

		private void Send_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				

				if (/*!ConnectionDB.AnimalSittersEntities.Listining.Any(u => u.Id_user == ConnectionDB.current_id)*/Name.Text!=null)
				{
					Listining newListining = new Listining
					{
						Name = Name.Text,
						Text = Desc.Text,
						Experience = Convert.ToInt32(Stage.Text),
						Id_user= ConnectionDB.current_id,
					};

					ConnectionDB.AnimalSittersEntities.Listining.Add(newListining);
					ConnectionDB.AnimalSittersEntities.SaveChanges();

					NavigationService.Navigate(new Main());
				}
			}
			catch
			{
			}

        }

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}
