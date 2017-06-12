using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Utilities;

namespace Tetris.Models
{
    public class Game
    {
        public Game(int boardWidth, int boardHeight,int level, int score, int linesCleared,char blockSprite, string boardRearWallSprite, string bottomSprite)
        {
            this.Board = new Board(boardWidth,boardHeight,level,score,linesCleared,  blockSprite,  boardRearWallSprite,  bottomSprite);
            this.Timer = new Stopwatch();
            this.DropTimer = new Stopwatch();
        }

        public Board Board { get; set; }

        public Stopwatch Timer { get; set; }

        public Stopwatch DropTimer { get; set; }

        
    }
}
