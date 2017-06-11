namespace Tetris.Models
{
    public class Board
    {
        public Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }
        
    }
}
