using Tetris.Models.Contracts;

namespace Tetris.Services.Contracts
{
    public interface IBoardStateService
    {
        ICurrentTetromino MoveTetrominoRight(IBoard board, ICurrentTetromino currentTetromino);

        ICurrentTetromino MoveTetrominoLeft(IBoard board, ICurrentTetromino currentTetromino);

        ICurrentTetromino MoveTetrominoDown(IBoard board, ICurrentTetromino currentTetromino);

        ICurrentTetromino SpawnTetromino(ITetromino tetromino, IBoard board, ICurrentTetromino currentTetromino);

        ICurrentTetromino RotateTetromino(IBoard board, ICurrentTetromino currentTetromino);
    }
}
