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
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            MyDictionary.InitializeDictionary();
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            MyDictionary.FinalizeDictionary();
        }
    }
}
