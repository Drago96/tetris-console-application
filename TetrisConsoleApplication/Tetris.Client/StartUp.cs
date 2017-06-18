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

            // test to find the first user, he is seeded in db creation, 
            //UserService userService = new UserService();
            //var user = userService.GetUserById(1);
            //Console.WriteLine();
        }
    }
}
