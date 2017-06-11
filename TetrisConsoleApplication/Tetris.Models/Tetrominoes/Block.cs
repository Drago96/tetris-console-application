using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    class Block : Tetromino
    {
        public Block(char sprite)
        {
            this.Blocks = new byte[,] { {1,1}, {1,1} };
        }

        public void Rotate()
        {

        }

        public byte[,] Blocks { get; set; }
    }
}
