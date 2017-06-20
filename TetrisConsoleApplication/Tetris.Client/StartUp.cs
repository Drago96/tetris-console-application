namespace Tetris.Client
{
    using Tetris.Client.Contracts;

    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}