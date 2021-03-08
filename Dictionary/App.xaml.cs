using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
namespace Dictionary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public ObservableCollection<Word> Words { get; set; }
            
        private const string MyWords = @"..\..\Resources\words.json";

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            try
            {
                string jsonString = File.ReadAllText(MyWords);
                Words = JsonSerializer.Deserialize<ObservableCollection<Word>>(jsonString);
            }
            catch (IOException)
            {
                Words = new ObservableCollection<Word>();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
           
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(Words);
            File.WriteAllText(MyWords, jsonString);
        }
    }
}
