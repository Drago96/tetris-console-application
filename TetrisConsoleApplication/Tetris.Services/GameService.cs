namespace Tetris.Services
{
    using System;
    using Tetris.Models.Contracts;

    public class GameService
    {
        public void StartGame(IGame game, UserService userService, BoardOutputService boardOutputService,
            TetrominoService tetrominoService, CurrentTetrominoService currentTetrominoService,
            BoardService boardService)
        {
            userService.LoginUser();

            ConsoleKeyInfo key = new ConsoleKeyInfo();


            Console.CursorVisible = false;
            boardOutputService.InitializeBoard(game.Board, game.ScoreInfo,
                tetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
            boardOutputService.StartGamePrompt(game);
            game.CurrentTetromino = currentTetrominoService.SpawnTetromino(
                tetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory), game.Board,
                game.CurrentTetromino);
            this.StartTimers(game);

            while (true)
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
                        boardOutputService.InitializeBoard(game.Board, game.ScoreInfo,
                            tetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
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

                if (game.DropTimer.ElapsedMilliseconds > game.TetrominoDropRate)
                {
                    game.CurrentTetromino =
                        currentTetrominoService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                    if (game.CurrentTetromino == null)
                    {
                        int linesCleared = boardService.UpdateBoard(game.Board);
                        this.UpdateScoreInfo(game, linesCleared);
                        game.CurrentTetromino = currentTetrominoService.SpawnTetromino(
                            tetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory),
                            game.Board,
                            game.CurrentTetromino);
                        if (game.CurrentTetromino == null)
                        {
                            userService.AddScore(AuthenticationManager.GetCurrentUser().Name, game.ScoreInfo.Score);
                            AuthenticationManager.Logout();
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

        public void StartTimers(IGame game)
        {
            game.DropTimer.Start();
        }

        public void UpdateScoreInfo(IGame game, int lines)
        {
            game.ScoreInfo.Score += lines * game.ScoreInfo.Level * 10;
            int progressionToNextLevel = game.ScoreInfo.LinesCleared % 5;
            if (progressionToNextLevel + lines >= 5)
            {
                game.ScoreInfo.Level++;
                game.TetrominoDropRate -= 25;
            }
            game.ScoreInfo.LinesCleared += lines;
        }
    }
}