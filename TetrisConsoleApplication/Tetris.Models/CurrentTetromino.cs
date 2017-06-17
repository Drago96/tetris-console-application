using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;
using Tetris.Models.Tetrominoes;

namespace Tetris.Models
{
    public class CurrentTetromino :  ICurrentTetromino
    {
        public CurrentTetromino(ITetromino tetromino, int tetrominoAxisX, int tetrominoAxisY )
        {
            this.Tetromino = tetromino;
            this.TetrominoAxisX = tetrominoAxisX;
            this.TetrominoAxisY = tetrominoAxisY;
        }

        public ITetromino Tetromino { get; set; }

        public byte[,] Blocks
        {
            get { return this.Tetromino.Blocks; }
            private set { this.Blocks = value; }
        }

        public int TetrominoAxisX { get; set; }

        public int TetrominoAxisY { get; set; }

    }
}
