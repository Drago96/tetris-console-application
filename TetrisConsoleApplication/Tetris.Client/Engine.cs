﻿using System;
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
        public Engine()
        {
            this.GameService = new GameService();
            this.BoardStateService = new BoardStateService();
            this.MenuService = new MenuService();
            this.OutputService = new OutputService();
            this.TetrominoService = new TetrominoService();
            this.UserService = new UserService();
        }

        private IGameService GameService { get; set; }
        private IBoardStateService BoardStateService { get; set; }
        private MenuService MenuService { get; set; }
        private IOutputService OutputService { get; set; }
        private ITetrominoService TetrominoService { get; set; }
        private UserService UserService { get; set; }

        public void Run()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
         

            IGame game = new Game(Constants.BoardWidth, Constants.BoardHeight, Constants.StartLevel,
                Constants.StartScore, Constants.StartLinesCleared, Constants.BlockSprite, Constants.BoardRearWallSprite,
                Constants.BoardBottomSprite);       

            Console.CursorVisible = false;
            OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
            OutputService.StartGamePrompt(game);
            GameService.StartTimers(game);

            while (true)
            {
                if (game.DropTimer.ElapsedMilliseconds > 150)
                {
                    if (game.CurrentTetromino == null)
                    {
                        game.CurrentTetromino = BoardStateService.SpawnTetromino(
                            TetrominoService.GetNextTetromino(game.TetrominoRepository, game.TetrominoFactory), game.Board,
                            game.CurrentTetromino);
                    }
                    while (Console.KeyAvailable)
                    {
                        key = Console.ReadKey();
                        
                        if (key.Key == ConsoleKey.RightArrow )
                        {
                            game.CurrentTetromino =
                                BoardStateService.MoveTetrominoRight(game.Board, game.CurrentTetromino);
                        }
                        else if (key.Key == ConsoleKey.LeftArrow )
                        {
                            game.CurrentTetromino =
                                BoardStateService.MoveTetrominoLeft(game.Board, game.CurrentTetromino);
                        }
                       
                    }
                    game.CurrentTetromino = BoardStateService.MoveTetrominoDown(game.Board, game.CurrentTetromino);
                    OutputService.InitializeBoard(game.Board, game.ScoreInfo,
                        TetrominoService.PeekNextTetromino(game.TetrominoRepository, game.TetrominoFactory));
                    game.DropTimer.Restart();
                }
                
                
            }




        }


    }
}
