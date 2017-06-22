namespace Tetris.Models
{
    using System.Diagnostics;
    using Tetris.Models.Contracts;
    using Tetris.Models.Tetrominoes;

    public class Game : IGame
    {
        public Game(IBoard board,IScoreInfo scoreInfo, int tetrominoDropRate, int tetrominoDropRateIncrease)
        {
            this.Board = board;
            this.DropTimer = new Stopwatch();
            this.ScoreInfo = scoreInfo;
            this.TetrominoFactory = new TetrominoFactory();
            this.TetrominoRepository = new TetrominoRepository();
            this.TetrominoDropRate = tetrominoDropRate - (scoreInfo.Level-1) * tetrominoDropRateIncrease;
            this.TetrominoDropRateIncrease = tetrominoDropRateIncrease;
        }

        public IBoard Board { get; set; }

        public ICurrentTetromino CurrentTetromino { get; set; }

        public ITetrominoFactory TetrominoFactory { get; set; }

        public ITetrominoRepository TetrominoRepository { get; set; }

        public Stopwatch DropTimer { get; set; }

        public int TetrominoDropRate { get; set; }

        public int TetrominoDropRateIncrease { get; set; }

        public IScoreInfo ScoreInfo { get; set; }
    }
}