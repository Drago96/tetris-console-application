using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Models.Tetrominoes;
using Tetris.Services;
using Tetris.Utilities;

namespace Tetris.Client
{
    public class Engine
    {
        public GameService GameService { get; set; }
        public BoardStateService BoardStateService { get; set; }
        public MenuService MenuService { get; set; }
        public OutputService OutputService { get; set; }
        public TetrominoService TetrominoService { get; set; }
        public UserService UserService { get; set; }

        public void Run()
        {
            this.GameService = new GameService();
            this.BoardStateService = new BoardStateService();
            this.MenuService = new MenuService();
            this.OutputService = new OutputService();
            this.TetrominoService = new TetrominoService();
            this.UserService = new UserService();

            Game Game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite);
            ITetrominoFactory tetrominoFactory = new TetrominoFactory();
            ITetrominoRepository tetrominoRepository = new TetrominoRepository();
            CurrentTetromino currentTetromino = null;

            Console.CursorVisible = false;

            while (true)
            {
                if (currentTetromino == null)
                {
                    currentTetromino = BoardStateService.SpawnTetromino(
                        TetrominoService.GetNextTetromino(tetrominoRepository, tetrominoFactory), Game.Board,
                        currentTetromino);
                }
                currentTetromino = BoardStateService.MoveTetrominoDown(Game.Board, currentTetromino);
                OutputService.InitializeBoard(Game.Board, Game.ScoreInfo,
                    TetrominoService.PeekNextTetromino(tetrominoRepository, tetrominoFactory));
                Thread.Sleep(100);
            }




        }


    }
}
