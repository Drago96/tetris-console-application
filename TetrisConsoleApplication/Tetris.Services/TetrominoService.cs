using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;
using Tetris.Models.Tetrominoes;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class TetrominoService
    {
        public TetrominoService()
        {
            this.TetrominoFactory = new TetrominoFactory();

        }

        public ITetromino GetNextTetromino()
        {
            if (TetrominoFactory.Tetrominoes.Count < 2)
            {
                this.RefillTetrominoes();
            }
            return TetrominoFactory.Tetrominoes.Dequeue();
        }

        public ITetromino PeekNextTetromino()
        {
            if (TetrominoFactory.Tetrominoes.Count < 2)
            {
                this.RefillTetrominoes();
            }
            return TetrominoFactory.Tetrominoes.Peek();
        }

        public void RefillTetrominoes()
        {
            Random rnd = new Random();
            for (int i = 0; i < Constants.TetrominoRefillCount; i++)
            {

                int nextTetronimoTypeNumber = rnd.Next(0, TetrominoFactory.TetrominoTypes.Count - 1);
                Type tetrominoType = TetrominoFactory.TetrominoTypes[nextTetronimoTypeNumber];
                var nextTetromino = Activator.CreateInstance(tetrominoType);
                TetrominoFactory.Tetrominoes.Enqueue((ITetromino)nextTetromino);

            }
        }

        public TetrominoFactory TetrominoFactory { get; set; }
    }
}
