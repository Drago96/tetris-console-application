using System;
using Tetris.Services.IO;

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
            this.PromptUserLogin();
            Console.Clear();
            IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite, Constants.TetrominoDropRate);
            this.StartGame(game);
        }

        private void PromptUserLogin()
        {
            ConsoleWriter.WriteLine(Constants.EnterNamePrompt);
            var username = Console.ReadLine();
            userService.LoginUser(username);
        }

        public void StartGame(IGame game)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            this.InitializeGame(game);
            game.CurrentTetromino = currentTetrominoService.SpawnTetromino(
                tetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory), game.Board,game.CurrentTetromino);
            while (true)
            {
                this.ProcessNextMove(game, key);
                if (game.DropTimer.ElapsedMilliseconds > game.TetrominoDropRate)
                {
                    game.CurrentTetromino =
                        currentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                    if (game.CurrentTetromino == null)
                    {
                        this.UpdateGameState(game);
                        game.CurrentTetromino = currentTetrominoService.SpawnTetromino(
                            tetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory),
                            game.Board,game.CurrentTetromino);
                        if (game.CurrentTetromino == null)
                        {
                            this.AddScoreToDatabase(game);
                            boardOutputService.DisplayGameOver(game);
                            break;
                        }
                    }

                    boardOutputService.InitializeBoard(game.Board, game.ScoreInfo,
                        tetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
                    game.DropTimer.Restart();
                }
            }
        }

        private void UpdateGameState(IGame game)
        {
            int linesCleared = boardService.UpdateBoard(game.Board);
            gameService.UpdateScoreInfo(game, linesCleared);
        }

        private void InitializeGame(IGame game)
        {
            boardOutputService.InitializeBoard(game.Board, game.ScoreInfo,
                tetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
            boardOutputService.StartGamePrompt(game);
            gameService.StartTimers(game);
        }

        private void ProcessNextMove(IGame game, ConsoleKeyInfo key)
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow)
                {
                    game.CurrentTetromino =
                        currentTetrominoService.MoveTetrominoRight(game.Board, game.CurrentTetromino);
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    game.CurrentTetromino =
                        currentTetrominoService.MoveTetrominoLeft(game.Board, game.CurrentTetromino);
                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    game.CurrentTetromino =
                        currentTetrominoService.RotateTetromino(game.Board, game.CurrentTetromino);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    game.CurrentTetromino =
                        currentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    while (game.CurrentTetromino != null)
                    {
                        game.CurrentTetromino =
                            currentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                    }
                }
                boardOutputService.InitializeBoard(game.Board, game.ScoreInfo,
                    tetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
            }
        }

        private void AddScoreToDatabase(IGame game)
        {
            userService.AddScore(AuthenticationManager.GetCurrentUser().Name, game.ScoreInfo.Score);
            AuthenticationManager.Logout();
        }

        
    }
}