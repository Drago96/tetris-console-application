﻿namespace Tetris.Models.Enums
{
    using System.ComponentModel;

    public enum MenuOptions
    {
        [Description("New game")] NewGame,
        [Description("How to play")] HowToPlay,
        [Description("Highscores of single user")] HighscoresPerUser,
        [Description("Top 10")] Top10,
        [Description("Credits")] Credits,
        [Description("Exit game")] Quit
    }

}
