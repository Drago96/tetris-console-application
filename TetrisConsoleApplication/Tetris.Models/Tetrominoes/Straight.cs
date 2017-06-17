using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class Straight : Tetromino
    {
        private static readonly byte[,] StraightFigure = new byte[,] {{0,0,0,0}, { 1, 1, 1, 1 },{0,0,0,0},{0,0,0,0} };
        private int rotateState;

        public Straight() : base(StraightFigure, Constants.BlockSprite)
        {
            this.rotateState = 0;
        }

        public override void Rotate()
        {
            if (rotateState == 0)
            {
                this.Blocks = new byte[,] {{0, 0, 1, 0}, {0, 0, 1, 0}, {0, 0, 1, 0}, {0, 0, 1, 0}};
                rotateState++;
            }
            else if (rotateState == 1)
            {
                this.Blocks = new byte[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1,1,1,1 }, {0,0,0,0 } };
                rotateState++;
            }
            else if (rotateState == 2)
            {
                this.Blocks = new byte[,] { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0,1,0,0 }, { 0, 1, 0, 0 } };
                rotateState = 0;
            }
        }


    }
}
