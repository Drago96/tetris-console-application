using Tetris.Client.Contracts;
using Tetris.Services;

namespace Tetris.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {    
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowMenu();
        }
    }
}
