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
        }


        public Board Board { get; set; }
        
    }
}
