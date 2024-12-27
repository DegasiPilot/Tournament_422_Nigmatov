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
using System.Windows.Shapes;
using Tournament_422_Nigmatov.Pages;

namespace Tournament_422_Nigmatov.Windowses
{

	/// <summary>
	/// Логика взаимодействия для LogRegWindow.xaml
	/// </summary>
	public partial class LogRegWindow : Window
	{
		public static Frame LoginRegFrame;

		public LogRegWindow()
		{
			InitializeComponent();
			LoginRegFrame = LogRegFrame;
			LogRegFrame.Navigate(new LoginPage(this));
		}
	}
}
