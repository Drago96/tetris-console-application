namespace Tetris.Services
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Tetris.Data;
    using Tetris.Models.Entities;

    public class UserService
    {

        public User GetUserById(int userId)
        {
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == userId);
            }
        }

        public IEnumerable<HighScore> GetUserHighScoresById(int userId)
        {
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == userId).HighScores;
            }
        }

        public IEnumerable<HighScore> GetUserHighScoresByName(string username)
        {
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Name == username).HighScores;
            }
        }
    }
}