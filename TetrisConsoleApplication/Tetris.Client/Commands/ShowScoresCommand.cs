﻿using System;
using System.Collections.Generic;
using Tetris.Models.Entities;
using Tetris.Utilities;

namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Services;

    class ShowScoresCommand : ICommand
    {
        private readonly MenuService menuService;
        private readonly UserService userService;

        public ShowScoresCommand(MenuService menuService,UserService userService)
        {
            this.menuService = menuService;
            this.userService = userService;
        }

        public void Execute()
        {
            Console.WriteLine(Constants.PleaseEnterUsername);
            var username = Console.ReadLine();
            ICollection<HighScore> highScores = userService.GetScoresByUsername(username);
            this.menuService.ShowScoresForUser(username,highScores);
        }
    }
}