namespace Tetris.Client
{
    using System;
    using Contracts;

    public static class CommandParser
    {
        public static void ParseCommand(int action)
        {
            switch (action)
            {
                case 1:
                    IEngine engine = new Engine();
                    engine.Run();
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }
}
