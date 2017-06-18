using System.Net.Configuration;

namespace Tetris.Models.Contracts
{
    public interface ITetromino : IGrid
    {
        char BlockSprite { get; }

        void DrawTetromino();

        void Rotate();

        byte[,] GetNextRotation();
    }
}
