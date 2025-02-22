using Quiz_GUI.Models;
using Quiz_GUI.Stores;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Quiz_GUI.ViewModels
{
    public class EditPlayerViewModel : ViewModelBase
    {
        private readonly PlayerListStore _playerListStore;


        // Bound Player Property
        public Player Player { get; }
        public PlayerDetailsViewModel PlayerDetails { get; }

        // Bound Error Message Property
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        // Commands
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditPlayerViewModel(Player player,  PlayerListStore playerListStore, PlayerDetailsViewModel playerDetails)
        {
            _playerListStore = playerListStore;

            Player = new Player(player.Username, player.Email, player.FullName, player.Rank, player.Score);

            SaveCommand = new RelayCommand(async () => await SavePlayer());
            CancelCommand = new RelayCommand(CloseWindow);
            PlayerDetails = playerDetails;
        }

        // Save Player Logic
        private async Task SavePlayer()
        {
            try
            {
                // Simulate saving to the database or data store
                _playerListStore.UpdatePlayer(Player);

                // Clear error message on successful save
                ErrorMessage = string.Empty;
                PlayerDetails.UpdatePlayerDetails();

                // Close the edit window after saving
                CloseWindow();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }

        // Validation for enabling Save Button


        // Close the Window Logic
        private void CloseWindow()
        {
            // Find the window with this ViewModel as its DataContext and close it
            var window = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext == this);
            window?.Close();
        }
    }
}
