using Quiz_GUI.Stores;
using System.Windows;

namespace Quiz_GUI
{
    public partial class App : Application
    {
        private readonly SelectedPlayerStores _SelectedPlayerStores;

        public App()
        {
            _SelectedPlayerStores = new SelectedPlayerStores();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Pass the shared instance to the Login window
            Views.Login loginWindow = new Views.Login(_SelectedPlayerStores);
            loginWindow.Show();
        }
    }
}
