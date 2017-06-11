using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Utilities
{
    public class Constants
    {
        public const int BoardHeight = 23;
        public const int BoardWidth = 10;

        public const char BlockSprite = '■';

        public const string BoardRearWallSprite = "*";
        public const string BoardBottomSprite = "*-";

        public const string StartGamePromptMessage = "Press any key";

        public const string LevelLable = "Level: ";
        public const string ScoreLable = "Score: ";
        public const string LinesClearedLable = "Lines cleared: ";

        public const int StartLevel = 1;
        public const int StartScore = 0;
        public const int StartLinesCleared = 0;
    }
}
