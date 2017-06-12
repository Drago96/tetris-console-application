using System.Collections.Generic;

namespace Tetris.Models.Contracts
{
    public interface ITetrominoRepository
    {
        Queue<ITetromino> Tetrominoes { get; }

        void AddTetromino(ITetromino tetromino);

        ITetromino GetFirstElement();
    }
}
