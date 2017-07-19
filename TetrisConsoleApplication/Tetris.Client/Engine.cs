namespace Tetris.Client
{
    using System;
    using Tetris.Client.Contracts;
    using Tetris.Models;
    using Tetris.Services;

    public class Engine : IEngine
    {
        private readonly ICommandParser commandParser;
        private readonly MenuService menuService;

        public Engine()
        {
            this.commandParser = new CommandParser();
            this.menuService = new MenuService();
        }

        public void Run()
        {
            Menu menu = new Menu();
            var pressedKey = new ConsoleKeyInfo();
            while (true)
            {
                Console.Clear();
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (menu.CurrentCursorPosition < menu.MenuOptions.Count)
                    {
                        menu.CurrentCursorPosition++;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (menu.CurrentCursorPosition > 1)
                    {
                        menu.CurrentCursorPosition--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    this.commandParser.ParseCommand(menu.CurrentCursorPosition);
                }
                Console.Clear();
                this.menuService.PrintMenuOptions(menu);
                pressedKey = Console.ReadKey();
            }
        }
    }
}