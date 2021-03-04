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

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void ButtonClickAdmin(object sender, RoutedEventArgs e)
        {
            AdministrationWindow window = new AdministrationWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            SearchWindow window = new SearchWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClickEntertainment(object sender, RoutedEventArgs e)
        {
            EntertainmentWindow window = new EntertainmentWindow();
            window.Show();
            this.Close();
        }
    }
}
