namespace Tetris.Services.Services
{
    using System;
    using Contracts;
    using IO;
    using Models;
    using Models.Contracts;
    using Utilities;

    public class BoardOutputService : IBoardOutputService
    {
        public BoardOutputService()
        {
            this.consoleWriter = new ConsoleWriter();
        }

        public IOutputWriter consoleWriter { get; private set; }

        public void InitializeBoard(IBoard board, ScoreInfo scoreInfo, ITetromino tetromino)
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
                    this.consoleWriter.Print(board.Blocks[i, j] == 0 ? " " : board.BoardSprite.ToString());
                    this.consoleWriter.Print(" ");
                }

                this.consoleWriter.PrintEmptyLine();
            }
        }

        public void DrawBorder(IBoard board)
        {
            for (int lengthCount = 0; lengthCount < board.Height; ++lengthCount)
            {
                this.consoleWriter.PrintOnPosition(0, lengthCount, board.BoardBorder.RearWallSprite);
                this.consoleWriter.PrintOnPosition(board.Height - 2, lengthCount, board.BoardBorder.RearWallSprite);
            }

            Console.SetCursorPosition(0, board.Height);

            for (int widthCount = 0; widthCount <= board.Width; widthCount++)
            {
                Console.Write(board.BoardBorder.BottomSprite);
            }
        }

        public void DisplayInfo(IBoard board, ScoreInfo scoreInfo)
        {
            this.consoleWriter.PrintLineOnPosition(board.Height + 2, 0, Constants.LevelLable + scoreInfo.Level);
            this.consoleWriter.PrintLineOnPosition(board.Height + 2, 1, Constants.ScoreLable + scoreInfo.Score);
            this.consoleWriter.PrintLineOnPosition(board.Height + 2, 2, Constants.LinesClearedLable + scoreInfo.LinesCleared);
            if (AuthenticationManager.IsAuthenticated())
            {
                this.consoleWriter.PrintLineOnPosition(board.Height + 2, 3,
                    Constants.CurrentPlayerNameLabel + AuthenticationManager.GetCurrentUser().Name);
            }
        }

        public void DisplayNextTetromino(IBoard board, ITetromino tetromino)
        {
            Console.SetCursorPosition(board.Height + 2, 5);
            ClearArea();
            Console.SetCursorPosition(board.Height + 2, 5);
            tetromino.DrawTetromino();
        }

        private void ClearArea()
        {
            for (int i = 0; i < Constants.LinesToClear; i++)
            {
                for (int j = 0; j < Constants.ColumnsToClear; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Console.CursorLeft - Constants.ColumnsToClear, Console.CursorTop + 1);
            }
        }

        public void StartGamePrompt(IGame game)
        {
            Console.SetCursorPosition(game.Board.Height / 6, game.Board.Width / 2);
            consoleWriter.PrintLine(Constants.StartGamePromptMessage);
            Console.ReadKey(true);
        }

        public void DisplayGameOver(IGame game)
        {
            Console.SetCursorPosition(game.Board.Height / 6 + 3 , game.Board.Width / 2 - 1);
            consoleWriter.PrintLine(new string(' ',10));
            Console.SetCursorPosition(game.Board.Height / 6 + 3, game.Board.Width / 2 );
            consoleWriter.PrintLine(Constants.GameOverLabel);
            Console.SetCursorPosition(game.Board.Height / 6 + 3 , game.Board.Width / 2 + 1 );
            consoleWriter.PrintLine(new string(' ', 10));
            Console.ReadKey();

        }
    }
}
