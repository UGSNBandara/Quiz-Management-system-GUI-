using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Quiz_GUI.ViewModels
{
    public class AddPlayerViewModel : ViewModelBase
    {
        private string _username = "DefaultUser";
        private string _email = "default@example.com";
        private string _fullName = "Default Name";
        private int _rank = 0;
        private int _score = 0;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        public int Rank
        {
            get => _rank;
            set
            {
                _rank = value;
                OnPropertyChanged();
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPlayerViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Save()
        {
            CloseWindow(true); // Indicate success
        }

        private void Cancel()
        {
            CloseWindow(false); // Indicate cancel
        }

        private void CloseWindow(bool dialogResult)
        {
            var window = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext == this);
            if (window != null)
            {
                window.DialogResult = dialogResult;
                window.Close();
            }
        }

        // Notify PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private Visibility errorMessage;

        public Visibility ErrorMessage { get => errorMessage; set => SetProperty(ref errorMessage, value); }
    }
}
