using System.ComponentModel;
using Tetris.Models;
using Tetris.Models.Enums;

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

        public void ShowMenu(Menu menu)
        {
            Console.CursorVisible = false;
            var startCursorPos = 1;
            var currentCursorPos = startCursorPos;
            Console.SetCursorPosition(0, currentCursorPos);
        }

        public static void PrintMenuOptions(int currentCursorPos)
        {
            var counter = 1;
            foreach (var menuOption in Enum.GetValues(typeof(MenuOption)))
            {
                if (currentCursorPos == counter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ConsoleWriter.PrintLine($"{GetMenuItemDescription(menuOption)}");
                    Console.ResetColor();
                }
                else
                {
                    ConsoleWriter.PrintLine($"{GetMenuItemDescription(menuOption)}");
                }
                counter++;
            }
        }

        private static string GetMenuItemDescription(object enumValue)
        {
            var fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null != fi)
            {
                var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumValue.ToString();
        }

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
