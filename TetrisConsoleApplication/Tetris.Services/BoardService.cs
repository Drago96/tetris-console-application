using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class BoardService
    {
        public BoardService(Board board)
        {
            this.Board = board;
        }

        public void DrawBoard()
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
            this.DisplayInfo();
        }

        private void DisplayInfo()
        {
            Console.SetCursorPosition(Board.Height + 2, 0);
            Console.WriteLine(Constants.LevelLable + Board.Level);
            Console.SetCursorPosition(Board.Height + 2, 1);
            Console.WriteLine(Constants.ScoreLable + Board.Score);
            Console.SetCursorPosition(Board.Height + 2, 2);
            Console.WriteLine(Constants.LinesClearedLable + Board.LinesCleared);
        }


        public Board Board { get; set; }
        
    }
}
