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
    /// Interaction logic for EntertainmentWindow.xaml
    /// </summary>
    public partial class EntertainmentWindow : Window
    {
        private static int NoOfWords = 5;
        private static Random Rng = new Random();
        private int noOfGuessedWords = 0;
        private int currentWordIndex = 0;
        private List<Word> words = new List<Word>();

        public EntertainmentWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void EntertainmentWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).Words == null) return;

            if (((App)Application.Current).Words.Count < NoOfWords) return;

            ShuffleExtension.Shuffle(((App)Application.Current).Words);
            for (int i = 0; i < NoOfWords; i++)
            {
                words.Add(((App)Application.Current).Words.ElementAt(i));
            }

            ShowTip(currentWordIndex);
        }

        private void ShowTip(int index)
        {
            if (index % 2 == Rng.Next() % 2 || words.ElementAt(index).ImagePath.Equals("D:\\FACULT 2020-2021\\MVP\\Dictionary\\Dictionary\\Resources\\noimage.png"))
            {
                labelTip.Content = words.ElementAt(index).Description;
                labelTip.Visibility = Visibility.Visible;
                imageTip.Visibility = Visibility.Hidden;
            }
            else
            {
                imageTip.Source = new BitmapImage(new Uri(words.ElementAt(index).ImagePath));
                imageTip.Visibility = Visibility.Visible;
                labelTip.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonClickMenu(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClickGuess(object sender, RoutedEventArgs e)
        {
            if (input.Text.ToLower() == words.ElementAt(currentWordIndex).Name.ToLower())
            {
                noOfGuessedWords++;
                labelRight.Visibility = Visibility.Visible;
            }
            else 
            {
                labelWrong.Visibility = Visibility.Visible;
            }
            buttonNext.IsEnabled = true;
            buttonGuess.IsEnabled = false;
        }

        private void ButtonClickNext(object sender, RoutedEventArgs e)
        {
            labelRight.Visibility = Visibility.Hidden;
            labelWrong.Visibility = Visibility.Hidden;
            input.Text = "";
            buttonGuess.IsEnabled = true;

            if (currentWordIndex == 4)
            {
                buttonFinish.Visibility = Visibility.Visible;
                labelTip.Visibility = Visibility.Hidden;
                imageTip.Visibility = Visibility.Hidden;
                buttonGuess.IsEnabled = false;
                buttonNext.IsEnabled = false;
                input.IsEnabled = false;
            }
            else
            {
                buttonNext.IsEnabled = false;
                currentWordIndex++;
                ShowTip(currentWordIndex);
            }
        }

        private void ButtonClickFinish(object sender, RoutedEventArgs e)
        {
            labelFinished.Content = String.Format("You guessed {0} words!", noOfGuessedWords);
        }

        
    }
}
