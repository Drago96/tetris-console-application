namespace Tetris.Models.Tetrominoes
{
    public class Straight : Tetromino
    {
        private static readonly byte[,] straightFigure = new byte[,] { { 1, 1, 1, 1 } };

        protected Straight() : base(straightFigure)
        {
        }
    }
}
