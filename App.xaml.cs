using System.Windows;
using System.Windows.Controls;
using Tournament_422_Nigmatov.DB;

namespace Tournament_422_Nigmatov
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static Frame MainFrame;

		public const string OrganiztorName = "Организатор";
		public const string PlayerName = "Участник";
		public const string ViewerName = "Зритель";
		public readonly static string[] Roles = new string[] { OrganiztorName, PlayerName };
		public static string CurrentRole;

		public static readonly Tournament_Entities db = new Tournament_Entities();

		public static Organizator CurrentOrganizator 
		{ 
			get => currentOrganizator;
			set
			{
				currentPlayer = null;
				currentOrganizator = value;
				CurrentRole = OrganiztorName;
			}
		}
		private static Organizator currentOrganizator;

		public static Player CurrentPlayer 
		{
			get => currentPlayer;
			set
			{
				currentOrganizator = null;
				currentPlayer = value;
				CurrentRole = PlayerName;
			}
		}
		private static Player currentPlayer;
	}
}
