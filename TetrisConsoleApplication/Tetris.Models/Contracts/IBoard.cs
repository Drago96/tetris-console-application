namespace Tetris.Models.Contracts
{
    public interface IBoard : IGrid
    {
        char BoardSprite { get; }

        BoardBorder BoardBorder { get; }

        int Width { get; }

        int Height { get; }

        CurrentTetromino CurrentTetromino { get; }
    }
}
