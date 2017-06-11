using System;
using System.Collections.Generic;
using System.Linq;
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
            var type = typeof(ITetromino);
            this.TetrominoTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p)).ToList();
            this.IsTetrominoSpawned = false;
        }

        public Queue<ITetromino> Tetrominoes { get; set; }

        public List<Type> TetrominoTypes { get; set; }

        public bool IsTetrominoSpawned { get; set; }
    }
}
