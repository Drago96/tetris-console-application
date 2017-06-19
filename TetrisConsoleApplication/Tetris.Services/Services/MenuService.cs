namespace Tetris.Services
{
    using System;
    using System.Linq;
    using Data;
    using IO;
    using Utilities;

    public class MenuService
    {
        private static readonly ConsoleWriter ConsoleWriter = new ConsoleWriter();
        private static readonly ConsoleReader ConsoleReader = new ConsoleReader();

        public void ShowTop10()
        {
            using (var context = new TetrisDbContext())
            {
                var highscores = context.HighScores.OrderByDescending(h => h.Points).Take(10).ToList();
                if (highscores.Count > 0)
                {
                    ConsoleWriter.PrintLine(Constants.Top10);
                    highscores.ForEach(h => Console.WriteLine($"{h.User.Name} - {h.Points}"));
                }
                else
                {
                    ConsoleWriter.PrintLine(Constants.NoScoresToShow);
                }
                ConsoleWriter.PrintEmptyLine();
                ConsoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
                while (Console.ReadKey().Key != ConsoleKey.Escape){ }
            }
        }

        public void ShowScoresForUser()
        {
            ConsoleWriter.PrintLine(Constants.PleaseEnterUsername);
            var username = ConsoleReader.ReadLine();
            var userService = new UserService();
            var userHighscores = userService.GetUserHighScoresByName(username);
            if (!userHighscores.Any())
            {
                ConsoleWriter.PrintLine(string.Join(" ", username, Constants.UserDoesNotHaveScores));
            }
            else
            {
                foreach (var score in userHighscores.OrderBy(s => s.Points))
                {
                    ConsoleWriter.PrintLine($"{score.Points} - {score.Date:d}");
                }
            }
            ConsoleWriter.PrintEmptyLine();
            ConsoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }

        public void ShowCredits()
        {
            
        }

        public void ShowHowToPlay()
        {
            
        }
    }
}
