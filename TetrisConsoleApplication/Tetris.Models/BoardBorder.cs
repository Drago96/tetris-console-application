using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class BoardBorder : IBoardBorder
    {
        public BoardBorder(char rearWallSprite, string bottomSprite)
        {
            this.RearWallSprite = rearWallSprite;
            this.BottomSprite = bottomSprite;
        }

        public char RearWallSprite { get; private set; }

        public string BottomSprite { get; private set; }
    }
}