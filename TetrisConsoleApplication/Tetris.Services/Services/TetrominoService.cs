namespace Tetris.Services.Services
{
    using Contracts;
    using Models.Contracts;
    using Utilities;

    public class TetrominoService 
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
