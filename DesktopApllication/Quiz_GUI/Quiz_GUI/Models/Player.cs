using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Quiz_GUI.Models
{
    public class Player : INotifyPropertyChanged
    {
        private string _username;
        private string _email;
        private string _fullName;
        private int _score;
        private int _rank;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public int Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }

        public int Rank
        {
            get => _rank;
            set => SetProperty(ref _rank, value);
        }

        // Constructor
        public Player(string username, string email, string fullName, int rank, int score)
        {
            _username = username;
            _email = email;
            _fullName = fullName;
            _rank = rank;
            _score = score;
        }

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
