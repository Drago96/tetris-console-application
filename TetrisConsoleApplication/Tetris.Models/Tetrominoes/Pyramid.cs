using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    public class Pyramid : Tetromino
    {
        public Pyramid()
        {
            this.Blocks = new byte[,] {{0,1,0},{1,1,1} };
        }

        public void Rotate()
        {

        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }

        public byte[,] Blocks { get; set; }
    }
}
