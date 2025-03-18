using Quiz_GUI.Commands;
using Quiz_GUI.DB_Manager;
using Quiz_GUI.Stores;
using Quiz_GUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Quiz_GUI.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {

        public PlayerListViewModel PlayerListViewModel { get; }
        public PlayerDetailsViewModel PlayerDetailsViewModel { get; }

        public ICommand AddPlayerCommand { get; }


        public PlayerViewModel(SelectedPlayerStores _SelectedPlayerStores)
        {
            PlayerListViewModel = new PlayerListViewModel(_SelectedPlayerStores);
            PlayerDetailsViewModel = new PlayerDetailsViewModel(_SelectedPlayerStores, PlayerListViewModel);

            AddPlayerCommand = new RelayCommand(ExecuteAddPlayerCommand);
            
        }

        private void ExecuteAddPlayerCommand(object parameter)
        {
            var addPlayerWindow = new AddPlayerWindow();
            if (addPlayerWindow.ShowDialog() == true)
            {
                PlayerDataManager playerdbManager = new PlayerDataManager();
                playerdbManager.AddPlayerToDatabase(
                    addPlayerWindow.Username,
                    addPlayerWindow.Email,
                    addPlayerWindow.FullName,
                    addPlayerWindow.Rank,
                    addPlayerWindow.Score
                );

                var newPlayer = new PlayerListItemViewModel(
                    addPlayerWindow.Username,
                    addPlayerWindow.Email,
                    addPlayerWindow.FullName,
                    addPlayerWindow.Rank,
                    addPlayerWindow.Score
                );

                PlayerListViewModel.AddPlayer(newPlayer);
            }
        }





    }
}
