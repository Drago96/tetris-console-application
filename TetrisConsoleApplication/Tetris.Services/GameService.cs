namespace Tetris.Services
{
    using Tetris.Models.Contracts;

    public class GameService
    {
        public void StartTimers(IGame game)
        {
            game.DropTimer.Start();
        }

        public void UpdateScoreInfo(IGame game, int lines)
        {
            game.ScoreInfo.Score += lines * game.ScoreInfo.Level * game.ScoreInfo.ScorePerLine;
            int progressionToNextLevel = game.ScoreInfo.LinesCleared % game.ScoreInfo.LinesPerLevel;
            if (progressionToNextLevel + lines >= game.ScoreInfo.LinesPerLevel)
            {
                game.ScoreInfo.Level++;
                game.TetrominoDropRate -= game.TetrominoDropRateIncrease;
            }
            game.ScoreInfo.LinesCleared += lines;
        }
    }
}