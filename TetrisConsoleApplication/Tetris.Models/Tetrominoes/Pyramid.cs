namespace Tetris.Models.Tetrominoes
{
    public class Pyramid : Tetromino
    {
        private static readonly byte[,] pyramidFigure = new byte[,] {{0,1,0},{1,1,1} };

        protected Pyramid() : base(pyramidFigure)
        {
        }
    }
}
