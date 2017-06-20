using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;
using Tetris.Models.Tetrominoes;
using Tetris.Utilities;

namespace Tetris.Models
{
    public class Game : IGame
    {
        public Game(int boardWidth, int boardHeight,int level, long score, int linesCleared,
            char blockSprite, string boardRearWallSprite, string bottomSprite, int tetrominoDropRate)
        {
            this.Board = new Board(boardWidth,boardHeight,blockSprite,  boardRearWallSprite,  bottomSprite);
            this.DropTimer = new Stopwatch();
            this.ScoreInfo = new ScoreInfo(level,score,linesCleared);
            this.TetrominoFactory = new TetrominoFactory();
            this.TetrominoRepository = new TetrominoRepository();
            this.TetrominoDropRate = tetrominoDropRate;

        }

        public IBoard Board { get; set; }

        public ICurrentTetromino CurrentTetromino { get; set; }

        public ITetrominoFactory TetrominoFactory { get; set; }

        public ITetrominoRepository TetrominoRepository { get; set; }

        public Stopwatch DropTimer { get; set; }

        public int TetrominoDropRate { get; set; }

        public ScoreInfo ScoreInfo { get; set; }

    }
}
