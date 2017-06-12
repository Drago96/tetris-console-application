using System.Collections.Generic;

namespace Tetris.Models.Contracts
{
    public interface ITetrominoRepository
    {
        Queue<ITetromino> Tetrominoes { get; }

        bool IsTetrominoSpawned { get; set; }

        void AddTetromino(ITetromino tetromino);

        ITetromino GetFirstElement();

        ITetromino PeekNextElement();

        
    }
}
