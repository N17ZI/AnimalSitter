using AnimalSitter.Pages;
using System.Windows;


namespace AnimalSitter
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			MyFrame.Content = new LogIn();
		}
	}
}
