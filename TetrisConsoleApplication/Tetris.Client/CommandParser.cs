namespace Tetris.Client
{
    using System;
    using Tetris.Client.Commands;
    using Tetris.Client.Contracts;
    using Tetris.Services;

    public class CommandParser : ICommandParser
    {
        private readonly BoardOutputService boardOutputService;
        private readonly BoardService boardService;
        private readonly CurrentTetrominoService currentTetrominoService;
        private readonly GameService gameService;
        private readonly MenuService menuService;
        private readonly TetrominoService tetrominoService;
        private readonly UserService userService;
        private readonly HighScoreService highScoreService;

        public CommandParser()
        {
            this.menuService = new MenuService();
            this.gameService = new GameService();
            this.currentTetrominoService = new CurrentTetrominoService();
            this.menuService = new MenuService();
            this.boardOutputService = new BoardOutputService();
            this.tetrominoService = new TetrominoService();
            this.userService = new UserService();
            this.boardService = new BoardService();
            this.highScoreService = new HighScoreService();
        }

        public void ParseCommand(int action)
        {
            switch (action)
            {
                case 1:
                    ICommand startGameCommand = new StartGameCommand(this.gameService, this.userService,
                        this.boardOutputService, this.tetrominoService, this.currentTetrominoService,
                        this.boardService);
                    startGameCommand.Execute();
                    break;

                case 2:
                    ICommand howToPlayCommand = new HowToPlayCommand(this.menuService);
                    howToPlayCommand.Execute();
                    break;

                case 3:
                    ICommand showScoresCommand = new ShowScoresCommand(this.menuService, this.userService);
                    showScoresCommand.Execute();
                    break;

                case 4:
                    ICommand showHighScoresCommand = new ShowHighScoresCommand(this.menuService, this.highScoreService);
                    showHighScoresCommand.Execute();
                    break;

                case 5:
                    ICommand showCreditsCommand = new ShowCreditsCommand(this.menuService);
                    showCreditsCommand.Execute();
                    break;

                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}