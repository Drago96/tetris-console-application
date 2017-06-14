using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Services.Contracts;

namespace Tetris.Services
{
    public class BoardStateService : IBoardStateService
    {
           
        public ICurrentTetromino MoveTetrominoDown(IBoard board,ICurrentTetromino currentTetromino)
        {
            if (IsTetrominoMoveDownPossible(board,currentTetromino))
            {
                for (int j = currentTetromino.TetrominoAxisX; j < currentTetromino.TetrominoAxisX + currentTetromino.Blocks.GetLength(0); j++)
                {
                    for (int i = currentTetromino.TetrominoAxisY; i < currentTetromino.TetrominoAxisY + currentTetromino.Blocks.GetLength(1); i++)
                    {
                        board.Blocks[j, i] = 0;
                    }
                }
                currentTetromino.TetrominoAxisX++;
                for (int i = currentTetromino.TetrominoAxisX;i < currentTetromino.TetrominoAxisX + currentTetromino.Blocks.GetLength(0) ;i++)
                {
                    for (int j = currentTetromino.TetrominoAxisY;j < currentTetromino.TetrominoAxisY+currentTetromino.Blocks.GetLength(1);j++)
                    {
                        if (board.Blocks[i, j] == 0)
                        {
                            board.Blocks[i, j] = currentTetromino.Blocks[i - currentTetromino.TetrominoAxisX,j - currentTetromino.TetrominoAxisY];
                        }

                    }
                }
                return currentTetromino;
            }
            else
            {
                return null;
            }
            
        }

        public bool IsTetrominoMoveDownPossible(IBoard board, ICurrentTetromino currentTetromino)
        {

            if (currentTetromino.TetrominoAxisX + currentTetromino.Blocks.GetLength(0) >= board.Blocks.GetLength(0) )
            {
                return false;
            }
            
            for (int i = currentTetromino.TetrominoAxisY;i < currentTetromino.TetrominoAxisY + currentTetromino.Blocks.GetLength(1);i++)
            {
                if (currentTetromino.Blocks[currentTetromino.Blocks.GetLength(0) - 1, i - currentTetromino.TetrominoAxisY] == 1 &&
                    board.Blocks[currentTetromino.TetrominoAxisX + currentTetromino.Blocks.GetLength(0), i] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public ICurrentTetromino SpawnTetromino(ITetromino tetromino, IBoard board,ICurrentTetromino currentTetromino)
        {

            int tetrominoSpawnPoint = (int)(board.Width / 2 - Math.Ceiling((double)tetromino.Blocks.GetLength(1) / 2));
            if (this.IsSpawnPossible(tetromino,board, tetrominoSpawnPoint,currentTetromino))
            {
                for (int i = 0; i < tetromino.Blocks.GetLength(0); i++)
                {
                    for (int j = tetrominoSpawnPoint; j < tetrominoSpawnPoint + tetromino.Blocks.GetLength(1); j++)
                    {
                        if (tetromino.Blocks[i, j - tetrominoSpawnPoint] == 1)
                        {
                            board.Blocks[i, j] = 1;
                        }
                    }
                }
                return new CurrentTetromino(tetromino.Blocks,0,tetrominoSpawnPoint);
            }

            return currentTetromino;
        }

        private bool IsSpawnPossible(ITetromino tetromino, IBoard board,  int tetrominoSpawnPoint, ICurrentTetromino currentTetromino)
        {
            if (currentTetromino != null)
            {
                return false;
            }
            for (int i = 0; i < tetromino.Blocks.GetLength(0); i++)
            {
                for (int j = tetrominoSpawnPoint; j < tetrominoSpawnPoint + tetromino.Blocks.GetLength(1); j++)
                {
                    if (board.Blocks[i, j] == 1 && tetromino.Blocks[i, j - tetrominoSpawnPoint] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        
    }
}
