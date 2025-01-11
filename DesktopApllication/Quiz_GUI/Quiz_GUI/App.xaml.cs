using Quiz_GUI.Stores;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Quiz_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedPlayerStores _SelectedPlayerStores;

        public App()
        {
            _SelectedPlayerStores = new SelectedPlayerStores();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new ViewModels.PlayerViewModel(_SelectedPlayerStores)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
