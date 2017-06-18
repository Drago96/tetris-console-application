using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class RightGun : Tetromino
    {
        private static readonly byte[,] RightGunFigure = new byte[,] { { 0, 0, 1 }, { 1, 1, 1 }, {0,0,0} };

        public RightGun() : base(RightGunFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 0 }, { 1, 1, 1, }, { 1, 0, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 0, 0 }});
        }



    }
}