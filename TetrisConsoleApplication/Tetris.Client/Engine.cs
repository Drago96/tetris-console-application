using System;
using Tetris.Client.Contracts;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Services;
using Tetris.Services.Contracts;
using Tetris.Utilities;
using System.Linq;
using Tetris.Data;
using Tetris.Models.Entities;
using Tetris.Models.Enums;
using Tetris.Services.IO;

namespace Tetris.Client
{
    using Services.Services;

    public class Engine : IEngine
    {
        private readonly CommandParser commandParser;
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
                    commandParser.ParseCommand(menu.CurrentCursorPosition);
                }
                Console.Clear();
                menuService.PrintMenuOptions(menu);
                pressedKey = Console.ReadKey();
            }

        }

        
    }
}
