﻿using Tetris.Services;

namespace Tetris.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {    

            Engine engine = new Engine();
            engine.Run();

            //MenuService menuService = new MenuService();
            //menuService.InitializeMenu();


            // test to find the first user, he is seeded in db creation, 
            //UserService userService = new UserService();
            //var user = userService.GetUserById(1);
            //Console.WriteLine();
        }
    }
}
