using System.Collections.Generic;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class LeftSnake : Tetromino
    {
        private static readonly byte[,] LeftSnakeFigure = new byte[,] {{1, 1, 0}, {0, 1, 1}, {0,0,0}};

        public LeftSnake() : base(LeftSnakeFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 1, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 }});
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0 }, { 1, 1, 0 }, { 1, 0, 0 }});
            ShapeRotations.Enqueue(new byte[,] { { 1, 1, 0 }, { 0, 1, 1 }, { 0, 0, 0 } });
        }

    }
}
