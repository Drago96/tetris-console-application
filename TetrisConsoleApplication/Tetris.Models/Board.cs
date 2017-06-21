using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class Board : IBoard
    {
        public Board(int width, int height,char boardSprite,char rearWallSprite, string bottomSprite)
        {
            this.BoardBorder = new BoardBorder(rearWallSprite,bottomSprite);
            this.Width = width;
            this.Height = height;
            this.Blocks = new byte[this.Height,this.Width];
            this.BoardSprite = boardSprite;

        }

        public byte[,] Blocks { get; private set; }

        public char BoardSprite { get; private set; }

        public BoardBorder BoardBorder { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }


    }
}
