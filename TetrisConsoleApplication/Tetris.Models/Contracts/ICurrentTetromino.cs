namespace Tetris.Models.Contracts
{
    public interface ICurrentTetromino 
    {
        int Row { get; set; }

        int Col { get; set; }

        byte[,] Blocks { get;}

        ITetromino Tetromino { get; set; }
    }
}
