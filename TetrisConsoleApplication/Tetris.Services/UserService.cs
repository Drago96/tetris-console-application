namespace Tetris.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models.Entities;

    public class UserService
    {

        public User GetUserById(int userId)
        {
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == userId);
            }
        }

        public bool AddScore(string username, long points)
        {
            if (username == null)
            {
                return false;
            }
            var isNewHighscore = false;
            using (var context = new TetrisDbContext())
            {

                if (context.HighScores.Max(h => h.Points) < points)
                {
                    isNewHighscore = true;
                }
                var user = context.Users.FirstOrDefault(u => u.Name == username);
                var highscore = new HighScore
                {
                    User = user,
                    Points = points,
                    Date = DateTime.Now
                };
                context.HighScores.Add(highscore);
                context.SaveChanges();
            }
            return isNewHighscore;
        }

        public List<HighScore> GetUserHighScoresByName(string username)
        {
            if (!UserExists(username))
            {
                return new List<HighScore>();
            }
            if (!UserHasHighscores(username))
            {
                return new List<HighScore>();
            }
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Name == username).HighScores.OrderByDescending(h => h.Points).ToList();
            }
        }

        private static bool UserExists(string username)
        {
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Name == username) != null;
            }
        }

        private static bool UserHasHighscores(string username)
        {
            using (var context = new TetrisDbContext())
            {
                return UserExists(username) && context.Users.FirstOrDefault(u => u.Name == username).HighScores != null;
            }
        }
    }
}