using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    public class RightSnake : Tetromino
    {
        public RightSnake()
        {
            this.Blocks = new byte[,] { { 0, 1, 1 }, { 1, 1, 0 } };
        }

        public void Rotate()
        {

        }

        public byte[,] Blocks { get; set; }

       
    }
}
