using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Contracts
{
    public interface IBoardBorder
    {
        char RearWallSprite { get; }
        
        string BottomSprite { get; }
    }
}
