using Tetris.Models.Contracts;

namespace Tetris.Services.Contracts
{
    public interface IGameService
    {
        void StartTimers(IGame game);

        void UpdateScoreInfo(IGame game, int lines);
    }
}
