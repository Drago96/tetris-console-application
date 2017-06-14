namespace Tetris.Models.Contracts
{
    public interface ICurrentTetromino : ITetromino
    {
        int TetrominoAxisX { get; set; }

        int TetrominoAxisY { get; set; }
    }
}
