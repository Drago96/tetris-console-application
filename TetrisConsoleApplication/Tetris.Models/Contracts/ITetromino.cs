namespace Tetris.Models.Contracts
{
    public interface ITetromino
    {
        byte[,] Blocks { get; }

        char BlockSprite { get; }

        void DrawTetromino();

        void RotateLeft();

        void RotateRight();

    }
}
