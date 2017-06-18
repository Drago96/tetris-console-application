using System.Collections.Generic;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class Block : Tetromino
    {
        private static readonly byte[,] BlockFigure =  new byte[,] { {1,1}, {1,1} };

        public Block() : base(BlockFigure,Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            ShapeRotations.Enqueue(new byte[,] { {1,1},{1,1} });
            ShapeRotations.Enqueue(new byte[,] { { 1, 1 }, { 1, 1 } });
        }


    }
}
