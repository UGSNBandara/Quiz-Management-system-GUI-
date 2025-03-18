using Quiz_GUI.DB_Manager;
using Quiz_GUI.Models;
using Quiz_GUI.Stores;
using Quiz_GUI.ViewModels;
using System.Collections.ObjectModel;

public class PlayerListViewModel : ViewModelBase
{
    private readonly SelectedPlayerStores _selectedPlayerStores;
    private readonly ObservableCollection<PlayerListItemViewModel> _players;
    public IEnumerable<PlayerListItemViewModel> Players => _players;

    private PlayerListItemViewModel _selectedPlayer;
    public PlayerListItemViewModel SelectedPlayer
    {
        get => _selectedPlayer;
        set
        {
            _selectedPlayer = value;
            OnPropertyChanged(nameof(SelectedPlayer));

            if (_selectedPlayer != null)
            {
                _selectedPlayerStores.selectedPlayer = new Player(
                    _selectedPlayer.Username,
                    _selectedPlayer.Email, 
                    _selectedPlayer.FullName,          
                    _selectedPlayer.Rank,                    
                    _selectedPlayer.Score                   
                );
            }
        }
    }

    public PlayerListViewModel(SelectedPlayerStores selectedPlayerStores)
    {
        _selectedPlayerStores = selectedPlayerStores;
        PlayerDataManager playerdbManager = new PlayerDataManager();
        _players = new ObservableCollection<PlayerListItemViewModel>(playerdbManager.GetAllPlayersFromDatabase());
    }

    public void AddPlayer(PlayerListItemViewModel newPlayer)
    {
        _players.Add(newPlayer);
        OnPropertyChanged(nameof(Players));
    }

    public void DeletePlayer(PlayerListItemViewModel playerToDelete)
    {
        if (_players.Contains(playerToDelete))
        {
            PlayerDataManager playerdbManager = new PlayerDataManager();
            playerdbManager.DeletePlayerFromDatabase(playerToDelete.Username);

            _players.Remove(playerToDelete);
            OnPropertyChanged(nameof(Players));
        }
    }


    public void RemovePlayer(PlayerListItemViewModel player)
    {
        if (player != null)
        {
            _players.Remove(player);
            OnPropertyChanged(nameof(Players));

            // Clear the selected player from the store if it matches the removed player
            if (_selectedPlayerStores.selectedPlayer != null &&
                _selectedPlayerStores.selectedPlayer.Username == player.Username)
            {
                _selectedPlayerStores.selectedPlayer = null;
            }
        }
    }

}
