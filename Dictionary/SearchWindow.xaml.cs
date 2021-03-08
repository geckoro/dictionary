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

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            textBoxSearch.TextChanged += new TextChangedEventHandler(textBoxSearch_TextChanged);
        }

        private void SearchWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedString = textBoxSearch.Text;
            List<Word> autoList = new List<Word>();
            autoList.Clear();

            foreach (var word in ((App)Application.Current).Words)
            {
                if (!string.IsNullOrEmpty(textBoxSearch.Text))
                {
                    if (word.Name.StartsWith(typedString))
                    {
                        autoList.Add(word);
                    }
                }
            }

            if (autoList.Count > 0)
            {
                listBoxSearch.ItemsSource = autoList;
                listBoxSearch.Visibility = Visibility.Visible;
            }
            else if (textBoxSearch.Text.Equals(""))
            {
                listBoxSearch.Visibility = Visibility.Collapsed;
                listBoxSearch.ItemsSource = null;
            }
            else
            {
                listBoxSearch.Visibility = Visibility.Collapsed;
                listBoxSearch.ItemsSource = null;
            }
        }

        private void listBoxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxSearch.ItemsSource != null)
            {
                listBoxSearch.Visibility = Visibility.Collapsed;
                textBoxSearch.TextChanged -= new TextChangedEventHandler(textBoxSearch_TextChanged);
                if (listBoxSearch.SelectedIndex != -1)
                {
                    textBoxSearch.Text = listBoxSearch.SelectedItem.ToString();
                }
                textBoxSearch.TextChanged += new TextChangedEventHandler(textBoxSearch_TextChanged);
            }
        }

        private void ButtonClickMenu(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void WordImage_OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri(@"D:\FACULT 2020-2021\MVP\Dictionary\Dictionary\Resources\noimage.png"));
        }
    }
}
