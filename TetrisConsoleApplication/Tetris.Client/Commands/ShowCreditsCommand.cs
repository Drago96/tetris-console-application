using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Client.Contracts;
using Tetris.Services.Services;

namespace Tetris.Client.Commands
{
    class ShowCreditsCommand : ICommand
    {
        private readonly MenuService menuService;

        public ShowCreditsCommand(MenuService menuService)
        {
            this.menuService = menuService;
        }

        public void Execute()
        {
            menuService.ShowCredits();
        }
    }
}
