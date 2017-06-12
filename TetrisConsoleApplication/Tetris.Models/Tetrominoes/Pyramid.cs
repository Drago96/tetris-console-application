﻿using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class Pyramid : Tetromino
    {
        private static readonly byte[,] PyramidFigure = new byte[,] {{0,1,0},{1,1,1} };

        public Pyramid() : base(PyramidFigure, Constants.BlockSprite)
        {
        }

        public override void RotateLeft()
        {

        }

        public override void RotateRight()
        {

        }
    }
}
