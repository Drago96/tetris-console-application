using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    public class Straight : Tetromino
    {
        public Straight()
        {
            this.Blocks = new byte[,] {  { 1,1,1,1 }  };
        }

        public void Rotate()
        {
            
        }

        public byte[,] Blocks { get; set; }
    }
}
