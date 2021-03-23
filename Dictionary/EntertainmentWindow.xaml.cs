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
        private GuessingGame guessingGame;

        public EntertainmentWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void EntertainmentWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            guessingGame = new GuessingGame(5);
            ShowTip(0);
        }

        private void ShowTip(int index)
        {
            if (guessingGame.ShowTip())
            {
                labelTip.Content = guessingGame.WordsToBeGuessed.ElementAt(index).Description;
                labelTip.Visibility = Visibility.Visible;
                imageTip.Visibility = Visibility.Hidden;
            }
            else
            {
                imageTip.Source = new BitmapImage(new Uri(guessingGame.WordsToBeGuessed.ElementAt(index).ImagePath));
                imageTip.Visibility = Visibility.Visible;
                labelTip.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonClickGuess(object sender, RoutedEventArgs e)
        {
            if (guessingGame.GuessMade(input.Text))
            {
                guessingGame.NoOfGuessedWords++;
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

            if (guessingGame.IsFinished())
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
                guessingGame.IndexOfCurrentWord++;
                ShowTip(guessingGame.IndexOfCurrentWord);
            }
        }

        private void ButtonClickFinish(object sender, RoutedEventArgs e)
        {
            labelFinished.Content = String.Format($"You guessed {guessingGame.NoOfGuessedWords} words!");
        }

        private void ButtonClickMenu(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
