using Quiz_GUI.DB_Manager;
using Quiz_GUI.Stores;
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

namespace Quiz_GUI.Views
{
    /// <summary>
    /// Interaction logic for Signin.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly SelectedPlayerStores _SelectedPlayerStores;
        private readonly AdminDataManager adminDataManager;
        public RegisterWindow(SelectedPlayerStores selectedPlayerStores)
        {
            InitializeComponent();
            _SelectedPlayerStores = selectedPlayerStores;
            adminDataManager = new AdminDataManager();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle registration logic here
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            adminDataManager.RegisterUser(username, password);

            MainWindow mainWindow = new MainWindow
            {
                DataContext = new ViewModels.PlayerViewModel(_SelectedPlayerStores)
            };
            mainWindow.Show();

            // Close the Login window
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Views.Login loginWindow = new Views.Login(_SelectedPlayerStores);
            loginWindow.Show();
            this.Close();
        }
    }


}
