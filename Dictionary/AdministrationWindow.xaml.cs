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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void AdministrationWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (MyDictionary.Words == null) return;

            HashSet<string> categories = new HashSet<string>();
            foreach (Word word in MyDictionary.Words)
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

        private void ButtonClickMenu(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void HideButtons()
        {
            buttonAdd.Visibility = Visibility.Hidden;
            buttonOther.Visibility = Visibility.Hidden;
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

        private void ButtonClickAddNew(object sender, RoutedEventArgs e)
        {
            if (checkboxNewCategory.IsChecked != null)
            {
                string inputCategory;
                if ((bool)checkboxNewCategory.IsChecked)
                {
                    inputCategory = inputNewCategory.Text;
                    comboBoxCategory.Items.Add(inputCategory);
                    comboBoxCategoryModify.Items.Add(inputCategory);
                }
                else
                {
                    inputCategory = comboBoxCategory.SelectedItem.ToString();
                }
                MyDictionary.AddWord(inputName.Text, inputDescription.Text, inputCategory, path);
            }

            AdministrationWindow window = new AdministrationWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClickUpdate(object sender, RoutedEventArgs e)
        {
            if (checkboxNewCategoryModify.IsChecked != null)
            {
                string inputCategoryModify;
                if ((bool)checkboxNewCategoryModify.IsChecked)
                {
                    inputCategoryModify = inputNewCategoryModify.Text;
                    comboBoxCategory.Items.Add(newCategory);
                    comboBoxCategoryModify.Items.Add(newCategory);
                }
                else
                {
                    inputCategoryModify = comboBoxCategoryModify.Text;
                }
                MyDictionary.UpdateWord(((Word)WordsList.SelectedItem).Name, inputNameModify.Text, inputDescriptionModify.Text, inputCategoryModify);
            }

            AdministrationWindow window = new AdministrationWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            MyDictionary.RemoveWord(((Word)WordsList.SelectedItem).Name);
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

        private void WordImage_OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri(@"D:\FACULT 2020-2021\MVP\Dictionary\Dictionary\Resources\noimage.png"));
        }
    }
}
