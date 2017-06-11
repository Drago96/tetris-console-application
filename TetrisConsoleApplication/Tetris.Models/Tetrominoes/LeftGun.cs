namespace Tetris.Models.Tetrominoes
{
    public class LeftGun : Tetromino
    {
        private static readonly  byte[,] leftGunFigure = new byte[,] { { 1, 0, 0 }, { 1, 1, 1 } };

        public LeftGun() : base(leftGunFigure)
        {

        }
    }
}
