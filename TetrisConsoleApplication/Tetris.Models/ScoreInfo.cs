using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models
{
    public class ScoreInfo
    {
        public ScoreInfo(int level, int score, int linesCleared)
        {
            this.Level = level;
            this.Score = score;
            this.LinesCleared = linesCleared;  
        }

        public int Level { get; set; }

        public int Score { get; set; }

        public int LinesCleared { get; set; }
    }
}
