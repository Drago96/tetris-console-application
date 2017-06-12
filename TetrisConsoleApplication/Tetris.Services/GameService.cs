using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class GameService
    {
        public GameService()
        {
            this.Game = new Game(Constants.BoardWidth,Constants.BoardHeight,Constants.StartLevel,Constants.StartScore,Constants.StartLinesCleared, Constants.BlockSprite,Constants.BoardRearWallSprite,Constants.BoardBottomSprite);
            this.OutputService = new OutputService(this.Game.Board,this.Game.ScoreInfo);
            this.TetrominoService = new TetrominoService();
            this.BoardService = new BoardService(this.Game.Board);
            
        }

        public Game Game { get; set; }
        public OutputService OutputService { get; set; }
        public BoardService BoardService { get; set; }
        public TetrominoService TetrominoService { get; set; }

        public void InitializeGame()
        {
            
            Console.CursorVisible = false;
            BoardService.SpawnTetromino(TetrominoService.GetNextTetromino());
            BoardService.MoveTetrominoDown();
            BoardService.MoveTetrominoDown();
            OutputService.InitializeBoard();
            this.StartGamePrompt();
            this.StartTimers();
                                
        }

        private void StartTimers()
        {
            this.Game.Timer.Start();
            this.Game.DropTimer.Start();
        }

        public void StartGamePrompt()
        {
            Console.SetCursorPosition(Game.Board.Height/6, Game.Board.Width/2);
            Console.WriteLine(Constants.StartGamePromptMessage);
            Console.ReadKey(true);
        }

        
    }
}
