namespace Tetris.Models.Tetrominoes
{
    public class RightSnake : Tetromino
    {
        private static readonly byte[,] rightSnakeFigure = new byte[,] { { 0, 1, 1 }, { 1, 1, 0 } };

        public RightSnake() : base(rightSnakeFigure)
        {
        }
    }
}
