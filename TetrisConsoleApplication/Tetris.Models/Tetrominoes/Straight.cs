﻿using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class Straight : Tetromino
    {
        private static readonly byte[,] StraightFigure = new byte[,] { { 1, 1, 1, 1 } };

        public Straight() : base(StraightFigure, Constants.BlockSprite)
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
