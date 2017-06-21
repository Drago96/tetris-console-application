﻿namespace Tetris.Utilities
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
        public const string PleaseEnterUsername = "Please enter an username.";
        public const string UserDoesNotHaveScores = "doesn't have any scores on the board.";
        public const string Highscores = "High Scores";
        public const string NoSuchUserOrNoScores = "Their is no such user or the user doesn't have any scores.";

        public const string LeftArrow = "← - Slide tetrimino left";
        public const string RightArrow = "→ - Slide tetrimino right";
        public const string UpArrow = "↑ - Hard drop";
        public const string DownArrow = "↓ - Soft drop";
        public const string Space = "Space - Rotate tetrimino";

        public const int StartLevel = 1;
        public const long StartScore = 0;
        public const int StartLinesCleared = 0;

        public const int TetrominoRefillCount = 10;

        public const int LinesToClear = 4;
        public const int ColumnsToClear = 10;

        public const string CurrentPlayerNameLabel = "Player name: ";

        public const int TetrominoDropRate = 250;

        public const string GameOverLabel = " Game Over ";
        public const string Credits = "Drago96\nhopeee\nIliyanPopov\ndimpeev\nNikola";
        public const string EnterNamePrompt = "Please enter your name... (Press ENTER if you want to play anonimously)";
    }
}