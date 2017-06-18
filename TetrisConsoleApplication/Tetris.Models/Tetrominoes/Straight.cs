using System.Collections.Generic;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class Straight : Tetromino
    {
        private static readonly byte[,] StraightFigure = new byte[,] {{0,0,0,0}, { 1, 1, 1, 1 },{0,0,0,0},{0,0,0,0} };


        public Straight() : base(StraightFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } });
        }

  


    }
}
