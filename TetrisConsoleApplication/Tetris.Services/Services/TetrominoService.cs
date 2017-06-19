using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;
using Tetris.Models.Tetrominoes;
using Tetris.Utilities;
using System.Reflection;
using Tetris.Models.Enums;
using Tetris.Services.Contracts;

namespace Tetris.Services
{
    public class TetrominoService : ITetrominoService
    {
           
        public ITetromino GetNextTetromino(ITetrominoRepository tetrominoRepository, ITetrominoFactory tetrominoFactory)
        {
            if (tetrominoRepository.Tetrominoes.Count < 1)
            {
                this.RefillTetrominoes(tetrominoRepository,tetrominoFactory);
            }
            return tetrominoRepository.GetFirstElement();
        }

        public ITetromino PeekNextTetromino(ITetrominoRepository tetrominoRepository, ITetrominoFactory tetrominoFactory)
        {

            if (tetrominoRepository.Tetrominoes.Count < 1)
            {
                this.RefillTetrominoes(tetrominoRepository, tetrominoFactory);
            }
            return tetrominoRepository.PeekNextElement();
        }

        public void RefillTetrominoes(ITetrominoRepository tetrominoRepository, ITetrominoFactory tetrominoFactory)
        {
       
            for (int i = 0; i < Constants.TetrominoRefillCount; i++)
            {
                
                ITetromino tetromino = tetrominoFactory.CreateTetromino();

                tetrominoRepository.AddTetromino(tetromino);

            }
        }
    }
}
