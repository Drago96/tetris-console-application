namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Services;

    class ShowHighScoresCommand : ICommand
    {
        private readonly MenuService menuService;

        public ShowHighScoresCommand(MenuService menuService)
        {
            this.menuService = menuService;
        }

        public void Execute()
        {
            this.menuService.ShowHighScores();
        }
    }
}