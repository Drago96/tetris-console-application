using System;
using Tetris.Models.Contracts;
using Tetris.Utilities;

namespace Tetris.Models.Tetrominoes
{
    public abstract class Tetromino : ITetromino
    {
        protected Tetromino(byte[,] blocks, char blockSprite = ' ')
        {           
            this.Blocks = blocks;
            this.BlockSprite = blockSprite;
        }

        public byte[,] Blocks { get; protected set; }
        
        public char BlockSprite { get; private set; }

        public void DrawTetromino()
        {
            for (int i = 0; i < Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < Blocks.GetLength(1); j++)
                {
                    Console.Write(Blocks[i,j] == 0 ? "  " : $"{this.BlockSprite} ");
                }
                Console.SetCursorPosition(Console.CursorLeft - Blocks.GetLength(1)*2,Console.CursorTop+1);
            }
        }

        public abstract void Rotate();



    }
}
