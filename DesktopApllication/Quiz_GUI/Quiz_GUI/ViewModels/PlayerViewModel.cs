using Quiz_GUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            PlayerDetailsViewModel = new PlayerDetailsViewModel(_SelectedPlayerStores);  
             
        }

    }
}
