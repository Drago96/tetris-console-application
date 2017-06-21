namespace Tetris.Services
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using Tetris.Data;
    using Tetris.Models;
    using Tetris.Models.Enums;
    using Tetris.Services.IO;
    using Tetris.Utilities;

    public class MenuService
    {
        private readonly ConsoleWriter consoleWriter;
        private readonly ConsoleReader consoleReader;

        public MenuService()
        {
            this.consoleWriter = new ConsoleWriter();
            this.consoleReader = new ConsoleReader();
        }

        public void PrintMenuOptions(Menu menu)
        {
            Console.CursorVisible = false;
            this.consoleWriter.PrintLine(Constants.ChooseAction);
            var counter = 1;
            foreach (var menuOption in Enum.GetValues(typeof(MenuOption)))
            {
                if (menu.CurrentCursorPosition == counter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    this.consoleWriter.PrintLine($"{this.GetMenuItemDescription(menuOption)}");
                    Console.ResetColor();
                }
                else
                {
                    this.consoleWriter.PrintLine($"{this.GetMenuItemDescription(menuOption)}");
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
                    return ((DescriptionAttribute) attrs[0]).Description;
                }
            }
            return enumValue.ToString();
        }

        public void ShowHighScores()
        {
            using (var context = new TetrisDbContext())
            {
                var highscores = context.HighScores.OrderByDescending(h => h.Points).Take(10).ToList();
                if (highscores.Count > 0)
                {
                    this.consoleWriter.PrintLine(Constants.Top10);
                    highscores.ForEach(h => Console.WriteLine($"{h.User.Name} - {h.Points}"));
                }
                else
                {
                    this.consoleWriter.PrintLine(Constants.NoScoresToShow);
                }
                this.consoleWriter.PrintEmptyLine();
                this.consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
            }
        }

        public void ShowScoresForUser()
        {
            this.consoleWriter.PrintLine(Constants.PleaseEnterUsername);
            var username = consoleReader.ReadLine();
            var userService = new UserService();
            var userHighscores = userService.GetScoresByUsername(username);
            if (!userHighscores.Any())
            {
                this.consoleWriter.PrintLine(Constants.NoSuchUserOrNoScores);
            }
            else
            {
                foreach (var score in userHighscores.OrderByDescending(s => s.Points))
                {
                    this.consoleWriter.PrintLine($"{score.Points} - {score.Date:d}");
                }
            }
            this.consoleWriter.PrintEmptyLine();
            this.consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }

        public void ShowCredits()
        {
            this.consoleWriter.PrintLine("Drago96\nhopeee\nIliyanPopov\ndimpeev\nNikola");
            this.consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }

        public void ShowHowToPlay()
        {
            Console.OutputEncoding = Encoding.UTF8;
            this.consoleWriter.PrintLine(Constants.LeftArrow);
            this.consoleWriter.PrintLine(Constants.RightArrow);
            this.consoleWriter.PrintLine(Constants.UpArrow);
            this.consoleWriter.PrintLine(Constants.DownArrow);
            this.consoleWriter.PrintLine(Constants.Space);
            this.consoleWriter.PrintLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}