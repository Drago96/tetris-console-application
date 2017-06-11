namespace Tetris.Models
{
    public class Board
    {
        public Board(int width, int height,int level, int score, int linesCleared)
        {
            this.Width = width;
            this.Height = height;
            this.Level = level;
            this.Score = score;
            this.LinesCleared = linesCleared;

        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Level { get; set; }

        public int Score { get; set; }

        public int LinesCleared { get; set; }

    }
}
