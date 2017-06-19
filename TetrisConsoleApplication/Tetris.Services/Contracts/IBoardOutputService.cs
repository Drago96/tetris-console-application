using Tetris.Models;
using Tetris.Models.Contracts;

namespace Tetris.Services.Contracts
{
    public interface IBoardOutputService
    {
        IOutputWriter consoleWriter { get; }

        void InitializeBoard(IBoard board, ScoreInfo scoreInfo, ITetromino tetromino);

        void DrawBoard(IBoard board);

        void DrawBorder(IBoard board);

        void DisplayInfo(IBoard board, ScoreInfo scoreInfo);

        void DisplayNextTetromino(IBoard board, ITetromino tetromino);

        void StartGamePrompt(IGame game);

        void DisplayGameOver(IGame game);
    }
}
