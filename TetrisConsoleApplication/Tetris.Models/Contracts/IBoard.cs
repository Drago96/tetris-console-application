namespace Tetris.Models.Contracts
{
    public interface IBoard : IGrid
    {
        char BoardSprite { get; }

        IBoardBorder BoardBorder { get; }

        int Width { get; }

        int Height { get; }
    }
}