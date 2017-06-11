namespace Tetris.Models.Tetrominoes
{
    public class Block : Tetromino
    {
        private static readonly byte[,] blockFigure =  new byte[,] { {1,1}, {1,1} };

        public Block() : base(blockFigure)
        {
        }        

    }
}
