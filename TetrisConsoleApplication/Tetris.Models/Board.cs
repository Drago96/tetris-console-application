using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class Board
    {
        public Board(int width, int height,int level, int score, int linesCleared,char boardSprite,string rearWallSprite, string bottomSprite)
        {
            this.BoardBorder = new BoardBorder(rearWallSprite,bottomSprite);
            this.Width = width;
            this.Height = height;
            this.ScoreInfo = new ScoreInfo(level,score,linesCleared);
            this.Grid = new byte[this.Height,this.Width];
            this.BoardSprite = boardSprite;


        }

        public byte[,] Grid { get; set; }

        public char BoardSprite { get; }

        public BoardBorder BoardBorder { get; }

        public int Width { get; }

        public int Height { get;  }

        public ScoreInfo ScoreInfo { get; set; }

        public ITetromino SpawnedTetromino { get; set; }

    }
}
