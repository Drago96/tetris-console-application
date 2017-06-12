using System;
using Tetris.Models.Contracts;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public abstract class Tetromino : ITetromino
    {
        private byte[,] blocks;

        protected Tetromino(byte[,] blocks)
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

        public void DrawTetromino()
        {
            for (int i = 0; i < Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < Blocks.GetLength(1); j++)
                {
                    Console.Write(Blocks[i,j] == 0 ? "  " : $"{Constants.BlockSprite} ");
                }
                Console.SetCursorPosition(Console.CursorLeft - Blocks.GetLength(1)*2,Console.CursorTop+1);
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
