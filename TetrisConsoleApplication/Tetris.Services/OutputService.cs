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
        public OutputService(Board board, ScoreInfo scoreInfo)
        {
            this.Board = board;
            this.ScoreInfo = scoreInfo;
            this.TetrominoService = new TetrominoService();
            this.ConsoleWriter = new ConsoleWriter();
        }

        public ScoreInfo ScoreInfo { get; set; }
        public IBoard Board { get; set; }
        public ITetrominoService TetrominoService { get; set; }
        public IOutputWriter ConsoleWriter { get; private set; }

        public void InitializeBoard()
        {
            this.DrawBorder();
            this.DrawBoard();
            this.DisplayInfo();
            this.DisplayNextTetromino();
        }

        public void DrawBoard()
        {
            for (int i = 0; i < Board.Height; ++i)
            {
                Console.SetCursorPosition(1, i);
                for (int j = 0; j < Board.Width; j++)
                {
                    this.ConsoleWriter.Print(this.Board.Blocks[i, j] == 0 ? " " : Board.BoardSprite.ToString());
                    this.ConsoleWriter.Print(" ");
                }

                this.ConsoleWriter.PrintEmptyLine();
            }
        }

        public void DrawBorder()
        {
            for (int lengthCount = 0; lengthCount < Board.Height; ++lengthCount)
            {
                this.ConsoleWriter.PrintOnPosition(0, lengthCount, Board.BoardBorder.RearWallSprite);
                this.ConsoleWriter.PrintOnPosition(Board.Height - 2, lengthCount, Board.BoardBorder.RearWallSprite);
            }

            Console.SetCursorPosition(0 , Board.Height);
           
            for (int widthCount = 0; widthCount <= Board.Width; widthCount++)
            {
                //this.ConsoleWriter.PrintOnPosition(0, Board.Height, Board.BoardBorder.BottomSprite); not working 
                Console.Write(Board.BoardBorder.BottomSprite);
            }
        }

        public void DisplayInfo()
        {
            this.ConsoleWriter.PrintLineOnPosition(Board.Height + 2, 0, Constants.LevelLable + ScoreInfo.Level);
            this.ConsoleWriter.PrintLineOnPosition(Board.Height + 2, 1, Constants.ScoreLable + ScoreInfo.Score);
            this.ConsoleWriter.PrintLineOnPosition(Board.Height + 2, 2, Constants.LinesClearedLable + ScoreInfo.LinesCleared);
        }

        public void DisplayNextTetromino()
        {
            ITetromino nextTetromino = TetrominoService.PeekNextTetromino();
            Console.SetCursorPosition(Board.Height + 2, 4);
            nextTetromino.DrawTetromino();
        }

    }
}
