namespace Tetris.Models
{
    public class BoardBorder
    {
        public BoardBorder(string rearWallSprite, string bottomSprite)
        {
            this.RearWallSprite = rearWallSprite;
            this.BottomSprite = bottomSprite;
        }

        public string RearWallSprite { get; private set; }

        public string BottomSprite { get; private set; }
    }
}