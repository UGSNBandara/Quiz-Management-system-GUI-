using Quiz_GUI.Stores;
using System.Windows.Input;

namespace Quiz_GUI.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public PlayerListViewModel PlayerListViewModel { get; }
        public PlayerDetailsViewModel PlayerDetailsViewModel { get; }

        public ICommand AddPlayerCommand { get; }

        public PlayerViewModel(SelectedPlayerStores selectedPlayerStores, PlayerListStore playerListStore)
        {
            PlayerListViewModel = new PlayerListViewModel(selectedPlayerStores, playerListStore);
            PlayerDetailsViewModel = new PlayerDetailsViewModel(selectedPlayerStores, playerListStore);

            AddPlayerCommand = new RelayCommand(OpenAddPlayerWindow);
        }

        private void AddPlayer()
        {
            // Create a new player with default values
            var newPlayer = new PlayerListItemViewModel(
                "NewUser",
                "new.user@example.com",
                "New User",
                0,
                PlayerListViewModel.Players.Count() + 1
            );

            // Add the new player to the PlayerListViewModel
            PlayerListViewModel.AddPlayer(newPlayer);
        }

        private void OpenAddPlayerWindow()
        {
            // Create and show the AddPlayerWindow
            var addPlayerWindow = new AddPlayerWindow
            {
                DataContext = new AddPlayerViewModel()
            };

            if (addPlayerWindow.ShowDialog() == true) // Wait for the window to close
            {
                var viewModel = (AddPlayerViewModel)addPlayerWindow.DataContext;

                // Add the new player to the list
                var newPlayer = new PlayerListItemViewModel(
                    viewModel.Username,
                    viewModel.Email,
                    viewModel.FullName,
                    viewModel.Score,
                    viewModel.Rank
                );

                PlayerListViewModel.AddPlayer(newPlayer);
            }
        }
    }
}
