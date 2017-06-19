namespace Tetris.Client
{
    using System;
    using System.ComponentModel;
    using Models.Enums;
    using Services.IO;
    using Utilities;

    public class MainMenu
    {
        private static readonly ConsoleWriter ConsoleWriter = new ConsoleWriter();
        public static void ShowMenu()
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
                ConsoleWriter.PrintLine(Constants.ChooseAction);

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
                    Console.Clear();
                    CommandParser.ParseCommand(currentCursorPos);
                }
                PrintMenuOptions(currentCursorPos);
                pressedKey = Console.ReadKey();
            }
        }

        private static void PrintMenuOptions(int currentCursorPos)
        {
            var counter = 1;
            foreach (var menuOption in Enum.GetValues(typeof(MenuOptions)))
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
    }
}
