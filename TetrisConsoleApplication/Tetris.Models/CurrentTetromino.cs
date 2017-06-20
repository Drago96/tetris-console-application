namespace Tetris.Models
{
    using Tetris.Models.Contracts;

    public class CurrentTetromino : ICurrentTetromino
    {
        public CurrentTetromino(ITetromino tetromino, int tetrominoAxisX, int tetrominoAxisY)
        {
            this.Tetromino = tetromino;
            this.Row = tetrominoAxisX;
            this.Col = tetrominoAxisY;
        }

        public ITetromino Tetromino { get; set; }

        public byte[,] Blocks
        {
            get { return this.Tetromino.Blocks; }
            private set { this.Blocks = value; }
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}