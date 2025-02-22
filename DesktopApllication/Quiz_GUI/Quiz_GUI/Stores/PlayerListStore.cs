using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient; // Updated namespace
using Quiz_GUI.Models;

namespace Quiz_GUI.Stores
{
    public class PlayerListStore
    {
        private readonly string _connectionString;

        public ObservableCollection<Player> Players { get; }

        // Event to notify when the player list changes
        public event Action PlayerListChanged;

        public PlayerListStore()
        {
            _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\sulit\\Documents\\Quizify.mdf;Integrated Security=True;Connect Timeout=30";
            Players = new ObservableCollection<Player>();
            LoadPlayersFromDatabase();
        }

        public void LoadPlayersFromDatabase()
        {
            Players.Clear();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Username, Email, FullName, Rank, Score FROM Players";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var player = new Player(
                                reader.GetString(0), // Username
                                reader.GetString(1), // Email
                                reader.GetString(2), // FullName
                                reader.GetInt32(3),  // Rank
                                reader.GetInt32(4)   // Score
                            );
                            Players.Add(player);
                        }
                    }
                }
            }

            PlayerListChanged?.Invoke(); // Notify listeners after loading data
        }

        public void UpdatePlayer(Player player)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Players SET Email = @Email, FullName = @FullName, Rank = @Rank, Score = @Score WHERE Username = @Username";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", player.Username);
                    command.Parameters.AddWithValue("@Email", player.Email);
                    command.Parameters.AddWithValue("@FullName", player.FullName);
                    command.Parameters.AddWithValue("@Rank", player.Rank);
                    command.Parameters.AddWithValue("@Score", player.Score);

                    command.ExecuteNonQuery();
                }
            }
            LoadPlayersFromDatabase();
            PlayerListChanged?.Invoke();

        }

        public void AddPlayer(Player player)
        {
            if (UsernameExists(player.Username))
            {
                // You can throw an exception or trigger an error message here.
                throw new InvalidOperationException("Username already exists. Please choose a different one.");
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Players (Username, Email, FullName, Rank, Score) VALUES (@Username, @Email, @FullName, @Rank, @Score)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", player.Username);
                    command.Parameters.AddWithValue("@Email", player.Email);
                    command.Parameters.AddWithValue("@FullName", player.FullName);
                    command.Parameters.AddWithValue("@Rank", player.Rank);
                    command.Parameters.AddWithValue("@Score", player.Score);
                    command.ExecuteNonQuery();
                }
            }

            Players.Add(player);
            PlayerListChanged?.Invoke(); // Notify listeners after adding player
        }

        public void RemovePlayer(Player player)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Players WHERE Username = @Username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", player.Username);
                    command.ExecuteNonQuery();
                }
            }

            Players.Remove(player);
            LoadPlayersFromDatabase();
            PlayerListChanged?.Invoke(); // Notify listeners after removing player
        }

        public bool UsernameExists(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM Players WHERE Username = @Username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
    }
}
