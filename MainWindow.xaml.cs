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
using Tournament_422_Nigmatov.Pages;
using Tournament_422_Nigmatov.Windowses;

namespace Tournament_422_Nigmatov
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			App.MainFrame = MainFrame;
			Window window = new LogRegWindow();
			if(window.ShowDialog() != true)
			{
				Application.Current.Shutdown();
			}
			RoleTb.Text = App.CurrentRole;
			TournamentBtn.Visibility = App.CurrentRole == App.OrganiztorName ? Visibility.Visible : Visibility.Collapsed;
			MainFrame.Navigate(new HomePage());
		}

		private void TournamentBtn_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new AddEditTournament(null));
		}
	}
}
