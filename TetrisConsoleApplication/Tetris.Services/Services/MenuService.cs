namespace Tetris.Services
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Data;
    using Models.Enums;

    public class MenuService
    {
        public delegate void StartNewGame();
        public event StartNewGame StartGame;

        public void InitializeMenu()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.CursorVisible = false;
            var startCursorPos = 1;
            var currentCursorPos = startCursorPos;
            var menuElementsCount = Enum.GetNames(typeof(MenuOptions)).Length;
            Console.SetCursorPosition(0, currentCursorPos);
            var pressedKey = new ConsoleKeyInfo();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose an action...");

                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (currentCursorPos < menuElementsCount)
                    {
                        currentCursorPos++;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (currentCursorPos > startCursorPos)
                    {
                        currentCursorPos--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    ChooseAction(currentCursorPos);
                }

                PrintMenuOptions(currentCursorPos);
                pressedKey = Console.ReadKey();
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
                    return ((DescriptionAttribute) attrs[0]).Description;
                }
            }
            return enumValue.ToString();
        }

        public void ShowTop10()
        {
            Console.Clear();
            using (var context = new TetrisDbContext())
            {
                var highscores = context.HighScores.OrderByDescending(h => h.Points).Take(10).ToList();
                if (highscores.Count > 0)
                {
                    Console.WriteLine("TOP 10");
                    highscores.ForEach(h => Console.WriteLine($"{h.User.Name} - {h.Points}"));
                }
                else
                {
                    Console.WriteLine("There are no scores to show.");
                }
                Console.WriteLine();
                Console.WriteLine("Press ESC to go to the previous menu.");
                while (Console.ReadKey().Key != ConsoleKey.Escape){ }
                ShowMenu();
            }
        }

        public void ShowHighscoresForUser()
        {
            Console.Clear();
            Console.WriteLine("Please enter username.");
            var username = Console.ReadLine();
            UserService userService = new UserService();
            var userHighscores = userService.GetUserHighScoresByName(username);
            if (!userHighscores.Any())
            {
                Console.WriteLine($"{username} doesn't have any scores on the board.");
            }
            else
            {
                foreach (var score in userHighscores.OrderBy(s => s.Points))
                {
                    Console.WriteLine($"{score.Points} - {score.Date:d}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press ESC to go to the previous menu.");
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
            ShowMenu();

        }

        public void PrintMenuOptions(int currentCursorPos)
        {
            var counter = 1;
            foreach (var menuOption in Enum.GetValues(typeof(MenuOptions)))
            {
                if (currentCursorPos == counter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{GetMenuItemDescription(menuOption)}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{GetMenuItemDescription(menuOption)}");
                }
                counter++;
            }
        }

        public void ChooseAction(int action)
        {
            switch (action)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    ShowHighscoresForUser();
                    break;
                case 3:
                    ShowTop10();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
