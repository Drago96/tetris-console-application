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

        public void MoveTetrominoDown()
        {
            if (IsTetrominoMoveDownPossible())
            {
                for (int i = Board.SpawnedTetromino.TetrominoAxisY;
                    i < Board.SpawnedTetromino.TetrominoAxisY + Board.SpawnedTetromino.Tetromino.Blocks.GetLength(1);
                    i++)
                {
                    Board.Grid[Board.SpawnedTetromino.TetrominoAxisX, i] = 0;
                }
                Board.SpawnedTetromino.TetrominoAxisX++;
                for (int i = Board.SpawnedTetromino.TetrominoAxisX;
                    i < Board.SpawnedTetromino.TetrominoAxisX + Board.SpawnedTetromino.Tetromino.Blocks.GetLength(0) ;
                    i++)
                {
                    for (int j = Board.SpawnedTetromino.TetrominoAxisY;
                        j < Board.SpawnedTetromino.TetrominoAxisY +
                        Board.SpawnedTetromino.Tetromino.Blocks.GetLength(1);
                        j++)
                    {

                            Board.Grid[i, j] =
                                Board.SpawnedTetromino.Tetromino.Blocks[i - Board.SpawnedTetromino.TetrominoAxisX,
                                    j - Board.SpawnedTetromino.TetrominoAxisY];
                        
                    }
                }
                
            }
            else
            {
                Board.SpawnedTetromino = null;
            }
        }

        public bool IsTetrominoMoveDownPossible()
        {

            int spawnedTetrominoAxisY = Board.SpawnedTetromino.TetrominoAxisY;
            int spawnedTetrominoAxisX = Board.SpawnedTetromino.TetrominoAxisX;
            if (spawnedTetrominoAxisX + Board.SpawnedTetromino.Tetromino.Blocks.GetLength(0) >= Board.Grid.GetLength(0) )
            {
                return false;
            }
            
            for (int i = spawnedTetrominoAxisY;
                i < spawnedTetrominoAxisY + Board.SpawnedTetromino.Tetromino.Blocks.GetLength(1);
                i++)
            {
                if (Board.SpawnedTetromino.Tetromino.Blocks[
                        Board.SpawnedTetromino.Tetromino.Blocks.GetLength(0) - 1, i - spawnedTetrominoAxisY] == 1 &&
                    Board.Grid[spawnedTetrominoAxisX + Board.SpawnedTetromino.Tetromino.Blocks.GetLength(0), i] == 1)
                {
                    return false;
                }
            }
            return true;
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
                this.Board.SpawnedTetromino = new SpawnedTetrominoInfo(tetromino,0,tetrominoSpawnPoint);
            }
            else
            {
                this.EndGame();
            }
            
        }

        private bool IsSpawnPossible(Board board, ITetromino tetromino, int tetrominoSpawnPoint)
        {
            if (Board.SpawnedTetromino != null)
            {
                return false;
            }
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

        private void EndGame()
        {
            
        }
    }
}
