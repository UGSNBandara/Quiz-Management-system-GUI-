using Quiz_GUI.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Quiz_GUI.ViewModels
{
    public class EditPlayerViewModel : ViewModelBase
    {
        public Player Player { get; }
        private readonly PlayerDetailsViewModel _playerDetailsViewModel;

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditPlayerViewModel(Player player, PlayerDetailsViewModel playerDetailsViewModel)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
            _playerDetailsViewModel = playerDetailsViewModel ?? throw new ArgumentNullException(nameof(playerDetailsViewModel));

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Save(object parameter)
        {
            // Notify PlayerDetailsViewModel of the change
            _playerDetailsViewModel.UpdatePlayerDetails();

            // Close the window and mark the operation as successful
            CloseWindow();
        }

        private void Cancel(object parameter)
        {
            // Simply close the window without saving changes
            CloseWindow();
        }

        private void CloseWindow()
        {
            // Try to find and close the currently active window (EditPlayerWindow)
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
