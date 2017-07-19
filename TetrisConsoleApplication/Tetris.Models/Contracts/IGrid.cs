namespace Tetris.Models.Contracts
{
    public interface IGrid
    {
        byte[,] Blocks { get; }
    }
}