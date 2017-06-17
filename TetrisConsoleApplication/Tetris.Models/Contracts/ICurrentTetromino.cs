namespace Tetris.Models.Contracts
{
    public interface ICurrentTetromino 
    {
        int TetrominoAxisX { get; set; }

        int TetrominoAxisY { get; set; }

        byte[,] Blocks { get;}

        ITetromino Tetromino { get; set; }
    }
}
