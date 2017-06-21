namespace Tetris.Services
{
    using System;
    using Tetris.Models;
    using Tetris.Models.Contracts;

    public class CurrentTetrominoService
    {
        public ICurrentTetromino RotateTetromino(IBoard board, ICurrentTetromino currentTetromino)
        {
            if (this.IsRotatePossible(board, currentTetromino))
            {
                this.ClearTetromino(currentTetromino, board);
                currentTetromino.Tetromino.Rotate();
                this.RespawnTetromino(currentTetromino, board);
                return currentTetromino;
            }
            if (this.IsTetrominoMoveRightPossible(board, currentTetromino))
            {
                this.MoveTetrominoRight(board, currentTetromino);
                if (this.IsRotatePossible(board, currentTetromino))
                {
                    this.ClearTetromino(currentTetromino, board);
                    currentTetromino.Tetromino.Rotate();
                    this.RespawnTetromino(currentTetromino, board);
                    return currentTetromino;
                }
                this.MoveTetrominoLeft(board, currentTetromino);
            }
            if (this.IsTetrominoMoveLeftPossible(board, currentTetromino))
            {
                this.MoveTetrominoLeft(board, currentTetromino);
                if (this.IsRotatePossible(board, currentTetromino))
                {
                    this.ClearTetromino(currentTetromino, board);
                    currentTetromino.Tetromino.Rotate();
                    this.RespawnTetromino(currentTetromino, board);
                    return currentTetromino;
                }
                this.MoveTetrominoRight(board, currentTetromino);
            }
            return currentTetromino;
        }

        private bool IsRotatePossible(IBoard board, ICurrentTetromino currentTetromino)
        {
            byte[,] nextRotation = currentTetromino.Tetromino.GetNextRotation();
            for (int i = currentTetromino.Row; i < currentTetromino.Row + currentTetromino.Blocks.GetLength(0); i++)
            {
                for (int j = currentTetromino.Col; j < currentTetromino.Col + currentTetromino.Blocks.GetLength(1); j++)
                {
                    if (!this.IsPointInBoardRange(board, i, j) &&
                        nextRotation[i - currentTetromino.Row, j - currentTetromino.Col] == 1)
                    {
                        return false;
                    }
                    if (this.IsPointInBoardRange(board, i, j) &&
                        nextRotation[i - currentTetromino.Row, j - currentTetromino.Col] == 1 &&
                        currentTetromino.Blocks[i - currentTetromino.Row, j - currentTetromino.Col] == 0 &&
                        board.Blocks[i, j] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public ICurrentTetromino MoveTetrominoRight(IBoard board, ICurrentTetromino currentTetromino)
        {
            if (this.IsTetrominoMoveRightPossible(board, currentTetromino))
            {
                this.ClearTetromino(currentTetromino, board);
                currentTetromino.Col++;
                this.RespawnTetromino(currentTetromino, board);
            }

            return currentTetromino;
        }

        private bool IsTetrominoMoveRightPossible(IBoard board, ICurrentTetromino currentTetromino)
        {
            if (currentTetromino == null)
            {
                return false;
            }
            int blockToCheckY = this.GetRightSideColumnToCheck(currentTetromino);
            if (!this.IsPointInBoardRange(board, currentTetromino.Row, blockToCheckY))
            {
                return false;
            }
            this.ClearTetromino(currentTetromino, board);
            for (int i = currentTetromino.Row; i < currentTetromino.Row + currentTetromino.Blocks.GetLength(0); i++)
            {
                for (int j = blockToCheckY - 1; j >= currentTetromino.Col; j--)
                {
                    if (currentTetromino.Blocks[i - currentTetromino.Row, j - currentTetromino.Col] == 1 &&
                        board.Blocks[i, j + 1] == 1)
                    {
                        this.RespawnTetromino(currentTetromino, board);
                        return false;
                    }
                }
            }
            this.RespawnTetromino(currentTetromino, board);
            return true;
        }

        private int GetRightSideColumnToCheck(ICurrentTetromino currentTetromino)
        {
            for (int i = currentTetromino.Col + currentTetromino.Blocks.GetLength(1) - 1;
                i >= currentTetromino.Col;
                i--)
            {
                for (int j = currentTetromino.Row; j < currentTetromino.Row + currentTetromino.Blocks.GetLength(0); j++)
                {
                    if (currentTetromino.Blocks[j - currentTetromino.Row, i - currentTetromino.Col] == 1)
                    {
                        return i + 1;
                    }
                }
            }
            return -1;
        }

        public ICurrentTetromino MoveTetrominoLeft(IBoard board, ICurrentTetromino currentTetromino)
        {
            if (this.IsTetrominoMoveLeftPossible(board, currentTetromino))
            {
                this.ClearTetromino(currentTetromino, board);
                currentTetromino.Col--;
                this.RespawnTetromino(currentTetromino, board);
            }
            return currentTetromino;
        }

        private bool IsTetrominoMoveLeftPossible(IBoard board, ICurrentTetromino currentTetromino)
        {
            if (currentTetromino == null)
            {
                return false;
            }
            int blockToCheckY = this.GetLeftSideColumnToCheck(currentTetromino);
            if (!this.IsPointInBoardRange(board, currentTetromino.Row, blockToCheckY))
            {
                return false;
            }
            this.ClearTetromino(currentTetromino, board);
            for (int i = currentTetromino.Row; i < currentTetromino.Row + currentTetromino.Blocks.GetLength(0); i++)
            {
                for (int j = blockToCheckY; j < currentTetromino.Col + currentTetromino.Blocks.GetLength(1) - 1; j++)
                {
                    if (currentTetromino.Blocks[i - currentTetromino.Row, j - currentTetromino.Col + 1] == 1 &&
                        board.Blocks[i, j] == 1)
                    {
                        this.RespawnTetromino(currentTetromino, board);
                        return false;
                    }
                }
            }
            this.RespawnTetromino(currentTetromino, board);
            return true;
        }

        private int GetLeftSideColumnToCheck(ICurrentTetromino currentTetromino)
        {
            for (int i = currentTetromino.Col; i < currentTetromino.Col + currentTetromino.Blocks.GetLength(1); i++)
            {
                for (int j = currentTetromino.Row; j < currentTetromino.Row + currentTetromino.Blocks.GetLength(0); j++)
                {
                    if (currentTetromino.Blocks[j - currentTetromino.Row, i - currentTetromino.Col] == 1)
                    {
                        return i - 1;
                    }
                }
            }
            return -1;
        }

        public ICurrentTetromino MoveTetrominoDown(IBoard board, ICurrentTetromino currentTetromino)
        {
            if (this.IsTetrominoMoveDownPossible(board, currentTetromino))
            {
                this.ClearTetromino(currentTetromino, board);
                currentTetromino.Row++;
                this.RespawnTetromino(currentTetromino, board);
                return currentTetromino;
            }
            else
            {
                return null;
            }
        }

        private bool IsTetrominoMoveDownPossible(IBoard board, ICurrentTetromino currentTetromino)
        {
            if (currentTetromino == null)
            {
                return false;
            }
            int blockToCheckX = this.GetRowToCheck(currentTetromino);
            if (!this.IsPointInBoardRange(board, blockToCheckX, 0))
            {
                return false;
            }
            this.ClearTetromino(currentTetromino, board);
            for (int i = currentTetromino.Row; i < blockToCheckX; i++)
            {
                for (int j = currentTetromino.Col; j < currentTetromino.Col + currentTetromino.Blocks.GetLength(1); j++)
                {
                    if (currentTetromino.Blocks[i - currentTetromino.Row, j - currentTetromino.Col] == 1 &&
                        board.Blocks[i + 1, j] == 1)
                    {
                        this.RespawnTetromino(currentTetromino, board);
                        return false;
                    }
                }
            }
            this.RespawnTetromino(currentTetromino, board);
            return true;
        }

        private int GetRowToCheck(ICurrentTetromino currentTetromino)
        {
            for (int i = currentTetromino.Row + currentTetromino.Blocks.GetLength(0) - 1;
                i >= currentTetromino.Row;
                i--)
            {
                for (int j = currentTetromino.Col; j < currentTetromino.Col + currentTetromino.Blocks.GetLength(1); j++)
                {
                    if (currentTetromino.Blocks[i - currentTetromino.Row, j - currentTetromino.Col] == 1)
                    {
                        return i + 1;
                    }
                }
            }
            return -1;
        }

        public ICurrentTetromino SpawnTetromino(ITetromino tetromino, IBoard board, ICurrentTetromino currentTetromino)
        {
            int tetrominoSpawnPoint =
                (int) (board.Width / 2 - Math.Ceiling((double) tetromino.Blocks.GetLength(1) / 2));
            if (this.IsSpawnPossible(tetromino, board, tetrominoSpawnPoint))
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
                return new CurrentTetromino(tetromino, 0, tetrominoSpawnPoint);
            }

            return currentTetromino;
        }

        private bool IsSpawnPossible(ITetromino tetromino, IBoard board, int tetrominoSpawnPoint)
        {
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

        private void ClearTetromino(ICurrentTetromino currentTetromino, IBoard board)
        {
            for (int j = currentTetromino.Row; j < currentTetromino.Row + currentTetromino.Blocks.GetLength(0); j++)
            {
                for (int i = currentTetromino.Col; i < currentTetromino.Col + currentTetromino.Blocks.GetLength(1); i++)
                {
                    if (this.IsPointInBoardRange(board, j, i))
                    {
                        if (currentTetromino.Blocks[j - currentTetromino.Row, i - currentTetromino.Col] == 1)
                        {
                            board.Blocks[j, i] = 0;
                        }
                    }
                }
            }
        }

        private void RespawnTetromino(ICurrentTetromino currentTetromino, IBoard board)
        {
            for (int i = currentTetromino.Row; i < currentTetromino.Row + currentTetromino.Blocks.GetLength(0); i++)
            {
                for (int j = currentTetromino.Col; j < currentTetromino.Col + currentTetromino.Blocks.GetLength(1); j++)
                {
                    if (this.IsPointInBoardRange(board, i, j) && board.Blocks[i, j] == 0 &&
                        currentTetromino.Blocks[i - currentTetromino.Row, j - currentTetromino.Col] == 1)
                    {
                        board.Blocks[i, j] =
                            currentTetromino.Blocks[i - currentTetromino.Row, j - currentTetromino.Col];
                    }
                }
            }
        }

        private bool IsPointInBoardRange(IBoard board, int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return false;
            }
            if (i >= board.Blocks.GetLength(0) || j >= board.Blocks.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}