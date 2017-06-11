using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;

namespace Tetris.Models.Tetrominoes
{
    public class TetrominoFactory
    {
        public TetrominoFactory()   
        {
            this.Tetrominoes = new Queue<ITetromino>();

            var type = typeof(Tetromino);

            this.TetrominoTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(v => v != type && v.IsSubclassOf(type)).ToList();

            this.IsTetrominoSpawned = false;
        }

        public Queue<ITetromino> Tetrominoes { get; set; }

        public List<Type> TetrominoTypes { get; set; }

        public bool IsTetrominoSpawned { get; set; }
    }
}
