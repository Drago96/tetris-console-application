using Tetris.Models.Contracts;

namespace Tetris.Services.Contracts
{
    public interface ITetrominoService
    {
        ITetrominoFactory TetrominoFactory { get; }

        ITetrominoRepository TetrominoRepository { get; }

        ITetromino GetNextTetromino();

        ITetromino PeekNextTetromino();

        void RefillTetrominoes();

    }
}
