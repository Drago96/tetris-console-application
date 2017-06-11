namespace Tetris.Models.Contracts
{
    public interface ITetromino
    {
        byte[,] Blocks { get; }

        void Rotate();
        void MoveLeft();
        void MoveRight(); //??
    }
}
