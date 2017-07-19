namespace Tetris.Client
{
    using Tetris.Client.Contracts;

    internal class StartUp
    {
        private static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}