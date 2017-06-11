namespace Tetris.Models.Tetrominoes
{
    public class LeftSnake : Tetromino
    {
        private static readonly byte[,] leftSnakeFigure = new byte[,] { { 1, 1, 0 }, { 0, 1, 1 } };

        public LeftSnake() : base(leftSnakeFigure)
        {
        }
    }
}
