using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class LeftSnake : Tetromino
    {
        private static readonly byte[,] LeftSnakeFigure = new byte[,] {{1, 1, 0}, {0, 1, 1}};

        public LeftSnake() : base(LeftSnakeFigure, Constants.BlockSprite)
        {
        }

    }
}
