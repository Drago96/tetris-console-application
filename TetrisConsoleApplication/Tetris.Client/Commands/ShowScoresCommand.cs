using System;
using System.Collections.Generic;
using Tetris.Models.Entities;
using Tetris.Services.IO;
using Tetris.Utilities;

namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Services;

    internal class ShowScoresCommand : ICommand
    {
        private readonly MenuService menuService;
        private readonly UserService userService;

        public ShowScoresCommand(MenuService menuService, UserService userService)
        {
            this.menuService = menuService;
            this.userService = userService;
        }

        public void Execute()
        {
            ConsoleWriter.WriteLine(Constants.PleaseEnterUsername);
            var username = ConsoleReader.ReadLine();
            ICollection<HighScore> highScores = userService.GetScoresByUsername(username);
            this.menuService.ShowScoresForUser(username, highScores);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}