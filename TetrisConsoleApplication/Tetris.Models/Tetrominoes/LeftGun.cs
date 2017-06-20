namespace Tetris.Models.Tetrominoes
{
    using System.Collections.Generic;
    using Tetris.Utilities;

    public class LeftGun : Tetromino
    {
        private static readonly byte[,] LeftGunFigure = new byte[,] {{1, 0, 0}, {1, 1, 1}, {0, 0, 0}};

        public LeftGun() : base(LeftGunFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            this.ShapeRotations.Enqueue(new byte[,] {{0, 1, 1}, {0, 1, 0}, {0, 1, 0}});
            this.ShapeRotations.Enqueue(new byte[,] {{0, 0, 0}, {1, 1, 1}, {0, 0, 1}});
            this.ShapeRotations.Enqueue(new byte[,] {{0, 1, 0}, {0, 1, 0}, {1, 1, 0}});
            this.ShapeRotations.Enqueue(new byte[,] {{1, 0, 0}, {1, 1, 1}, {0, 0, 0}});
        }
    }
}