using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class Block : Tetromino
    {
        private static readonly byte[,] BlockFigure =  new byte[,] { {1,1}, {1,1} };

        public Block() : base(BlockFigure,Constants.BlockSprite)
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
