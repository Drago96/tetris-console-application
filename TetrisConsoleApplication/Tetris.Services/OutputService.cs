using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Services.Contracts;
using Tetris.Services.IO;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class OutputService
    {
        public OutputService()
        {
            this.ConsoleWriter = new ConsoleWriter();
        }

        public IOutputWriter ConsoleWriter { get; private set; }

        public void InitializeBoard(Board board, ScoreInfo scoreInfo,ITetromino tetromino)
        {
            this.DrawBorder(board);
            this.DrawBoard(board);
            this.DisplayInfo(board,scoreInfo);
            this.DisplayNextTetromino(board,tetromino);
        }

        public void DrawBoard(Board board)
        {
            for (int i = 0; i < board.Height; ++i)
            {
                Console.SetCursorPosition(1, i);
                for (int j = 0; j < board.Width; j++)
                {
                    this.ConsoleWriter.Print(board.Blocks[i, j] == 0 ? " " : board.BoardSprite.ToString());
                    this.ConsoleWriter.Print(" ");
                }

                this.ConsoleWriter.PrintEmptyLine();
            }
        }

        public void DrawBorder(Board board)
        {
            for (int lengthCount = 0; lengthCount < board.Height; ++lengthCount)
            {
                this.ConsoleWriter.PrintOnPosition(0, lengthCount, board.BoardBorder.RearWallSprite);
                this.ConsoleWriter.PrintOnPosition(board.Height - 2, lengthCount, board.BoardBorder.RearWallSprite);
            }

            Console.SetCursorPosition(0 , board.Height);
           
            for (int widthCount = 0; widthCount <= board.Width; widthCount++)
            {
                //this.ConsoleWriter.PrintOnPosition(0, Board.Height, Board.BoardBorder.BottomSprite); not working 
                Console.Write(board.BoardBorder.BottomSprite);
            }
        }

        public void DisplayInfo(Board board, ScoreInfo scoreInfo)
        {
            this.ConsoleWriter.PrintLineOnPosition(board.Height + 2, 0, Constants.LevelLable + scoreInfo.Level);
            this.ConsoleWriter.PrintLineOnPosition(board.Height + 2, 1, Constants.ScoreLable + scoreInfo.Score);
            this.ConsoleWriter.PrintLineOnPosition(board.Height + 2, 2, Constants.LinesClearedLable + scoreInfo.LinesCleared);
        }

        public void DisplayNextTetromino(Board board,ITetromino tetromino)
        {
            Console.SetCursorPosition(board.Height + 2, 4);
            ClearArea();
            Console.SetCursorPosition(board.Height + 2, 4);
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

        public void StartGamePrompt(Game game)
        {
            Console.SetCursorPosition(game.Board.Height / 6, game.Board.Width / 2);
            ConsoleWriter.PrintLine(Constants.StartGamePromptMessage);
            Console.ReadKey(true);
        }
    }
}
