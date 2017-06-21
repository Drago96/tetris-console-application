namespace Tetris.Models.Tetrominoes
{
    using System.Collections.Generic;
    using Tetris.Utilities;

    public class Block : Tetromino
    {
        private static readonly byte[,] BlockFigure = new byte[,] {{1, 1}, {1, 1}};

        public Block() : base(BlockFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            this.ShapeRotations.Enqueue(new byte[,] {{1, 1}, {1, 1}});
        }
    }
}