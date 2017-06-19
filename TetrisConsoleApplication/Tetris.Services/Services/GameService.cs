namespace Tetris.Services.Services
{
    using Contracts;
    using Models.Contracts;

    public class GameService : IGameService
    {      
        public void StartTimers(IGame game)
        {
            game.Timer.Start();
            game.DropTimer.Start();
        }

        
    }
}
