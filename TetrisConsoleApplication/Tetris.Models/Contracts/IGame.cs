using System.Diagnostics;

namespace Tetris.Models.Contracts
{
    public interface IGame
    {
        IBoard Board { get; set; }

        ICurrentTetromino CurrentTetromino { get; set; }

        ITetrominoFactory TetrominoFactory { get; set; }

        ITetrominoRepository TetrominoRepository { get; set; }

        Stopwatch DropTimer { get; set; }

        int TetrominoDropRate { get; set; }

        int TetrominoDropRateIncrease { get; set; }

        ScoreInfo ScoreInfo { get; set; }
    }
}
