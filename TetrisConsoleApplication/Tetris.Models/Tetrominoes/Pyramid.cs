using System.Collections.Generic;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class Pyramid : Tetromino
    {
        private static readonly byte[,] PyramidFigure = new byte[,] {{0,1,0},{1,1,1}, {0,0,0} };

        public Pyramid() : base(PyramidFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0 }, { 0, 1, 1 }, { 0, 1, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 1, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0 }, { 1, 1, 0 }, { 0, 1, 0 } } );
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 0, 0  }});
        }

    


    }
}
