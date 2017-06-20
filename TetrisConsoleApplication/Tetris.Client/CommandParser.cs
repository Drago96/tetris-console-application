using System.Linq;
using Tetris.Client.Commands;
using Tetris.Data;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Models.Entities;
using Tetris.Services.Contracts;
using Tetris.Utilities;

namespace Tetris.Client
{
    using System;
    using Contracts;
    using Services;
    using Services.IO;
    using Services.Services;

    public class CommandParser : ICommandParser
    {
        private readonly MenuService menuService;
        private readonly GameService gameService;
        private readonly CurrentTetrominoService currentTetrominoService;
        private readonly BoardOutputService boardOutputService;
        private readonly TetrominoService tetrominoService;
        private readonly UserService userService;
        private readonly BoardService boardService;

        public CommandParser()
        {
            this.menuService = new MenuService();
            this.gameService = new GameService();
            this.currentTetrominoService = new CurrentTetrominoService();
            this.menuService = new MenuService();
            this.boardOutputService = new BoardOutputService();
            this.tetrominoService = new TetrominoService();
            this.userService = new UserService();
            this.boardService = new BoardService();
        }

        public void ParseCommand(int action)
        {          
            switch (action)
            {
                case 1:
                    ICommand startGameCommand = new StartGameCommand(gameService,userService,boardOutputService,tetrominoService,currentTetrominoService,boardService);
                    startGameCommand.Execute();
                    break;
                case 2:
                    ICommand howToPlayCommand = new HowToPlayCommand(menuService);
                    howToPlayCommand.Execute();
                    break;
                case 3:
                    ICommand showScoresCommand = new ShowScoresCommand(menuService);
                    showScoresCommand.Execute();
                    break;
                case 4:
                    ICommand showHighScoresCommand = new ShowHighScoresCommand(menuService);
                    showHighScoresCommand.Execute();
                    break;
                case 5:
                    ICommand showCreditsCommand = new ShowCreditsCommand(menuService);
                    showCreditsCommand.Execute();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }

     
    }
}
