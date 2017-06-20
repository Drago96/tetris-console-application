using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Client.Contracts;
using Tetris.Services;
using Tetris.Services.Services;

namespace Tetris.Client.Commands
{
    class ShowScoresCommand : ICommand
    {
        private readonly MenuService menuService;

        public ShowScoresCommand(MenuService menuService)
        {
            this.menuService = menuService;
        }

        public void Execute()
        {
            if (AuthenticationManager.IsAuthenticated())
            {
                menuService.ShowScoresForUser(AuthenticationManager.GetCurrentUser().Name);
            }
        }
    }
}
