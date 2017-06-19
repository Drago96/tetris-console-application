using System;
using Tetris.Client.Contracts;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Services;
using Tetris.Services.Contracts;
using Tetris.Utilities;
using System.Linq;
using Tetris.Data;
using Tetris.Models.Entities;

namespace Tetris.Client
{
    using Services.Services;

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
            this.BoardService = new BoardService();
        }

        private IGameService GameService { get; set; }
        private ICurrentTetrominoService CurrentTetrominoService { get; set; }
        private MenuService MenuService { get; set; }
        private IOutputService OutputService { get; set; }
        private ITetrominoService TetrominoService { get; set; }
        private UserService UserService { get; set; }
        private BoardService BoardService;

        public void Run()
        {
            //need to register first
            if (!AuthenticationManager.IsAuthenticated())
            {
                Console.WriteLine("Please enter your name...");
                var username = Console.ReadLine();

                User user = new User()
                {
                    Name = username
                };

                using (var context = new TetrisDbContext())
                {
                    if (context.Users.Any(u => u.Name == username))
                    {
                        var userFromDb = context.Users.First(u => u.Name == username);
                        AuthenticationManager.Login(userFromDb);
                    }
                    else
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        AuthenticationManager.Login(user);
                    }
                }
            }
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
                if (Console.KeyAvailable)
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
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        game.CurrentTetromino = CurrentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);

                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        while (game.CurrentTetromino != null)
                        {
                            game.CurrentTetromino = CurrentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                        }
                    }

                    OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                        TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));

                }

                if (game.DropTimer.ElapsedMilliseconds > 200)
                {
                    game.CurrentTetromino = CurrentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                    if (game.CurrentTetromino == null)
                    {
                        int linesCleared = BoardService.UpdateBoard(game.Board);
                        GameService.UpdateScoreInfo(game,linesCleared);
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
