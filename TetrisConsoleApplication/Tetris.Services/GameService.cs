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
            this.Game = new Game(Constants.BoardWidth,Constants.BoardHeight);
            
        }
        
        public void InitializeGame()
        {
            Console.CursorVisible = false;
            this.Game = new Game(Constants.BoardWidth,Constants.BoardHeight);
            BoardService boardService = new BoardService(this.Game.Board);
            boardService.DrawBoard();
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

        public Game Game { get; set; }
    }
}
