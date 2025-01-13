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
        private readonly PlayerListStore _PlayerListStore;

        public App()
        {
            _SelectedPlayerStores = new SelectedPlayerStores();
            _PlayerListStore = new PlayerListStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new ViewModels.PlayerViewModel(_SelectedPlayerStores, _PlayerListStore)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
