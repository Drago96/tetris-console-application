namespace Tetris.Client
{
    using System;
    using Contracts;
    using Services;
    using Services.IO;
    using Services.Services;

    public class CommandParser
    {
        private readonly MenuService menuService = new MenuService();
        private readonly ConsoleWriter consoleWriter = new ConsoleWriter();

        public void ParseCommand(int action)
        {          
            switch (action)
            {
                case 1:
                    IEngine engine = new Engine();
                    engine.Run();
                    break;
                case 2:
                    menuService.ShowHowToPlay();
                    break;
                case 3:
                    if (AuthenticationManager.IsAuthenticated())
                    {
                        menuService.ShowScoresForUser(AuthenticationManager.GetCurrentUser().Name);
                    }
                    break;
                case 4:
                    menuService.ShowTop10();
                    break;
                case 5:
                    menuService.ShowCredits();
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
