using Tetris.Services;

namespace Tetris.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            GameService gameService = new GameService();
            gameService.InitializeGame();
        }
    }
}
