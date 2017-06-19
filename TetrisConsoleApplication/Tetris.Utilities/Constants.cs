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

        public const string NoScoresToShow = "There are no scores to show.";
        public const string ChooseAction = "Please choose an action...";
        public const string EscapeToReturnToPreviousMenu = "Press ESC to go to the previous menu.";
        public const string PleaseEnterUsername = "Please enter username.";
        public const string UserDoesNotHaveScores = "doesn't have any scores on the board.";
        public const string Top10 = "TOP 10";

        public const int StartLevel = 1;
        public const int StartScore = 0;
        public const int StartLinesCleared = 0;

        public const int TetrominoRefillCount = 10;

        public const int LinesToClear = 4;
        public const int ColumnsToClear = 10;

        public const string CurrentPlayerNameLabel = "Player name: ";
    }
}
