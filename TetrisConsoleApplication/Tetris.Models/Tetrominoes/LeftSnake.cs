using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class LeftSnake : Tetromino
    {
        private static readonly byte[,] LeftSnakeFigure = new byte[,] {{1, 1, 0}, {0, 1, 1}, {0,0,0}};

        public LeftSnake() : base(LeftSnakeFigure, Constants.BlockSprite)
        {
        }

        public override void Rotate()
        {
            if (RotateState == 0)
            {
                this.Blocks = new byte[,] { {0,0,1},{0,1,1},{0,1,0} };
                RotateState++;
            }
            else if (RotateState == 1)
            {
                this.Blocks = new byte[,] { {0,0,0},{1,1,0},{0,1,1} };
                RotateState++;
            }
            else if (RotateState == 2)
            {
                this.Blocks = new byte[,] { {0,1,0},{1,1,0},{1,0,0} };
                RotateState++;
            }
            else
            {
                this.Blocks = new byte[,] { { 1, 1, 0 }, { 0, 1, 1 }, { 0, 0, 0 } };
                RotateState = 0;
            }
        }

    }
}
