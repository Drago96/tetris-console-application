namespace Tetris.Models.Contracts
{
    using System.Collections.Generic;

    public interface ITetrominoRepository
    {
        Queue<ITetromino> Tetrominoes { get; }

        void AddTetromino(ITetromino tetromino);

        ITetromino GetFirstElement();

        ITetromino PeekNextElement();
    }
}