using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;
using Tetris.Models.Enums;

namespace Tetris.Models.Tetrominoes
{
    public class TetrominoFactory : ITetrominoFactory
    {

        public ITetromino CreateTetromino(TetrominoType type)
        {
            var typeOfTetromino = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(v => v.Name == type.ToString());

            ITetromino tetromino = (ITetromino)Activator.CreateInstance(typeOfTetromino);

            return tetromino;
        }

    }
}
