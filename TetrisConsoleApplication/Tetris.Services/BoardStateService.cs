using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.Contracts;

namespace Tetris.Services
{
    public class BoardStateService
    {
        public BoardStateService(Board board)
        {
            this.Board = board;
        }

        public Board Board { get; set; }

        public void MoveTetrominoDown()
        {
            if (IsTetrominoMoveDownPossible())
            {
                for (int j = Board.CurrentTetromino.TetrominoAxisX; j < Board.CurrentTetromino.TetrominoAxisX + Board.CurrentTetromino.Blocks.GetLength(0); j++)
                {
                    for (int i = Board.CurrentTetromino.TetrominoAxisY; i < Board.CurrentTetromino.TetrominoAxisY + Board.CurrentTetromino.Blocks.GetLength(1); i++)
                    {
                        Board.Blocks[j, i] = 0;
                    }
                }
                Board.CurrentTetromino.TetrominoAxisX++;
                for (int i = Board.CurrentTetromino.TetrominoAxisX;i < Board.CurrentTetromino.TetrominoAxisX + Board.CurrentTetromino.Blocks.GetLength(0) ;i++)
                {
                    for (int j = Board.CurrentTetromino.TetrominoAxisY;j < Board.CurrentTetromino.TetrominoAxisY+Board.CurrentTetromino.Blocks.GetLength(1);j++)
                    {
                        if (Board.Blocks[i, j] == 0)
                        {
                            Board.Blocks[i, j] = Board.CurrentTetromino.Blocks[i - Board.CurrentTetromino.TetrominoAxisX,j - Board.CurrentTetromino.TetrominoAxisY];
                        }

                    }
                }
                
            }
            else
            {
                Board.CurrentTetromino = null;
            }
            
        }

        public bool IsTetrominoMoveDownPossible()
        {

            if (Board.CurrentTetromino.TetrominoAxisX + Board.CurrentTetromino.Blocks.GetLength(0) >= Board.Blocks.GetLength(0) )
            {
                return false;
            }
            
            for (int i = Board.CurrentTetromino.TetrominoAxisY;i < Board.CurrentTetromino.TetrominoAxisY + Board.CurrentTetromino.Blocks.GetLength(1);i++)
            {
                if (Board.CurrentTetromino.Blocks[Board.CurrentTetromino.Blocks.GetLength(0) - 1, i - Board.CurrentTetromino.TetrominoAxisY] == 1 &&
                    Board.Blocks[Board.CurrentTetromino.TetrominoAxisX + Board.CurrentTetromino.Blocks.GetLength(0), i] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public void SpawnTetromino(ITetromino tetromino)
        {
            int tetrominoSpawnPoint = (int)(Board.Width / 2 - Math.Ceiling((double)tetromino.Blocks.GetLength(1) / 2));
            if (this.IsSpawnPossible(this.Board, tetromino, tetrominoSpawnPoint))
            {
                for (int i = 0; i < tetromino.Blocks.GetLength(0); i++)
                {
                    for (int j = tetrominoSpawnPoint; j < tetrominoSpawnPoint + tetromino.Blocks.GetLength(1); j++)
                    {
                        if (tetromino.Blocks[i, j - tetrominoSpawnPoint] == 1)
                        {
                            Board.Blocks[i, j] = 1;
                        }
                    }
                }
                this.Board.CurrentTetromino = new CurrentTetromino(tetromino,0,tetrominoSpawnPoint);
            }
            
            
        }

        private bool IsSpawnPossible(Board board, ITetromino tetromino, int tetrominoSpawnPoint)
        {
            if (Board.CurrentTetromino != null)
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
