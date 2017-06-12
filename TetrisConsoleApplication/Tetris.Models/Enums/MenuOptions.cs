namespace Tetris.Models.Enums
{
    using System.ComponentModel;

    public enum MenuOptions
    {
        [Description("New anonymous game")] NewGameAnonymous,
        [Description("New game as a registered user")] NewGameRegistered,
        [Description("Highscores of single user")] HighscoresPerUser,
        [Description("Top 10")] Top10,
        [Description("Credits")] Credits,
        [Description("Exit game")] Quit
    }

}
