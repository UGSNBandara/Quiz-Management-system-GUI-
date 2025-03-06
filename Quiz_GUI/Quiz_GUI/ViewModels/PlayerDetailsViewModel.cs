using Quiz_GUI.Commands;
using Quiz_GUI.Models;
using Quiz_GUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Quiz_GUI.ViewModels
{
    public class PlayerDetailsViewModel : ViewModelBase
    {
        private readonly SelectedPlayerStores _SelectedPlayerStores;

        private Player SelectedPlayer => _SelectedPlayerStores.selectedPlayer;

        public ICommand DeletePlayerCommand { get; }

        public ICommand ChangePlayerCommand { get; }


        public bool HasSelectedPlayer => SelectedPlayer != null;
        public String UserName => SelectedPlayer?.Username ?? "No";
        public String FullName => SelectedPlayer?.FullName ?? "No";
        public String Email => SelectedPlayer?.Email ?? "No";

        public int Rank => SelectedPlayer != null ? SelectedPlayer.Rank : 0;
        public int Score => SelectedPlayer != null ? SelectedPlayer.Score : 0;

        public PlayerDetailsViewModel(SelectedPlayerStores SelectedPlayerStores)
        {
            _SelectedPlayerStores = SelectedPlayerStores ?? throw new ArgumentNullException(nameof(SelectedPlayerStores));
            _SelectedPlayerStores.SelectedPlayerChanged += SelectedPlayerStores_SlectedPlayerChanged;

            DeletePlayerCommand = new RelayCommand(
                    execute: _ => DeletePlayer(),
                    canExecute: _ => HasSelectedPlayer);
        }
  


        protected override void Dispose()
        {
            _SelectedPlayerStores.SelectedPlayerChanged -= SelectedPlayerStores_SlectedPlayerChanged;

            base.Dispose();

        }

        private void SelectedPlayerStores_SlectedPlayerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedPlayer));
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Rank));
            OnPropertyChanged(nameof(Score));
        }

        private void DeletePlayer()
        {
            if (SelectedPlayer != null)
            {
                _SelectedPlayerStores.selectedPlayer = null;

                // Notify any consumers
                OnPropertyChanged(nameof(HasSelectedPlayer));
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Rank));
                OnPropertyChanged(nameof(Score));
            }
        }

    }
}
