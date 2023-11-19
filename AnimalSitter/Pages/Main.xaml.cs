using System;
using System.Collections.Generic;
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
	public partial class Main : Page
	{
		public Main()
		{
			InitializeComponent();
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
