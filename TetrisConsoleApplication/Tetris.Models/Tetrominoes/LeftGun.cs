using System.Collections.Generic;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public class LeftGun : Tetromino
    {
        private static readonly  byte[,] LeftGunFigure = new byte[,] { { 1, 0, 0 }, { 1, 1, 1 }, {0,0,0} };

        public LeftGun() : base(LeftGunFigure, Constants.BlockSprite)
        {
            this.ShapeRotations = new Queue<byte[,]>();
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 1 }});
            ShapeRotations.Enqueue(new byte[,] { { 0, 1, 0 }, { 0, 1, 0 }, { 1, 1, 0 } });
            ShapeRotations.Enqueue(new byte[,] { { 1, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 }});

        }


    }
}
