using System.Collections.Generic;
using Tetris.Models.Entities;

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

        public void PrintMenuOptions(Menu menu)
        {
            Console.CursorVisible = false;
            ConsoleWriter.WriteLine(Constants.ChooseAction);
            var counter = 1;
            foreach (var menuOption in Enum.GetValues(typeof(MenuOption)))
            {
                if (menu.CurrentCursorPosition == counter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ConsoleWriter.WriteLine($"{this.GetMenuItemDescription(menuOption)}");
                    Console.ResetColor();
                }
                else
                {
                    ConsoleWriter.WriteLine($"{this.GetMenuItemDescription(menuOption)}");
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

        public void ShowHighScores(ICollection<HighScore> highscores)
        {
            
                if (highscores.Count > 0)
                {
                    ConsoleWriter.WriteLine(Constants.Highscores);
                    highscores.ToList().ForEach(h => ConsoleWriter.WriteLine($"{h.User.Name} - {h.Points}"));
                }
                else
                {
                    ConsoleWriter.WriteLine(Constants.NoScoresToShow);
                }
                ConsoleWriter.WriteEmptyLine();
                ConsoleWriter.WriteLine(Constants.EscapeToReturnToPreviousMenu);
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
            
        }

        public void ShowScoresForUser(string username, ICollection<HighScore> userHighscores)
        {
            if (!userHighscores.Any())
            {
                ConsoleWriter.WriteLine(Constants.NoSuchUserOrNoScores);
            }
            else
            {
                foreach (var score in userHighscores.OrderByDescending(s => s.Points))
                {
                    ConsoleWriter.WriteLine($"{score.Points} - {score.Date:d}");
                }
            }
            ConsoleWriter.WriteEmptyLine();
            ConsoleWriter.WriteLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }

        public void ShowCredits()
        {
            ConsoleWriter.WriteLine(Constants.Credits);
            ConsoleWriter.WriteLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }

        public void ShowHowToPlay()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleWriter.WriteLine(Constants.LeftArrow);
            ConsoleWriter.WriteLine(Constants.RightArrow);
            ConsoleWriter.WriteLine(Constants.UpArrow);
            ConsoleWriter.WriteLine(Constants.DownArrow);
            ConsoleWriter.WriteLine(Constants.Space);
            ConsoleWriter.WriteLine(Constants.EscapeToReturnToPreviousMenu);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}