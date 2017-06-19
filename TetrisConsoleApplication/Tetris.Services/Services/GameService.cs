using System.Runtime.Remoting.Activation;

namespace Tetris.Services.Services
{
    using Contracts;
    using Models.Contracts;

    public class GameService : IGameService
    {      
        public void StartTimers(IGame game)
        {
            game.DropTimer.Start();
        }

        public void UpdateScoreInfo(IGame game, int lines)
        {
            game.ScoreInfo.Score += lines * game.ScoreInfo.Level * 10;
            int progressionToNextLevel = game.ScoreInfo.LinesCleared % 5;
            if (progressionToNextLevel + lines >= 5)
            {
                game.ScoreInfo.Level++;
                game.TetrominoDropRate -= 25;
            }
            game.ScoreInfo.LinesCleared += lines;
        }
        
    }
}
