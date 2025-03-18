using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Data.SqlClient;
using Quiz_GUI.ViewModels;

namespace Quiz_GUI.DB_Manager
{
    public class PlayerDataManager
    {
        private readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Quizify; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";

        public void AddPlayerToDatabase(string username, string email, string fullName, int rank, int score)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Players (Username, Email, FullName, Rank, Score) VALUES (@Username, @Email, @FullName, @Rank, @Score)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Rank", rank);
                command.Parameters.AddWithValue("@Score", score);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<PlayerListItemViewModel> GetAllPlayersFromDatabase()
        {
            List<PlayerListItemViewModel> players = new List<PlayerListItemViewModel>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT Username, Email, FullName, Rank, Score FROM Players";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(new PlayerListItemViewModel(
                            reader.GetString(0), // Username
                            reader.GetString(1), // Email
                            reader.GetString(2), // FullName
                            reader.GetInt32(3),  // Rank
                            reader.GetInt32(4)   // Score
                        ));
                    }
                }
            }

            return players;
        }

        public void DeletePlayerFromDatabase(string username)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Players WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
