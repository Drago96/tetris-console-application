using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.Contracts;
using Tetris.Services.Contracts;
using Tetris.Utilities;

namespace Tetris.Services
{
    public class GameService : IGameService
    {      
        public void StartTimers(IGame game)
        {
            game.Timer.Start();
            game.DropTimer.Start();
        }

        
    }
}
