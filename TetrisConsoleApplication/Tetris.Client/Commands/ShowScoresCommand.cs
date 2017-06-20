namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Services;

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
                this.menuService.ShowScoresForUser(AuthenticationManager.GetCurrentUser().Name);
            }
        }
    }
}