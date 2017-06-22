namespace Tetris.Models
{
    using System.Diagnostics;
    using Tetris.Models.Contracts;
    using Tetris.Models.Tetrominoes;

    public class Game : IGame
    {
        public Game(int boardWidth, int boardHeight, int level, long score, int linesCleared,
            char blockSprite, char boardRearWallSprite, string bottomSprite, int tetrominoDropRate, int tetrominoDropRateIncrease,
            int scorePerLine, int linesPerLevel)
        {
            this.Board = new Board(boardWidth, boardHeight, blockSprite, boardRearWallSprite, bottomSprite);
            this.DropTimer = new Stopwatch();
            this.ScoreInfo = new ScoreInfo(level, score, linesCleared,scorePerLine,linesPerLevel);
            this.TetrominoFactory = new TetrominoFactory();
            this.TetrominoRepository = new TetrominoRepository();
            this.TetrominoDropRate = tetrominoDropRate - (level-1) * tetrominoDropRateIncrease;
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