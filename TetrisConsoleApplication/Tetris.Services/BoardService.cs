using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.Contracts;

namespace Tetris.Services
{
    public class BoardService
    {
        public BoardService(Board board)
        {
            this.Board = board;
        }

        public Board Board { get; set; }

        public void MoveTetromino(ITetromino tetromino)
        {
            
        }

        public void SpawnTetromino(ITetromino tetromino)
        {
            int tetrominoSpawnPoint =
                (int)(Board.Width / 2 - Math.Ceiling((double)tetromino.Blocks.GetLength(1) / 2));
            if (this.IsSpawnPossible(this.Board, tetromino, tetrominoSpawnPoint))
            {
                for (int i = 0; i < tetromino.Blocks.GetLength(0); i++)
                {
                    for (int j = tetrominoSpawnPoint; j < tetrominoSpawnPoint + tetromino.Blocks.GetLength(1); j++)
                    {
                        if (tetromino.Blocks[i, j - tetrominoSpawnPoint] == 1)
                        {
                            Board.Grid[i, j] = 1;
                        }
                    }
                }
            }
        }

        private bool IsSpawnPossible(Board board, ITetromino tetromino, int tetrominoSpawnPoint)
        {
            
            for (int i = 0; i < tetromino.Blocks.GetLength(0); i++)
            {
                for (int j = tetrominoSpawnPoint; j < tetrominoSpawnPoint + tetromino.Blocks.GetLength(1); j++)
                {
                    if (board.Grid[i, j] == 1 && tetromino.Blocks[i, j - tetrominoSpawnPoint] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
