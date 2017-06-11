using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    public interface Tetromino
    {
        
        byte[,] Blocks { get; set; }
        void Rotate();
        void MoveLeft();
        void MoveRight();
    }
}
