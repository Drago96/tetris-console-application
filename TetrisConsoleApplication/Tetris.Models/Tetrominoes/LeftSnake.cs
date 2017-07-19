namespace Tetris.Models.Tetrominoes
{
    using System.Collections.Generic;
    using Tetris.Utilities;

    public class LeftSnake : Tetromino
    {
        private static readonly byte[,] LeftSnakeFigure = new byte[,] { { 1, 1, 0 }, { 0, 1, 1 }, { 0, 0, 0 } };

        public LeftSnake() : base(LeftSnakeFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            this.ShapeRotations.Enqueue(new byte[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 1, 0 } });
            this.ShapeRotations.Enqueue(new byte[,] { { 0, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } });
            this.ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0 }, { 1, 1, 0 }, { 1, 0, 0 } });
            this.ShapeRotations.Enqueue(new byte[,] { { 1, 1, 0 }, { 0, 1, 1 }, { 0, 0, 0 } });
        }
    }
}