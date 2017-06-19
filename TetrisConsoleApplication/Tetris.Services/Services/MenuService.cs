namespace Tetris.Services.Services
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using IO;
    using Utilities;

    public class MenuService
    {
        private static readonly ConsoleWriter ConsoleWriter = new ConsoleWriter();

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

        public void ShowScoresForUser(string username)
        {      
            var userService = new UserService();
            var userHighscores = userService.GetScoresByUsername(username);
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
            ConsoleWriter.PrintLine("Drago96\nhopeee\nIliyanPopov\ndimpeev\nNikola");
            ConsoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }

        }

        public void ShowHowToPlay()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleWriter.PrintLine(Constants.LeftArrow);
            ConsoleWriter.PrintLine(Constants.RightArrow);
            ConsoleWriter.PrintLine(Constants.UpArrow);
            ConsoleWriter.PrintLine(Constants.DownArrow);
            ConsoleWriter.PrintLine(Constants.Space);
            Console.OutputEncoding = Encoding.ASCII;
            ConsoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }
    }
}
