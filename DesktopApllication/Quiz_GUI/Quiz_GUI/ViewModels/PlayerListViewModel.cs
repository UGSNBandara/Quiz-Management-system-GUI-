using Quiz_GUI;
using Quiz_GUI.Models;
using Quiz_GUI.Stores;
using Quiz_GUI.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

public class PlayerListViewModel : ViewModelBase
{
    private readonly SelectedPlayerStores _selectedPlayerStores;
    private readonly PlayerListStore _playerListStore; 
    private readonly ObservableCollection<PlayerListItemViewModel> _players;

    public IEnumerable<PlayerListItemViewModel> Players => _players;
    public string ErrorMessage { get; private set; }

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

    // Updated Constructor
    public PlayerListViewModel(SelectedPlayerStores selectedPlayerStores, PlayerListStore playerListStore)
    {
        _selectedPlayerStores = selectedPlayerStores;
        _playerListStore = playerListStore;

        _players = new ObservableCollection<PlayerListItemViewModel>(
            _playerListStore.Players.Select(p => new PlayerListItemViewModel(
                p.Username, p.Email, p.FullName, p.Score, p.Rank, this)));

        _playerListStore.PlayerListChanged += OnPlayerListChanged; // Subscribe to event
    }


    // Synchronize _players with PlayerListStore
    private void OnPlayerListChanged()
    {
        _players.Clear();
        foreach (var player in _playerListStore.Players)
        {
            _players.Add(new PlayerListItemViewModel(
                player.Username, player.Email, player.FullName, player.Score, player.Rank, this));
        }
    }


    public void AddPlayer(PlayerListItemViewModel player)
    {
        try
        {
            var newPlayer = new Player(player.Username, player.Email, player.FullName, player.Rank, player.Score);
            _playerListStore.AddPlayer(newPlayer); // Update store
            ErrorMessage = string.Empty; // Clear any previous error messages
        }
        catch (InvalidOperationException ex)
        {
            var errorWindow = new ErrorWindow();
            errorWindow.ErrorMessageTextBlock.Text = ex.Message; // Set the error message on the error window
            errorWindow.ShowDialog();
        }
    }

    public void RemovePlayer(PlayerListItemViewModel player)
    {
        var existingPlayer = _playerListStore.Players.FirstOrDefault(p =>
            p.Username == player.Username &&
            p.Email == player.Email &&
            p.FullName == player.FullName &&
            p.Score == player.Score &&
            p.Rank == player.Rank);

        if (existingPlayer != null)
        {
            _playerListStore.RemovePlayer(existingPlayer);
            SelectedPlayer = null;// Update store
        }
    }



    protected override void Dispose()
    {
        _playerListStore.PlayerListChanged -= OnPlayerListChanged;
        base.Dispose();
    }
}
