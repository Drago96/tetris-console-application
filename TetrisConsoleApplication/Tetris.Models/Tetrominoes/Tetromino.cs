using System;
using Tetris.Models.Contracts;

namespace Tetris.Models.Tetrominoes
{
    public abstract class Tetromino : ITetromino
    {
        private byte[,] blocks;

        protected Tetromino(byte[,] blocks = null)
        {
            this.Blocks = blocks;
        }

        public byte[,] Blocks
        {   
            get
            {
                return blocks;
            }
            private set
            {
                this.blocks = value;
            }         
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}
