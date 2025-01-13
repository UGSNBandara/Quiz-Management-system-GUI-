using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Quiz_GUI.ViewModels
{
    public class PlayerListItemViewModel : ViewModelBase
    {
        public string Username { get;}
        public string Email { get;}
        public string FullName { get; }
        public int Score { get; }
        public int Rank { get; }

        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        private readonly PlayerListViewModel _playerListViewModel;

        public PlayerListItemViewModel(string username, string email, string fullName, int score, int rank, PlayerListViewModel playerListViewModel)
        {
            Username = username;
            Email = email;
            FullName = fullName;
            Score = score;
            Rank = rank;
            _playerListViewModel = playerListViewModel;

            DeleteCommand = new RelayCommand(DeletePlayer);
        }

        public PlayerListItemViewModel(string username, string email, string fullName, int score, int rank)
        {
            Username = username;
            Email = email;
            FullName = fullName;
            Score = score;
            Rank = rank;
        }

        private void DeletePlayer(object parameter)
        {
            // Call the RemovePlayer method to remove the current player from the list
            _playerListViewModel.RemovePlayer(this);
        }

    }
}
