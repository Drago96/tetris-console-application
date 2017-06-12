using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class Board
    {
        public Board(int width, int height,char boardSprite,string rearWallSprite, string bottomSprite)
        {
            this.BoardBorder = new BoardBorder(rearWallSprite,bottomSprite);
            this.Width = width;
            this.Height = height;
            this.Grid = new byte[this.Height,this.Width];
            this.BoardSprite = boardSprite;


        }

        public byte[,] Grid { get; set; }

        public char BoardSprite { get; }

        public BoardBorder BoardBorder { get; }

        public int Width { get; }

        public int Height { get;  }

        public CurrentTetromino CurrentTetromino {get; set; }

    }
}
