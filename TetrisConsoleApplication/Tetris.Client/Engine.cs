using System;
using Tetris.Client.Contracts;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Services;
using Tetris.Services.Contracts;
using Tetris.Utilities;

namespace Tetris.Client
{
    public class Engine : IEngine
    {
        public Engine()
        {
            this.GameService = new GameService();
            this.CurrentTetrominoService = new CurrentTetrominoService();
            this.MenuService = new MenuService();
            this.OutputService = new OutputService();
            this.TetrominoService = new TetrominoService();
            this.UserService = new UserService();
        }

        private IGameService GameService { get; set; }
        private ICurrentTetrominoService CurrentTetrominoService { get; set; }
        private MenuService MenuService { get; set; }
        private IOutputService OutputService { get; set; }
        private ITetrominoService TetrominoService { get; set; }
        private UserService UserService { get; set; }       

        public void Run()
        {
            StartGame();
        }

        private void StartGame()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();


            IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite);

            Console.CursorVisible = false;
            game.CurrentTetromino = CurrentTetrominoService.SpawnTetromino(
                TetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory), game.Board,
                game.CurrentTetromino);
            OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
            OutputService.StartGamePrompt(game);
            GameService.StartTimers(game);

            while (true)
            {
                if (game.DropTimer.ElapsedMilliseconds > 100)
                {

                    while (Console.KeyAvailable)
                    {
                        key = Console.ReadKey();

                        if (key.Key == ConsoleKey.RightArrow)
                        {
                            game.CurrentTetromino =
                                CurrentTetrominoService.MoveTetrominoRight(game.Board, game.CurrentTetromino);
                        }
                        else if (key.Key == ConsoleKey.LeftArrow)
                        {
                            game.CurrentTetromino =
                                CurrentTetrominoService.MoveTetrominoLeft(game.Board, game.CurrentTetromino);
                            OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                                TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
                        }
                        else if (key.Key == ConsoleKey.Spacebar)
                        {
                            game.CurrentTetromino =
                                CurrentTetrominoService.RotateTetromino(game.Board, game.CurrentTetromino);

                        }



                    }
                    game.CurrentTetromino = CurrentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                    if (game.CurrentTetromino == null)
                    {
                        game.CurrentTetromino = CurrentTetrominoService.SpawnTetromino(
                            TetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory), game.Board,
                            game.CurrentTetromino);
                    }
                    OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                        TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));

                    game.DropTimer.Restart();
                }


            }
        }
    }
}
