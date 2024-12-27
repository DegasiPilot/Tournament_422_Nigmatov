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

namespace Tournament_422_Nigmatov.Pages
{
	/// <summary>
	/// Логика взаимодействия для AddEditTeam.xaml
	/// </summary>
	public partial class AddEditTeam : Page
	{
		Frame _frame;
		RegistrationPage _regPage;
		Team _team;

		public AddEditTeam(Frame frame, RegistrationPage regPage)
		{
			InitializeComponent();
			_frame = frame;
			_regPage = regPage;
			_team = new Team();
			DataContext = _team;
		}

		private void GoBackBtn_Click(object sender, RoutedEventArgs e)
		{
			_frame.GoBack();
        }

		private void EnterBtn_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(_team.Name))
			{
				MessageBox.Show("Введите название команды");
				return;
			}
			_team = App.db.Team.Add(_team);
			App.db.SaveChanges();
			if(_regPage != null)
			{
				_regPage.UpdateTeam(_team);
			}
			_frame.GoBack();
        }
    }
}
