using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Contracts;

namespace Tetris.Models
{
    public class ScoreInfo : IScoreInfo
    {
        public ScoreInfo(int level, long score, int linesCleared)
        {
            this.Level = level;
            this.Score = score;
            this.LinesCleared = linesCleared;  
        }

        public int Level { get; set; }

        public long Score { get; set; }

        public int LinesCleared { get; set; }
    }
}
