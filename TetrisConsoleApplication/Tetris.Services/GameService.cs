using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class GameService
    {
       
        public void StartTimers(Game game)
        {
            game.Timer.Start();
            game.DropTimer.Start();
        }

        public void StartGamePrompt(Game game)
        {
            Console.SetCursorPosition(game.Board.Height/6, game.Board.Width/2);
            Console.WriteLine(Constants.StartGamePromptMessage);
            Console.ReadKey(true);
        }

        
    }
}
