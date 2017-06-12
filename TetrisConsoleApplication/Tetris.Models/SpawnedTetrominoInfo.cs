using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class SpawnedTetrominoInfo
    {
        public SpawnedTetrominoInfo(ITetromino tetromino, int tetrominoAxisX, int tetrominoAxisY)
        {
            this.Tetromino = tetromino;
            this.TetrominoAxisX = tetrominoAxisX;
            this.TetrominoAxisY = tetrominoAxisY;
        }

        public ITetromino Tetromino { get; set; }
        public int TetrominoAxisX { get; set; }
        public int TetrominoAxisY { get; set; }
    }
}
