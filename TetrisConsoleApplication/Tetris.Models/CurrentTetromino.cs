using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;
using Tetris.Models.Tetrominoes;

namespace Tetris.Models
{
    public class CurrentTetromino : Tetromino, ICurrentTetromino
    {
        public CurrentTetromino(byte[,] blocks, int tetrominoAxisX, int tetrominoAxisY ) : base(blocks)
        {
            this.TetrominoAxisX = tetrominoAxisX;
            this.TetrominoAxisY = tetrominoAxisY;
        }

        public int TetrominoAxisX { get; set; }

        public int TetrominoAxisY { get; set; }

    }
}
