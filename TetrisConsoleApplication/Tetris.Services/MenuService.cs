namespace Tetris.Services
{
    using System;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Models.Enums;

    public class MenuService
    {
        public void InitializeMenu()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
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
                    
                }

                PrintMenuOptions(currentCursorPos);
                pressedKey = Console.ReadKey();
            }
        }

        public static string GetMenuItemDescription(object enumValue)
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
            using (var context = new TetrisDbContext())
            {
                context.HighScores.OrderByDescending(h => h.Points).Take(10).ToList().ForEach(h => Console.WriteLine($"{h.User} - {h.Points}"));
            }
        }

        public void ShowHighscoresForUser()
        {
            Console.WriteLine("Please enter username");
            var username = Console.ReadLine();
            UserService userService = new UserService();
            var userHighscores = userService.GetUserHighScoresByName(username);
            if (userHighscores == null || userHighscores.Count() == 0)
            {
                Console.WriteLine($"{username} doesn't have any scores on the board.");
            }
            else
            {
                foreach (var score in userHighscores.OrderBy(s => s.Points))
                {
                    Console.WriteLine($"{score.Points} - {score.Date}");
                }
            }
            
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

        public void ChooseAction()
        {
            
        }
    }
}
