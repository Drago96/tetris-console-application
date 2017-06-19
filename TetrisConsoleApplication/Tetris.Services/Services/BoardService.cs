using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;

namespace Tetris.Services.Services
{
    public class BoardService
    {
        public int UpdateBoard(IBoard board)
        {
            int lines = 0;
            for (int i = board.Height - 1; i >= 0; i--)
            {
                bool isFull = true;
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.Blocks[i, j] == 0)
                    {
                        isFull = false;
                    }
                }
                if (isFull)
                {
                    lines++;
                    ClearLine(board, i);
                    i++;
                }
            }
            return lines;
        }

        private void ClearLine(IBoard board, int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    board.Blocks[i, j] = board.Blocks[i - 1, j];
                }
            }
            for (int j = 0; j < board.Width; j++)
            {
                board.Blocks[0, j] = 0;
            }
        }
    }
}
