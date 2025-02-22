using Quiz_GUI.Models;
using Quiz_GUI.Stores;
using System;
using System.Windows.Input;

namespace Quiz_GUI.ViewModels
{
    public class PlayerDetailsViewModel : ViewModelBase
    {
        private readonly SelectedPlayerStores _SelectedPlayerStores;
        private readonly PlayerListStore _playerListStore;

        private Player SelectedPlayer => _SelectedPlayerStores.selectedPlayer;

        public bool HasSelectedPlayer => SelectedPlayer != null;
        public string UserName => SelectedPlayer?.Username ?? "No";
        public string FullName => SelectedPlayer?.FullName ?? "No";
        public string Email => SelectedPlayer?.Email ?? "No";
        public int Rank => SelectedPlayer?.Rank ?? 0;
        public int Score => SelectedPlayer?.Score ?? 0;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PlayerDetailsViewModel(SelectedPlayerStores selectedPlayerStores, PlayerListStore playerListStore)
        {
            _SelectedPlayerStores = selectedPlayerStores ?? throw new ArgumentNullException(nameof(selectedPlayerStores));
            _playerListStore = playerListStore ?? throw new ArgumentNullException(nameof(playerListStore));

            _SelectedPlayerStores.SelectedPlayerChanged += SelectedPlayerStores_SlectedPlayerChanged;

           EditCommand = new RelayCommand(EditPlayerDetails);
            DeleteCommand = new RelayCommand(DeletePlayerDetails, CanDeletePlayerDetails);
        }

        protected override void Dispose()
        {
            _SelectedPlayerStores.SelectedPlayerChanged -= SelectedPlayerStores_SlectedPlayerChanged;
            base.Dispose();
        }

        private void SelectedPlayerStores_SlectedPlayerChanged()
        {
            // Notify the UI that properties have changed
            OnPropertyChanged(nameof(HasSelectedPlayer));
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Rank));
            OnPropertyChanged(nameof(Score));
        }
        
        private void EditPlayerDetails(object parameter)
        {
            if (SelectedPlayer != null)
            {
                // Pass the current instance of PlayerDetailsViewModel to EditPlayerViewModel
                var editPlayerViewModel = new EditPlayerViewModel(SelectedPlayer, _playerListStore, this);
                var editPlayerView = new EditPlayerWindow( SelectedPlayer,this, _playerListStore );

                // Open the window as a dialog
                editPlayerView.ShowDialog();

                // After the dialog is closed, manually refresh the properties
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Score));
                OnPropertyChanged(nameof(Rank));
            }
        }

        private bool CanDeletePlayerDetails(object parameter)
        {
            // Enable delete only if a player is selected
            return SelectedPlayer != null;
        }

        private void DeletePlayerDetails(object parameter)
        {
            if (SelectedPlayer != null)
            {
                // Remove the selected player from the player list
                _playerListStore.RemovePlayer(SelectedPlayer);

                // Reset the selected player to null
                _SelectedPlayerStores.selectedPlayer = null;

                // Notify the UI to reset the details panel to the default state
                OnPropertyChanged(nameof(HasSelectedPlayer));
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Score));
                OnPropertyChanged(nameof(Rank));
            }
        }

        public void UpdatePlayerDetails()
        {
            _SelectedPlayerStores.selectedPlayer = null;
            // Manually trigger the property change notifications to update the UI
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Score));
            OnPropertyChanged(nameof(Rank));
        }
    }
}
