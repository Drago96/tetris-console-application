using Tetris.Models.Enums;

namespace Tetris.Models.Contracts
{
    public interface ITetrominoFactory
    {
        ITetromino CreateTetromino(TetrominoType type);
    }
}
