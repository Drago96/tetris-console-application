namespace Tetris.Services
{
    using Tetris.Models.Contracts;

    public class BoardService
    {
        public int UpdateBoard(IBoard board)
        {
            int lines = 0;
            for (int i = board.Height - 1; i >= 0; i--)
            {
                bool isFull = true;
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.Blocks[i, j] == 0)
                    {
                        isFull = false;
                    }
                }
                if (isFull)
                {
                    lines++;
                    this.ClearLine(board, i);
                    i++;
                }
            }
            return lines;
        }

        private void ClearLine(IBoard board, int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    board.Blocks[i, j] = board.Blocks[i - 1, j];
                }
            }
            for (int j = 0; j < board.Width; j++)
            {
                board.Blocks[0, j] = 0;
            }
        }
    }
}