using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Tetrominoes
{
    public class RightGun : Tetromino
    {
        private static readonly byte[,] rightGunFigure = new byte[,] { { 0, 0, 1 }, { 1, 1, 1 } };

        protected RightGun() : base(rightGunFigure)
        {
        }
    }
}