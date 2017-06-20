namespace Tetris.Models.Tetrominoes
{
    using System;
    using System.Collections.Generic;
    using Tetris.Models.Contracts;

    public abstract class Tetromino : ITetromino
    {
        protected Queue<byte[,]> ShapeRotations;

        protected Tetromino(byte[,] blocks, char blockSprite = ' ')
        {
            this.Blocks = blocks;
            this.BlockSprite = blockSprite;
        }

        public byte[,] Blocks { get; protected set; }

        public char BlockSprite { get; private set; }

        public void DrawTetromino()
        {
            for (int i = 0; i < this.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < this.Blocks.GetLength(1); j++)
                {
                    Console.Write(this.Blocks[i, j] == 0 ? "  " : $"{this.BlockSprite} ");
                }
                Console.SetCursorPosition(Console.CursorLeft - this.Blocks.GetLength(1) * 2, Console.CursorTop + 1);
            }
        }

        public void Rotate()
        {
            this.ShapeRotations.Enqueue(this.Blocks);
            this.Blocks = this.ShapeRotations.Dequeue();
        }

        public byte[,] GetNextRotation()
        {
            return this.ShapeRotations.Peek();
        }
    }
}