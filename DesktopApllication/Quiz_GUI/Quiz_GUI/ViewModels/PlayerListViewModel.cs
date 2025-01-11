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
        _players = new ObservableCollection<PlayerListItemViewModel>
        {
            new PlayerListItemViewModel("Leo123", "leo.martin@gmail.com", "Leonardo Martin", 1500, 1),
            new PlayerListItemViewModel("EmmaW", "emma.watson@yahoo.com", "Emma Watson", 1450, 2),
            new PlayerListItemViewModel("Sophia_R", "sophia.roberts@outlook.com", "Sophia Roberts", 1400, 3),
            new PlayerListItemViewModel("EthanB", "ethan.bennett@aol.com", "Ethan Bennett", 1350, 4),
            new PlayerListItemViewModel("AvaK", "ava.king@hotmail.com", "Ava King", 1300, 5),
            new PlayerListItemViewModel("LiamP", "liam.perez@gmail.com", "Liam Perez", 1250, 6),
            new PlayerListItemViewModel("IsabellaF", "isabella.foster@yahoo.com", "Isabella Foster", 1200, 7),
            new PlayerListItemViewModel("NoahH", "noah.harris@outlook.com", "Noah Harris", 1150, 8),
            new PlayerListItemViewModel("MiaC", "mia.collins@gmail.com", "Mia Collins", 1100, 9),
            new PlayerListItemViewModel("OliverJ", "oliver.james@protonmail.com", "Oliver James", 1050, 10)
        };
    }
}
