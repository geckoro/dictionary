using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AdministrationWindow.xaml
    /// </summary>

    public partial class AdministrationWindow : Window
    {
        private string path = null;

        public AdministrationWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void AdministrationWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).Words == null) return;

            HashSet<string> categories = new HashSet<string>();
            foreach (Word word in ((App)Application.Current).Words)
            {
                WordsList.Items.Add(word);
                categories.Add(word.Category);
            }

            foreach (string category in categories)
            {
                comboBoxCategory.Items.Add(category);
                comboBoxCategoryModify.Items.Add(category);
            }
        }

        private void HideButtons()
        {
            buttonAdd.Visibility = Visibility.Hidden;
            buttonOther.Visibility = Visibility.Hidden;
        }

        private void ButtonClickMenu(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClickAddNew(object sender, RoutedEventArgs e)
        {
            string wordName = inputName.Text;

            string wordDescription = inputDescription.Text;

            string wordCategory;

            if (checkboxNewCategory.IsChecked != null)
            {
                if ((bool)checkboxNewCategory.IsChecked)
                {
                    wordCategory = inputNewCategory.Text;

                    comboBoxCategory.Items.Add(wordCategory);
                    comboBoxCategoryModify.Items.Add(wordCategory);
                }
                else
                {
                    wordCategory = comboBoxCategory.SelectedItem.ToString();
                }

                var wordImagePath = path;
                if (path == null)
                {
                    Word word = new Word(wordName, wordDescription, wordCategory);
                    ((App)Application.Current).Words.Add(word);
                }
                else
                {
                    Word word = new Word(wordName, wordDescription, wordCategory, wordImagePath);
                    ((App)Application.Current).Words.Add(word);
                }

                AdministrationWindow window = new AdministrationWindow();
                window.Show();
                this.Close();
            }
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            HideButtons();
            addNewWordPanel.Visibility = Visibility.Visible;
        }

        private void ButtonClickOther(object sender, RoutedEventArgs e)
        {
            HideButtons();
            otherPanel.Visibility = Visibility.Visible;
        }

        private void ButtonClickModify(object sender, RoutedEventArgs e)
        {
            modifyWordPanel.Visibility = Visibility.Visible;
            otherPanel.Visibility = Visibility.Hidden;
        }

        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Words.Remove((Word)WordsList.SelectedItem);
            WordsList.Items.Remove(WordsList.SelectedItem);
        }

        private void ButtonClickBrowse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                path = op.FileName;
            }
        }

        private void WordImage_OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri(@"D:\FACULT 2020-2021\MVP\Dictionary\Dictionary\Resources\noimage.png"));
        }

        private void ButtonClickUpdate(object sender, RoutedEventArgs e)
        {
            ((Word)WordsList.SelectedItem).Name = inputNameModify.Text;
            ((Word)WordsList.SelectedItem).Description = inputDescriptionModify.Text;

            if (checkboxNewCategoryModify.IsChecked != null)
            {
                if ((bool)checkboxNewCategoryModify.IsChecked)
                {
                    string newCategory = inputNewCategoryModify.Text;

                    ((Word)WordsList.SelectedItem).Category = newCategory;
                    comboBoxCategory.Items.Add(newCategory);
                    comboBoxCategoryModify.Items.Add(newCategory);
                }
                else
                {
                    ((Word)WordsList.SelectedItem).Category = comboBoxCategoryModify.Text;
                }
            }

            AdministrationWindow window = new AdministrationWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClickBrowseModify(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                path = op.FileName;
            }
        }
    }
}
