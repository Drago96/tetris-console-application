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
        private readonly ConsoleWriter consoleWriter;

        public MenuService()
        {
            this.consoleWriter = new ConsoleWriter();
        }

        public void PrintMenuOptions(Menu menu)
        {
            Console.CursorVisible = false;
            consoleWriter.PrintLine(Constants.ChooseAction);
            var counter = 1;
            foreach (var menuOption in Enum.GetValues(typeof(MenuOption)))
            {
                if (menu.CurrentCursorPosition == counter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    consoleWriter.PrintLine($"{GetMenuItemDescription(menuOption)}");
                    Console.ResetColor();
                }
                else
                {
                    consoleWriter.PrintLine($"{GetMenuItemDescription(menuOption)}");
                }
                counter++;
            }
        }

        private string GetMenuItemDescription(object enumValue)
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

        public void ShowTop10( )
        {
            using (var context = new TetrisDbContext())
            {
                var highscores = context.HighScores.OrderByDescending(h => h.Points).Take(10).ToList();
                if (highscores.Count > 0)
                {
                    consoleWriter.PrintLine(Constants.Top10);
                    highscores.ForEach(h => Console.WriteLine($"{h.User.Name} - {h.Points}"));
                }
                else
                {
                    consoleWriter.PrintLine(Constants.NoScoresToShow);
                }
                consoleWriter.PrintEmptyLine();
                consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
                while (Console.ReadKey().Key != ConsoleKey.Escape){ }
            }
        }

        public void ShowScoresForUser(string username )
        {      
            var userService = new UserService();
            var userHighscores = userService.GetScoresByUsername(username);
            if (!userHighscores.Any())
            {
                consoleWriter.PrintLine(string.Join(" ", username, Constants.UserDoesNotHaveScores));
            }
            else
            {
                foreach (var score in userHighscores.OrderBy(s => s.Points))
                {
                    consoleWriter.PrintLine($"{score.Points} - {score.Date:d}");
                }
            }
            consoleWriter.PrintEmptyLine();
            consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }

        public void ShowCredits( )
        {
            consoleWriter.PrintLine("Drago96\nhopeee\nIliyanPopov\ndimpeev\nNikola");
            consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }

        }

        public void ShowHowToPlay( )
        {
            Console.OutputEncoding = Encoding.UTF8;
            consoleWriter.PrintLine(Constants.LeftArrow);
            consoleWriter.PrintLine(Constants.RightArrow);
            consoleWriter.PrintLine(Constants.UpArrow);
            consoleWriter.PrintLine(Constants.DownArrow);
            consoleWriter.PrintLine(Constants.Space);
            Console.OutputEncoding = Encoding.ASCII;
            consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }
    }
}
