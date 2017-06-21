using System;

namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Services;

    class ShowCreditsCommand : ICommand
    {
        private readonly MenuService menuService;

        public ShowCreditsCommand(MenuService menuService)
        {
            this.menuService = menuService;
        }

        public void Execute()
        {
            this.menuService.ShowCredits();
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}