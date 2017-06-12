using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class CurrentTetromino
    {
        public CurrentTetromino(ITetromino tetromino, int tetrominoAxisX, int tetrominoAxisY)
        {
            this.Grid = tetromino.Blocks;
            this.TetrominoAxisX = tetrominoAxisX;
            this.TetrominoAxisY = tetrominoAxisY;
        }

        public byte[,] Grid { get; set; }
        public int TetrominoAxisX { get; set; }
        public int TetrominoAxisY { get; set; }
    }
}
