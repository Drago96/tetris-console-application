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

        public void AddScore(string username, long points)
        {
            using (var context = new TetrisDbContext())
            {
                if (this.UserExists(username))
                {
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
                else
                {
                    var user = new User
                    {
                        Name = username,
                        HighScores = new List<HighScore>()
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    var highscore = new HighScore
                    {
                        User = user,
                        Points = points,
                        Date = DateTime.Now
                    };
                    context.HighScores.Add(highscore);
                    context.SaveChanges();
                }
            }
        }

        public List<HighScore> GetUserHighScoresById(int userId)
        {
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == userId).HighScores.ToList();
            }
        }

        public List<HighScore> GetUserHighScoresByName(string username)
        {
            if (!this.UserExists(username))
            {
                return new List<HighScore>();
            }
            if (!this.UserHasHighscores(username))
            {
                return new List<HighScore>();
            }
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Name == username).HighScores.OrderByDescending(h => h.Points).ToList();
            }
        }

        private bool UserExists(string username)
        {
            using (var context = new TetrisDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Name == username) != null;
            }
        }

        private bool UserHasHighscores(string username)
        {
            using (var context = new TetrisDbContext())
            {
                return this.UserExists(username) && context.Users.FirstOrDefault(u => u.Name == username).HighScores != null;
            }
        }
    }
}