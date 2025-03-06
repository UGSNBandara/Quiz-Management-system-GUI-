using Quiz_GUI.Stores;
using System.Windows;

namespace Quiz_GUI.Views
{
    public partial class Login : Window
    {
        private readonly SelectedPlayerStores _SelectedPlayerStores;

        public Login(SelectedPlayerStores selectedPlayerStores)
        {
            InitializeComponent();
            _SelectedPlayerStores = selectedPlayerStores;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate credentials
            if (UsernameTextBox.Text == "admin" && PasswordBox.Password == "password")
            {
                // Open the MainWindow with the shared SelectedPlayerStores
                MainWindow mainWindow = new MainWindow
                {
                    DataContext = new ViewModels.PlayerViewModel(_SelectedPlayerStores)
                };
                mainWindow.Show();

                // Close the Login window
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials, try again!");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Open RegisterWindow
            Views.RegisterWindow registerWindow = new RegisterWindow(_SelectedPlayerStores);
            registerWindow.Show();
            this.Close();
        }
    }
}
