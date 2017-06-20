using System.Linq;
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
                    IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                        Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                        Constants.BoardBottomSprite, Constants.TetrominoDropRate);
                    gameService.StartGame(game, userService,boardOutputService,tetrominoService,currentTetrominoService,boardService);
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
            }
        }

     
    }
}
