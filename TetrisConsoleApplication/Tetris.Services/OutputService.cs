using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class OutputService
    {
        public OutputService(Board board,ScoreInfo scoreInfo)
        {
            this.Board = board;
            this.ScoreInfo = scoreInfo;
            this.TetrominoService = new TetrominoService();
        }

        public ScoreInfo ScoreInfo { get; set; }
        public Board Board { get; set; }
        public TetrominoService TetrominoService { get; set; }

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
                    Console.Write(this.Board.Blocks[i,j] == 0 ? " " : Board.BoardSprite.ToString());
                    Console.Write(" ");
                }
                
                Console.WriteLine();
            }
        }

        public void DrawBorder()
        {
            for (int lengthCount = 0; lengthCount < Board.Height; ++lengthCount)
            {
                Console.SetCursorPosition(0, lengthCount);
                Console.Write(Board.BoardBorder.RearWallSprite);
                Console.SetCursorPosition(Board.Height - 2, lengthCount);
                Console.Write(Board.BoardBorder.RearWallSprite);
            }
            Console.SetCursorPosition(0, Board.Height);
            for (int widthCount = 0; widthCount <= Board.Width; widthCount++)
            {
                Console.Write(Board.BoardBorder.BottomSprite);
            }
            
        }

        public void DisplayInfo()
        {
            Console.SetCursorPosition(Board.Height + 2, 0);
            Console.WriteLine(Constants.LevelLable + ScoreInfo.Level);
            Console.SetCursorPosition(Board.Height + 2, 1);
            Console.WriteLine(Constants.ScoreLable + ScoreInfo.Score);
            Console.SetCursorPosition(Board.Height + 2, 2);
            Console.WriteLine(Constants.LinesClearedLable + ScoreInfo.LinesCleared);
        }

        public void DisplayNextTetromino()
        {
            ITetromino nextTetromino = TetrominoService.PeekNextTetromino();
            Console.SetCursorPosition(Board.Height + 2, 4);
            nextTetromino.DrawTetromino();
        }
        
    }
}
