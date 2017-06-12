namespace Tetris.Models.Contracts
{
    public interface ITetromino : IGrid
    {
        char BlockSprite { get; }

        void DrawTetromino();
    }
}
