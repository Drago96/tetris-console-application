using System;
using System.Linq;
using System.Reflection;
using Tetris.Models.Contracts;
using Tetris.Models.Enums;

namespace Tetris.Models.Tetrominoes
{
    public class TetrominoFactory : ITetrominoFactory
    {
        private Random randomNumberGenerator;
        private TetrominoType[] tetrominoTypes;

        public TetrominoFactory()
        {
            randomNumberGenerator = new Random();
            tetrominoTypes = Enum.GetValues(typeof(TetrominoType)).Cast<TetrominoType>().ToArray();
        }

        public ITetromino CreateTetromino()
        {
            TetrominoType type = GenerateRandomTetrominoType();

            var typeOfTetromino = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(v => v.Name == type.ToString());

            ITetromino tetromino = (ITetromino)Activator.CreateInstance(typeOfTetromino);

            return tetromino;
        }

        private TetrominoType GenerateRandomTetrominoType()
        {
            return tetrominoTypes[randomNumberGenerator.Next(0, tetrominoTypes.Length)];
        }

    }
}
