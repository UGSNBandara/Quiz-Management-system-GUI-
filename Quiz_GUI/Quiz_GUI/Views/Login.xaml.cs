using Quiz_GUI.DB_Manager;
using Quiz_GUI.Stores;
using System.Windows;

namespace Quiz_GUI.Views
{
    public partial class Login : Window
    {
        private readonly SelectedPlayerStores _SelectedPlayerStores;
        private readonly AdminDataManager adminDataManager;

        public Login(SelectedPlayerStores selectedPlayerStores)
        {
            InitializeComponent();
            _SelectedPlayerStores = selectedPlayerStores;

            adminDataManager = new AdminDataManager();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate credentials
            if (adminDataManager.ValidateUser(UsernameTextBox.Text, PasswordBox.Password))
            {
                MainWindow mainWindow = new MainWindow
                {
                    DataContext = new ViewModels.PlayerViewModel(_SelectedPlayerStores)
                };
                mainWindow.Show();
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
