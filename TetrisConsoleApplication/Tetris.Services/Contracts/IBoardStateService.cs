using Tetris.Models.Contracts;

namespace Tetris.Services.Contracts
{
    public interface IBoardStateService
    {
        ICurrentTetromino MoveTetrominoDown(IBoard board, ICurrentTetromino currentTetromino);

        ICurrentTetromino SpawnTetromino(ITetromino tetromino, IBoard board, ICurrentTetromino currentTetromino);

        bool IsTetrominoMoveDownPossible(IBoard board, ICurrentTetromino currentTetromino);



    }
}
