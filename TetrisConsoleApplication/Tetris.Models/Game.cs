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
    public class Game
    {
        public Game(int boardWidth, int boardHeight,int level, int score, int linesCleared,char blockSprite, string boardRearWallSprite, string bottomSprite)
        {
            this.Board = new Board(boardWidth,boardHeight,blockSprite,  boardRearWallSprite,  bottomSprite);
            this.Timer = new Stopwatch();
            this.DropTimer = new Stopwatch();
            this.ScoreInfo = new ScoreInfo(level,score,linesCleared);
            this.TetrominoFactory = new TetrominoFactory();
            this.TetrominoRepository = new TetrominoRepository();

        }

        public Board Board { get; set; }

        public Stopwatch Timer { get; set; }

        public Stopwatch DropTimer { get; set; }

        public ScoreInfo ScoreInfo { get; set; }

        public CurrentTetromino CurrentTetromino { get; set; }

        public ITetrominoFactory TetrominoFactory { get; set; }

        public ITetrominoRepository TetrominoRepository { get; set; }
    }
}
