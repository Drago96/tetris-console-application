using System.Diagnostics;

namespace Tetris.Models.Contracts
{
    public interface IGame
    {
        IBoard Board { get; set; }

        ICurrentTetromino CurrentTetromino { get; set; }

        ITetrominoFactory TetrominoFactory { get; set; }

        ITetrominoRepository TetrominoRepository { get; set; }

        Stopwatch Timer { get; set; }

        Stopwatch DropTimer { get; set; }

        ScoreInfo ScoreInfo { get; set; }
    }
}
