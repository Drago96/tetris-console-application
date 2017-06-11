using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models
{
    public class Game
    {
        public Game(int boardWidth, int boardHeight)
        {
            this.Board = new Board(boardWidth,boardHeight);
            this.Timer = new Stopwatch();
            this.DropTimer = new Stopwatch();
        }

        public Board Board { get; set; }

        public Stopwatch Timer { get; set; }

        public Stopwatch DropTimer { get; set; }
    }
}
