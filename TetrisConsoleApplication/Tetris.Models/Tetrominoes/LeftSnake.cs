using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    public class LeftSnake : Tetromino
    {
        public LeftSnake()
        {
            this.Blocks = new byte[,] { { 1, 1, 0 }, { 0, 1, 1 } };
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
