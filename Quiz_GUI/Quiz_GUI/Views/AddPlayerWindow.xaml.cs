using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Quiz_GUI.Views
{
    public partial class AddPlayerWindow : Window
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public int Rank { get; private set; }
        public int Score { get; private set; }

        public AddPlayerWindow()
        {
            InitializeComponent();
        }

        private bool ValidateForm()
        {
            bool isValid = true;

            UsernameError.Text = EmailError.Text = FullNameError.Text = RankError.Text = ScoreError.Text = "";

            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || UsernameTextBox.Text == "Username")
            {
                UsernameError.Text = "Username is required.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || !EmailTextBox.Text.Contains("@"))
            {
                EmailError.Text = "Invalid email.";
                isValid = false;
            }

            if (EmailTextBox.Text == "Email")
            {
                EmailError.Text = "Email is required.";
                isValid = false;
            }
               

            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) || FullNameTextBox.Text == "Full Name")
            {
                FullNameError.Text = "Full Name is required.";
                isValid = false;
            }

            if (!int.TryParse(RankTextBox.Text, out _))
            {
                RankError.Text = "Rank must be a valid number.";
                isValid = false;
            }

            if (!int.TryParse(ScoreTextBox.Text, out _))
            {
                ScoreError.Text = "Score must be a valid number.";
                isValid = false;
            }

            return isValid;
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            if(ValidateForm())
            {
                Username = UsernameTextBox.Text;
                Email = EmailTextBox.Text;
                FullName = FullNameTextBox.Text;
                Rank = int.TryParse(RankTextBox.Text, out int rank) ? rank : 0;
                Score = int.TryParse(ScoreTextBox.Text, out int score) ? score : 0;

                DialogResult = true;
                Close();
            }
        }
    }
}

