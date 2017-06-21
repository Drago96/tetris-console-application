namespace Tetris.Services
{
    using System;
    using IO;
    using Models;
    using Models.Contracts;
    using Utilities;

    public class BoardOutputService 
    {


        public void InitializeBoard(IBoard board, IScoreInfo scoreInfo, ITetromino tetromino)
        {
            this.DrawBorder(board);
            this.DrawBoard(board);
            this.DisplayInfo(board, scoreInfo);
            this.DisplayNextTetromino(board, tetromino);
        }

        public void DrawBoard(IBoard board)
        {
            for (int i = 0; i < board.Height; ++i)
            {
                Console.SetCursorPosition(1, i);
                for (int j = 0; j < board.Width; j++)
                {
                    ConsoleWriter.Write(board.Blocks[i, j] == 0 ? " " : board.BoardSprite.ToString());
                    ConsoleWriter.Write(" ");
                }

                ConsoleWriter.WriteEmptyLine();
            }
        }

        public void DrawBorder(IBoard board)
        {
            for (int lengthCount = 0; lengthCount < board.Height; ++lengthCount)
            {
                ConsoleWriter.WriteOnPosition(0, lengthCount, board.BoardBorder.RearWallSprite.ToString());
                ConsoleWriter.WriteOnPosition(board.Width * 2 + 1, lengthCount, board.BoardBorder.RearWallSprite.ToString());
            }

            Console.SetCursorPosition(0, board.Height);
            int counter = 0;
            char[] bottomBorder = board.BoardBorder.BottomSprite.ToCharArray();
            for (int widthCount = 0; widthCount <= board.Width * 2 + 1; widthCount++)
            {
                ConsoleWriter.Write(bottomBorder[counter%bottomBorder.Length].ToString());
                counter++;
            }
        }

        public void DisplayInfo(IBoard board, IScoreInfo scoreInfo)
        {
            ConsoleWriter.WriteLineOnPosition(board.Width * 2 + 5, 0, Constants.LevelLable + scoreInfo.Level);
            ConsoleWriter.WriteLineOnPosition(board.Width * 2 + 5, 1, Constants.ScoreLable + scoreInfo.Score);
            ConsoleWriter.WriteLineOnPosition(board.Width * 2 + 5, 2, Constants.LinesClearedLable + scoreInfo.LinesCleared);
            if (AuthenticationManager.IsAuthenticated())
            {
                ConsoleWriter.WriteLineOnPosition(board.Width * 2 + 5, 3,
                    Constants.CurrentPlayerNameLabel + AuthenticationManager.GetCurrentUser().Name);
            }
        }

        public void DisplayNextTetromino(IBoard board, ITetromino tetromino)
        {
            Console.SetCursorPosition(board.Width * 2 + 5, 5);
            ClearArea();
            Console.SetCursorPosition(board.Width * 2 + 5, 5);
            tetromino.DrawTetromino();
        }

        private void ClearArea()
        {
            for (int i = 0; i < Constants.NextTetrominoLinesToClear; i++)
            {
                for (int j = 0; j < Constants.NextTetrominoColumnsToClear; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Console.CursorLeft - Constants.NextTetrominoColumnsToClear, Console.CursorTop + 1);
            }
        }

        public void StartGamePrompt(IGame game)
        {
            Console.SetCursorPosition(game.Board.Width / 2, game.Board.Height / 2 - 4);
            ConsoleWriter.WriteLine(Constants.StartGamePromptMessage);
            Console.ReadKey(true);
        }

        public void DisplayGameOver(IGame game)
        {
            Console.SetCursorPosition(game.Board.Width / 2 , game.Board.Height / 2 - 5);
            ConsoleWriter.WriteLine(new string(' ',10));
            Console.SetCursorPosition(game.Board.Width / 2, game.Board.Height / 2 - 4);
            ConsoleWriter.WriteLine(Constants.GameOverLabel);
            Console.SetCursorPosition(game.Board.Width / 2, game.Board.Height / 2 - 3);
            ConsoleWriter.WriteLine(new string(' ', 10));
            Console.ReadKey();

        }
    }
}
