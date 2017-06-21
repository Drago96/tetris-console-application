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
            if (string.IsNullOrEmpty(username) || !UserExists(username))
            {
                return;
            }
            using (var context = new TetrisDbContext())
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
        }

        public List<HighScore> GetScoresByUsername(string username)
        {
            if (username == null || !UserExists(username))
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

        public void LoginUser()
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                Console.WriteLine("Please enter your name... (Press ENTER if you want to play anonimously)");
                var username = Console.ReadLine();

                User user = new User()
                {
                    Name = username
                };

                using (var context = new TetrisDbContext())
                {
                    if (context.Users.Any(u => u.Name == username))
                    {
                        var userFromDb = context.Users.First(u => u.Name == username);
                        AuthenticationManager.Login(userFromDb);
                    }
                    else
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        AuthenticationManager.Login(user);
                    }
                }
            }
            Console.Clear();
        }
    }
}