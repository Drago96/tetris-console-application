namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Models;
    using Tetris.Models.Contracts;
    using Tetris.Services;
    using Tetris.Utilities;

    class StartGameCommand : ICommand
    {
        private readonly BoardOutputService boardOutputService;
        private readonly BoardService boardService;
        private readonly CurrentTetrominoService currentTetrominoService;
        private readonly GameService gameService;
        private readonly TetrominoService tetrominoService;
        private readonly UserService userService;

        public StartGameCommand(GameService gameService, UserService userService, BoardOutputService boardOutputService,
            TetrominoService tetrominoService, CurrentTetrominoService currentTetrominoService,
            BoardService boardService)
        {
            this.gameService = gameService;
            this.userService = userService;
            this.boardOutputService = boardOutputService;
            this.tetrominoService = tetrominoService;
            this.currentTetrominoService = currentTetrominoService;
            this.boardService = boardService;
        }

        public void Execute()
        {
            IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite, Constants.TetrominoDropRate);
            this.gameService.StartGame(game, this.userService, this.boardOutputService, this.tetrominoService,
                this.currentTetrominoService, this.boardService);
        }
    }
}