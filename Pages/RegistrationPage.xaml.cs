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
using Tournament_422_Nigmatov.DB;
using Tournament_422_Nigmatov.Windowses;

namespace Tournament_422_Nigmatov.Pages
{
	/// <summary>
	/// Логика взаимодействия для RegistrationPage.xaml
	/// </summary>
	public partial class RegistrationPage : Page
	{
		LogRegWindow _myWindow;
		Player _player;

		public RegistrationPage(LogRegWindow myWindow)
		{
			InitializeComponent();
			_myWindow = myWindow;
			_player = new Player();
			DataContext = _player;
			TeamCb.ItemsSource = App.db.Team.ToList();
			RoleCb.ItemsSource = App.db.TeamRole.ToList();
		}

		private void ToEnterBtn_Click(object sender, RoutedEventArgs e)
		{
			_myWindow.LogRegFrame.Navigate(new LoginPage(_myWindow));
		}

		private void RegBtn_Click(object sender, RoutedEventArgs e)
		{
			_player.Password = PasswordPb.Password;
			if (string.IsNullOrEmpty(_player.Login))
			{
				MessageBox.Show("Введите логин");
			}
			else if (string.IsNullOrEmpty(_player.Password))
			{
				MessageBox.Show("Введите пароль");
			}
			else if (string.IsNullOrEmpty(_player.Nickname))
			{
				MessageBox.Show("Введите ник");
			}
			else if (_player.Team != null && _player.TeamRole == null)
			{
				MessageBox.Show("Выберите роль в команде");
			}
			else
			{
				_player = App.db.Player.Add(_player);
				App.db.SaveChanges();
				App.CurrentPlayer = _player;
				_myWindow.DialogResult = true;
				_myWindow.Close();
			}
		}

		private void CreateTeamBtn_Click(object sender, RoutedEventArgs e)
		{
			_myWindow.LogRegFrame.Navigate(new AddEditTeam(_myWindow.LogRegFrame, this));
		}

		public void UpdateTeam(Team team)
		{
			TeamCb.ItemsSource = App.db.Team.ToList();
			TeamCb.SelectedItem = team;
		}
	}
}
