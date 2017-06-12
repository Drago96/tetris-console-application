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
    public class BoardService
    {
        public BoardService(Board board)
        {
            this.Board = board;
            this.TetrominoService = new TetrominoService();
        }

        public Board Board { get; set; }
        public TetrominoService TetrominoService { get; set; }

        public void DrawBoard()
        {
            for (int i = 0; i < Constants.BoardHeight; ++i)
            {
                Console.SetCursorPosition(1, i);
                for (int j = 0; j < Constants.BoardWidth; j++)
                {
                    Console.Write(this.Board.Grid[i,j] == 0 ? " " : Constants.BlockSprite.ToString());
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
                Console.Write(Constants.BoardRearWallSprite);
                Console.SetCursorPosition(Constants.BoardHeight - 2, lengthCount);
                Console.Write(Constants.BoardRearWallSprite);
            }
            Console.SetCursorPosition(0, Constants.BoardHeight);
            for (int widthCount = 0; widthCount <= Board.Width; widthCount++)
            {
                Console.Write(Constants.BoardBottomSprite);
            }
            
        }

        public void DisplayInfo()
        {
            Console.SetCursorPosition(Board.Height + 2, 0);
            Console.WriteLine(Constants.LevelLable + Board.Level);
            Console.SetCursorPosition(Board.Height + 2, 1);
            Console.WriteLine(Constants.ScoreLable + Board.Score);
            Console.SetCursorPosition(Board.Height + 2, 2);
            Console.WriteLine(Constants.LinesClearedLable + Board.LinesCleared);
        }

        public void DisplayNextTetromino()
        {
            ITetromino nextTetromino = TetrominoService.PeekNextTetromino();
            Console.SetCursorPosition(Board.Height + 2, 4);
            nextTetromino.DrawTetromino();
        }
        
    }
}
