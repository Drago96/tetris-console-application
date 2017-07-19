namespace Tetris.Models.Tetrominoes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Tetris.Models.Contracts;
    using Tetris.Models.Enums;

    public class TetrominoFactory : ITetrominoFactory
    {
        private Random randomNumberGenerator;
        private TetrominoType[] tetrominoTypes;

        public TetrominoFactory()
        {
            this.randomNumberGenerator = new Random();
            this.tetrominoTypes = Enum.GetValues(typeof(TetrominoType)).Cast<TetrominoType>().ToArray();
        }

        public ITetromino CreateTetromino()
        {
            TetrominoType type = this.GenerateRandomTetrominoType();

            var typeOfTetromino = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(v => v.Name == type.ToString());

            ITetromino tetromino = (ITetromino)Activator.CreateInstance(typeOfTetromino);

            return tetromino;
        }

        private TetrominoType GenerateRandomTetrominoType()
        {
            return this.tetrominoTypes[this.randomNumberGenerator.Next(0, this.tetrominoTypes.Length)];
        }
    }
}