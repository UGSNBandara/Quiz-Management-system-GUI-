using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;




namespace Quiz_GUI.DB_Manager
{
    public class AdminDataManager
    {
        private readonly string _ConnectionString;

        public AdminDataManager()
        {
            _ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Quizify;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }

        public void RegisterUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Admin (Username, Password) VALUES (@Username, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
