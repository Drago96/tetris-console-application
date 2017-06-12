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
        public TetrominoService()
        {
            this.TetrominoFactory = new TetrominoFactory();
            this.TetrominoRepository = new TetrominoRepository();
        }

        public ITetrominoFactory TetrominoFactory { get; private set; }

        public ITetrominoRepository TetrominoRepository { get; private set; }

        public ITetromino GetNextTetromino()
        {
            if (TetrominoRepository.Tetrominoes.Count < 2)
            {
                this.RefillTetrominoes();
            }
            return TetrominoRepository.GetFirstElement();
        }

        public ITetromino PeekNextTetromino()
        {
            if (TetrominoRepository.Tetrominoes.Count < 2)
            {
                this.RefillTetrominoes();
            }
            return TetrominoRepository.PeekNextElement();
        }

        public void RefillTetrominoes()
        {
            Random rnd = new Random();

            var tetrominoTypes = Enum.GetValues(typeof(TetrominoType)).Cast<TetrominoType>().ToArray();
            
            for (int i = 0; i < Constants.TetrominoRefillCount; i++)
            {

                int nextTetronimoTypeNumber = rnd.Next(0, tetrominoTypes.Length);

                TetrominoType type = tetrominoTypes[nextTetronimoTypeNumber];

                ITetromino tetromino = TetrominoFactory.CreateTetromino(type);

                TetrominoRepository.AddTetromino(tetromino);

            }
        }
    }
}
