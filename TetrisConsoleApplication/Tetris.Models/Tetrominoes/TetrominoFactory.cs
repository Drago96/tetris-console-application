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
        public TetrominoFactory()   
        {

           // var type = typeof(Tetromino);
           //
           // this.TetrominoTypes = Assembly.GetExecutingAssembly().GetTypes()
           //     .Where(v => v != type && v.IsSubclassOf(type)).ToList();
           //
           // this.IsTetrominoSpawned = false;
        }

        public ITetromino CreateTetromino(TetrominoType type)
        {
            var typeOfTetromino = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(v => v.Name == type.ToString());

            ITetromino tetromino = (ITetromino)Activator.CreateInstance(typeOfTetromino);

            return tetromino;
        }


        public List<Type> TetrominoTypes { get; set; }

        public bool IsTetrominoSpawned { get; set; }

    }
}
