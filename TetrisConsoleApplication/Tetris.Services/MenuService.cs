using System.Collections.Generic;
using Tetris.Models.Entities;

namespace Tetris.Services
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
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
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumValue.ToString();
        }

        public void ShowHighScores(ICollection<HighScore> highScores)
        {
            StringBuilder highScoresStringBuilder = new StringBuilder();
            if (highScores.Count > 0)
            {
                highScoresStringBuilder.AppendLine(Constants.Highscores);
                highScoresStringBuilder.AppendLine(Constants.BestHighScoresProperties);
                foreach (var h in highScores)
                {
                    highScoresStringBuilder.AppendLine($"{h.User.Name,-10} | {h.Points,-5}");
                }
            }
            else
            {
                highScoresStringBuilder.AppendLine(Constants.NoScoresToShow);
            }
            highScoresStringBuilder.AppendLine();
            highScoresStringBuilder.AppendLine(Constants.EscapeToReturnToPreviousMenu);
            ConsoleWriter.WriteLine(highScoresStringBuilder.ToString());
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }

        public void ShowScoresForUser(string username, ICollection<HighScore> userHighscores)
        {
            StringBuilder highScores = new StringBuilder();
            if (!userHighscores.Any())
            {
                highScores.AppendLine(Constants.NoSuchUserOrNoScores);
                highScores.AppendLine(Constants.EscapeToReturnToPreviousMenu);
                ConsoleWriter.WriteLine(highScores.ToString());
                return;
            }
            highScores.AppendLine(Constants.HighScoreProperties);
            foreach (var score in userHighscores.OrderByDescending(s => s.Points))
            {
                highScores.AppendLine($"{score.Points,-5} | {score.Date,-10:d}");
            }
            highScores.AppendLine();
            highScores.AppendLine(Constants.EscapeToReturnToPreviousMenu);
            ConsoleWriter.WriteLine(highScores.ToString());
        }

        public void ShowCredits()
        {
            StringBuilder showCredits = new StringBuilder();
            showCredits.AppendLine(Constants.Credits);
            showCredits.AppendLine(Constants.EscapeToReturnToPreviousMenu);
            ConsoleWriter.WriteLine(showCredits.ToString());
        }

        public void ShowHowToPlay()
        {
            Console.OutputEncoding = Encoding.UTF8;
            StringBuilder howToPlay = new StringBuilder();
            howToPlay.AppendLine(Constants.LeftArrow);
            howToPlay.AppendLine(Constants.RightArrow);
            howToPlay.AppendLine(Constants.UpArrow);
            howToPlay.AppendLine(Constants.DownArrow);
            howToPlay.AppendLine(Constants.Space);
            howToPlay.AppendLine(Constants.EscapeToReturnToPreviousMenu);
            ConsoleWriter.WriteLine(howToPlay.ToString());
        }
    }
}