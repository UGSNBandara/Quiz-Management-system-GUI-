using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_GUI.Models
{
    public class Player
    {
        public string Username { get; }
        public string Email { get; }
        public string FullName { get; }
        public int Score { get; }
        public int Rank { get; }

        public Player(string username, string email, string fullname, int rank, int score) {
            Username = username;
            Email = email;
            FullName = fullname;
            Score = score;
            Rank = rank;
        }
    }
}
