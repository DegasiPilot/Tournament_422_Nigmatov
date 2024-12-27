using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Логика взаимодействия для AddEditTournament.xaml
	/// </summary>
	public partial class AddEditTournament : Page
	{
		private Tournament _tournament;
		private TimeSpan _time;

		public AddEditTournament(Tournament tournament)
		{
			InitializeComponent();
			GameCb.ItemsSource = App.db.Game.ToList();
			FormatCb.ItemsSource = App.db.TournamentFormat.ToList();
			if(tournament == null)
			{
				TitleTb.Text = "Создание турнира";
				_tournament = new Tournament();
			}
			else
			{
				TitleTb.Text = "Редактирование турнира";
				_tournament = tournament;
			}
			EventDateDb.DisplayDateStart = DateTime.Now.Date;
			this.DataContext = _tournament;
		}

		private void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(_tournament.Name))
			{
				MessageBox.Show("Введите название турнира");
			}
			else if(_tournament.DateOfEvent == null)
			{
				MessageBox.Show("Выберите дату");
			}
			else if (TimeTB.Background == Brushes.Red)
			{
				MessageBox.Show("Введите время в формате чч:мм");
			}
			else if (_tournament.Game == null)
			{
				MessageBox.Show("Выберите игру");
			}
			else if (_tournament.TournamentFormat == null)
			{
				MessageBox.Show("Выберите формат");
			}
			else if (_tournament.MembersAmount == null || _tournament.MembersAmount < 2)
			{
				MessageBox.Show("Количество участников должно быть больше 2");
			}
			else if (_tournament.PrizeFund == null || _tournament.PrizeFund < 1)
			{
				MessageBox.Show("Призовой фонд должен быть больше 0");
			}
			else
			{
				_tournament.DateOfEvent = _tournament.DateOfEvent.Value + _time;
				_tournament.TurnirStatus = App.db.TurnirStatus.First();
				_tournament = App.db.Tournament.Add(_tournament);
				App.db.TournamentOrganizator.Add(new TournamentOrganizator() { Organizator = App.CurrentOrganizator, Tournament = _tournament });
				App.db.SaveChanges();
				MessageBox.Show("Турнир добавлен!");
				App.MainFrame.GoBack();
			}
		}

		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text[0]))
			{
				e.Handled = true;
			}
        }

		private void TimeTB_TextChanged(object sender, TextChangedEventArgs e)
		{
			ValidateTime(TimeTB, out _time);
		}

		private void ValidateTime(TextBox timeText, out TimeSpan timeSpan)
		{
			timeSpan = TimeSpan.Zero;
			Regex time = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
			if (time.IsMatch(timeText.Text))
			{
				timeSpan = new TimeSpan(int.Parse(timeText.Text.Split(':')[0]), int.Parse(timeText.Text.Split(':')[1]), 0);
				timeText.Background = Brushes.LightGreen;
			}
			else
				timeText.Background = Brushes.Red;
		}
	}
}
