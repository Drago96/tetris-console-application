using System;

namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Services;

    internal class HowToPlayCommand : ICommand
    {
        private readonly MenuService menuService;

        public HowToPlayCommand(MenuService menuService)
        {
            this.menuService = menuService;
        }

        public void Execute()
        {
            this.menuService.ShowHowToPlay();
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}