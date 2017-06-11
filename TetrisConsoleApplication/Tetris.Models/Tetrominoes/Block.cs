using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    class Block : Tetromino
    {
        public Block()
        {
            this.Blocks = new byte[,] { {1,1}, {1,1} };
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
