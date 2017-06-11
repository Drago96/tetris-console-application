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
        public void DrawBoard(Board board)
        {
            for (int lengthCount = 0; lengthCount < board.Height; ++lengthCount)
            {
                Console.SetCursorPosition(0, lengthCount);
                Console.Write(Constants.BoardRearWallSprite);
                Console.SetCursorPosition(Constants.BoardHeight - 2, lengthCount);
                Console.Write(Constants.BoardRearWallSprite);
            }
            Console.SetCursorPosition(0, Constants.BoardHeight);
            for (int widthCount = 0; widthCount <= board.Width; widthCount++)
            {
                Console.Write(Constants.BoardBottomSprite);
            }
        }
    }
}
