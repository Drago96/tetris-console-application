using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;

namespace Tetris.Models.Tetrominoes
{
    public class TetrominoRepository : ITetrominoRepository
    {
        public TetrominoRepository()
        {
            this.Tetrominoes = new Queue<ITetromino>();
        }

        public Queue<ITetromino> Tetrominoes { get; private set; }

        public void AddTetromino(ITetromino tetromino)
        {
            this.Tetrominoes.Enqueue(tetromino);
        }
    }
}
