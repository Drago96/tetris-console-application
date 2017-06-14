using Tetris.Models.Contracts;

namespace Tetris.Services.Contracts
{
    public interface ITetrominoService
    {

        ITetromino GetNextTetromino(ITetrominoRepository tetrominoRepository, ITetrominoFactory tetrominoFactory);

        ITetromino PeekNextTetromino(ITetrominoRepository tetrominoRepository, ITetrominoFactory tetrominoFactory);

        void RefillTetrominoes(ITetrominoRepository tetrominoRepository, ITetrominoFactory tetrominoFactory);

    }
}
