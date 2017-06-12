using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class CurrentTetromino : IGrid
    {
        public CurrentTetromino(ITetromino tetromino, int tetrominoAxisX, int tetrominoAxisY)
        {
            this.Blocks = tetromino.Blocks;
            this.TetrominoAxisX = tetrominoAxisX;
            this.TetrominoAxisY = tetrominoAxisY;
        }

        public byte[,] Blocks { get; private set; }
        public int TetrominoAxisX { get; set; }
        public int TetrominoAxisY { get; set; }
    }
}
