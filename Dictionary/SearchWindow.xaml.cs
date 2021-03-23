using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            textBoxSearch.TextChanged += new TextChangedEventHandler(TextBoxSearch_TextChanged);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxSearch.Items.Add("*all categories");
            HashSet<string> categories = new HashSet<string>();
            foreach (Word word in MyDictionary.Words)
            {
                if (!comboBoxSearch.Items.Contains(word.Category))
                    comboBoxSearch.Items.Add(word.Category);
                categories.Add(word.Category);
            }
        }

        private void ComboBoxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSearch.SelectedItem != null)
            {
                textBoxSearch.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedString = textBoxSearch.Text;
            List<Word> autoList = new List<Word>();
            autoList.Clear();

            foreach (var word in MyDictionary.Words)
            {
                if (!string.IsNullOrEmpty(textBoxSearch.Text))
                {
                    if (comboBoxSearch.SelectedItem != null)
                    {
                        if (word.Name.StartsWith(typedString))
                        {
                            if (comboBoxSearch.SelectedItem.Equals("*all categories") || word.Category.Equals(comboBoxSearch.SelectedItem.ToString()))
                            {
                                autoList.Add(word);
                            }
                        }
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

        private void ListBoxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxSearch.ItemsSource != null)
            {
                listBoxSearch.Visibility = Visibility.Collapsed;
                textBoxSearch.TextChanged -= new TextChangedEventHandler(TextBoxSearch_TextChanged);
                if (listBoxSearch.SelectedIndex != -1)
                {
                    textBoxSearch.Text = listBoxSearch.SelectedItem.ToString();
                }
                textBoxSearch.TextChanged += new TextChangedEventHandler(TextBoxSearch_TextChanged);
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
