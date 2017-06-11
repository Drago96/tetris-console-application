using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class GameService
    {
        public void InitializeGame()
        {
            Board board = new Board(Constants.BoardWidth,Constants.BoardHeight);
            BoardService boardService = new BoardService();
            boardService.DrawBoard(board);
        }
    }
}
