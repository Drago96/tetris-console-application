using Tetris.Models.Contracts;

namespace Tetris.Services.Contracts
{
    public interface IBoardStateService
    {
        ICurrentTetromino MoveTetrominoLeft(IBoard board, ICurrentTetromino currentTetromino);

        ICurrentTetromino MoveTetrominoDown(IBoard board, ICurrentTetromino currentTetromino);

        ICurrentTetromino SpawnTetromino(ITetromino tetromino, IBoard board, ICurrentTetromino currentTetromino);

    }
}
