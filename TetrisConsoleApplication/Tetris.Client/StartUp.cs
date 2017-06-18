using Tetris.Client.Contracts;
using Tetris.Services;

namespace Tetris.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {    

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
