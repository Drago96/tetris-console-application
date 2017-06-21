using System.Collections;
using System.Collections.Generic;
using Tetris.Models.Entities;

namespace Tetris.Client.Commands
{
    using Tetris.Client.Contracts;
    using Tetris.Services;

    class ShowHighScoresCommand : ICommand
    {
        private readonly MenuService menuService;
        private readonly HighScoreService highScoreService;

        public ShowHighScoresCommand(MenuService menuService,HighScoreService highScoreService)
        {
            this.menuService = menuService;
            this.highScoreService = highScoreService;
        }

        public void Execute()
        {
            ICollection<HighScore> highScores = highScoreService.GetTopTenHighScores();
            this.menuService.ShowHighScores(highScores);
        }
    }
}