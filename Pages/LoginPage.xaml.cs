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
	/// Логика взаимодействия для LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Page
	{
		private readonly LogRegWindow _myWindow;

		public LoginPage(LogRegWindow myWindow)
		{
			InitializeComponent();
			RoleCb.ItemsSource = App.Roles;
			_myWindow = myWindow;
		}

		private void EnterBtn_Click(object sender, RoutedEventArgs e)
		{
			if (RoleCb.SelectedIndex == -1)
			{
				MessageBox.Show("Выберите роль под которой хотите войти");
			}
			else if (string.IsNullOrEmpty(LoginTb.Text))
			{
				MessageBox.Show("Логин пуст");
			}
			else if (string.IsNullOrEmpty(PasswordPb.Password))
			{
				MessageBox.Show("Пароль пуст");
			}
			else
			{
				if((RoleCb.SelectedItem as string) == App.OrganiztorName)
				{
					Organizator organizator = App.db.Organizator.FirstOrDefault(o => o.Login == LoginTb.Text);
					if(organizator == null)
					{
						MessageBox.Show("Нет организатора с таким логином");
					}
					else if(organizator.Password != PasswordPb.Password)
					{
						MessageBox.Show("Неправильный пароль");
					}
					else
					{
						App.CurrentOrganizator = organizator;
						_myWindow.DialogResult = true;
						_myWindow.Close();
					}
				}
				else if ((RoleCb.SelectedItem as string) == App.PlayerName)
				{
					Player player = App.db.Player.FirstOrDefault(p => p.Login == LoginTb.Text);
					if (player == null)
					{
						MessageBox.Show("Нет участника с таким логином");
					}
					else if (player.Password != PasswordPb.Password)
					{
						MessageBox.Show("Неправильный пароль");
					}
					else
					{
						App.CurrentPlayer = player;
						_myWindow.DialogResult = true;
						_myWindow.Close();
					}
				}
			}
		}

		private void ViewerLoginBtn_Click(object sender, RoutedEventArgs e)
		{
			App.CurrentRole = App.ViewerName;
			_myWindow.DialogResult = true;
			_myWindow.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			_myWindow.LogRegFrame.Navigate(new RegistrationPage());
		}
	}
}
