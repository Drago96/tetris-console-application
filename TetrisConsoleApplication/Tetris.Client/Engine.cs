using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tetris.Client.Contracts;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Models.Tetrominoes;
using Tetris.Services;
using Tetris.Services.Contracts;
using Tetris.Utilities;

namespace Tetris.Client
{
    public class Engine : IEngine
    {
        private IGameService GameService { get; set; }
        private IBoardStateService BoardStateService { get; set; }
        private MenuService MenuService { get; set; }
        private IOutputService OutputService { get; set; }
        private ITetrominoService TetrominoService { get; set; }
        private UserService UserService { get; set; }

        public void Run()
        {
            this.GameService = new GameService();
            this.BoardStateService = new BoardStateService();
            this.MenuService = new MenuService();
            this.OutputService = new OutputService();
            this.TetrominoService = new TetrominoService();
            this.UserService = new UserService();

            IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite);
           
            

            Console.CursorVisible = false;
            OutputService.StartGamePrompt(game);

            while (true)
            {
                if (game.CurrentTetromino == null)
                {
                    game.CurrentTetromino = BoardStateService.SpawnTetromino(
                        TetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory), game.Board,
                        game.CurrentTetromino);
                }
                game.CurrentTetromino = BoardStateService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                game.CurrentTetromino = BoardStateService.MoveTetrominoRight(game.Board, game.CurrentTetromino);
                OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                    TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
                Thread.Sleep(100);
            }




        }


    }
}
