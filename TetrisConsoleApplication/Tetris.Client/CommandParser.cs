using System.Linq;
using Tetris.Data;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Models.Entities;
using Tetris.Services.Contracts;
using Tetris.Utilities;

namespace Tetris.Client
{
    using System;
    using Contracts;
    using Services;
    using Services.IO;
    using Services.Services;

    public class CommandParser
    {
        private readonly MenuService menuService = new MenuService();
        private readonly ConsoleWriter consoleWriter = new ConsoleWriter();
        private IGameService GameService { get; set; }
        private ICurrentTetrominoService CurrentTetrominoService { get; set; }
        private MenuService MenuService { get; set; }
        private IOutputService OutputService { get; set; }
        private ITetrominoService TetrominoService { get; set; }
        private UserService UserService { get; set; }
        private BoardService BoardService { get; set; }

        public CommandParser()
        {
            this.GameService = new GameService();
            this.CurrentTetrominoService = new CurrentTetrominoService();
            this.MenuService = new MenuService();
            this.OutputService = new OutputService();
            this.TetrominoService = new TetrominoService();
            this.UserService = new UserService();
            this.BoardService = new BoardService();
        }

        public void ParseCommand(int action)
        {          
            switch (action)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    menuService.ShowHowToPlay();
                    break;
                case 3:
                    if (AuthenticationManager.IsAuthenticated())
                    {
                        menuService.ShowScoresForUser(AuthenticationManager.GetCurrentUser().Name);
                    }
                    break;
                case 4:
                    menuService.ShowTop10();
                    break;
                case 5:
                    menuService.ShowCredits();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private void LoginUser()
        {
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
        }

        private void StartGame()
        {

            LoginUser();

            ConsoleKeyInfo key = new ConsoleKeyInfo();


            IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite, Constants.TetrominoDropRate);

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

                if (game.DropTimer.ElapsedMilliseconds > game.TetrominoDropRate)
                {
                    game.CurrentTetromino = CurrentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                    if (game.CurrentTetromino == null)
                    {
                        int linesCleared = BoardService.UpdateBoard(game.Board);
                        GameService.UpdateScoreInfo(game, linesCleared);
                        game.CurrentTetromino = CurrentTetrominoService.SpawnTetromino(
                            TetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory), game.Board,
                            game.CurrentTetromino);
                        if (game.CurrentTetromino == null)
                        {
                            OutputService.DisplayGameOver(game);
                            break;
                        }
                    }

                    OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                        TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
                    game.DropTimer.Restart();
                }


            }
        }
    }
}
