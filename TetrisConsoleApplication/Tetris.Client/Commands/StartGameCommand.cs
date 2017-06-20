using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Client.Contracts;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Services.Services;
using Tetris.Utilities;

namespace Tetris.Client.Commands
{
    class StartGameCommand : ICommand
    {
        private readonly GameService gameService;
        private readonly UserService userService;
        private readonly BoardOutputService boardOutputService;
        private readonly TetrominoService tetrominoService;
        private readonly CurrentTetrominoService currentTetrominoService;
        private readonly BoardService boardService;

        public StartGameCommand(GameService gameService, UserService userService, BoardOutputService boardOutputService, TetrominoService tetrominoService, CurrentTetrominoService currentTetrominoService, BoardService boardService)
        {
            this.gameService = gameService;
            this.userService = userService;
            this.boardOutputService = boardOutputService;
            this.tetrominoService = tetrominoService;
            this.currentTetrominoService = currentTetrominoService;
            this.boardService = boardService;
        }                       
                                
        public void Execute()   
        {
            IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite, Constants.TetrominoDropRate);
            gameService.StartGame(game, userService, boardOutputService, tetrominoService, currentTetrominoService, boardService);
        }
    }
}
