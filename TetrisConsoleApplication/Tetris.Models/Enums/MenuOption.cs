namespace Tetris.Models.Enums
{
    using System.ComponentModel;

    public enum MenuOption
    {
        [Description("New game")] NewGame,
        [Description("How to play")] HowToPlay,
        [Description("My scores")] CurrentUserScores,
        [Description("High Scores")] HighScores,
        [Description("Credits")] Credits,
        [Description("Exit game")] Quit
    }
}