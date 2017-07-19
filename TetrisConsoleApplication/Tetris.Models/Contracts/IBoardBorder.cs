namespace Tetris.Models.Contracts
{
    public interface IBoardBorder
    {
        char RearWallSprite { get; }

        string BottomSprite { get; }
    }
}