using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models
{
    public class BoardBorder
    {
        public BoardBorder(string rearWallSprite, string bottomSprite)
        {        
            this.RearWallSprite = rearWallSprite;
            this.BottomSprite = bottomSprite;
        }

        public string RearWallSprite { get; private set; }

        public string BottomSprite { get; private set; }
    }
}
