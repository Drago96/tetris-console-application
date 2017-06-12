using System;
using Tetris.Models.Contracts;

namespace Tetris.Models.Tetrominoes
{
    public abstract class Tetromino : ITetromino
    {
        private byte[,] blocks;

<<<<<<< HEAD
        public Tetromino(byte[,] blocks)
=======
        protected Tetromino(byte[,] blocks = null)
>>>>>>> 7e0968f3cb09301af56450f2c5c739fc4e5cd0e5
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
